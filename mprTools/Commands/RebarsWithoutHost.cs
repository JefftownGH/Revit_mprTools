namespace mprTools.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.DB.Structure;
    using Autodesk.Revit.UI;
    using ModPlusAPI;
    using ModPlusAPI.Windows;

    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class RebarsWithoutHost : IExternalCommand
    {
        private const string LangItem = "mprTools";

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
#if !DEBUG
            Statistic.SendCommandStarting("mprRebarsWithoutHost", new ModPlusConnector().AvailProductExternalVersion);
#endif
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;

                IList<Rebar> rebars = new FilteredElementCollector(doc)
                    .OfClass(typeof(Rebar))
                    .WhereElementIsNotElementType()
                    .Where(x => x.IsValidObject && x.Category != null)
                    .Cast<Rebar>()
                    .ToList();
                IList<RebarInSystem> rebarInSystems = new FilteredElementCollector(doc)
                    .OfClass(typeof(RebarInSystem))
                    .WhereElementIsNotElementType()
                    .Where(x => x.IsValidObject && x.Category != null)
                    .Cast<RebarInSystem>()
                    .ToList();

                var taskDialog = new TaskDialog(Language.GetItem(LangItem, "h17"));
                if (!rebars.Any() && !rebarInSystems.Any())
                {
                    // В текущем проекте не найдена арматура
                    taskDialog.MainContent = Language.GetItem(LangItem, "m2");
                    taskDialog.Show();
                    return Result.Cancelled;
                }

                taskDialog.MainContent =
                    //// В текущем проекте найдено:
                    $"{Language.GetItem(LangItem, "m3")}{Environment.NewLine}{Language.GetItem(LangItem, "m4")} {rebars.Count}{Environment.NewLine}{Language.GetItem(LangItem, "m5")} {rebarInSystems.Count}";

                taskDialog.AddCommandLink(
                    TaskDialogCommandLinkId.CommandLink1,
                    //// Выполнить проверку
                    Language.GetItem(LangItem, "m6"));
                var dialogResult = taskDialog.Show();

                if (dialogResult == TaskDialogResult.CommandLink1)
                {
                    taskDialog = new TaskDialog(Language.GetItem(LangItem, "h17"));
                    //// Результат проверки:
                    taskDialog.MainContent = Language.GetItem(LangItem, "m7");

                    // для кэширования
                    var hostDictionary = new Dictionary<int, List<Solid>>();

                    var outsideHostRebars = new List<ElementId>();
                    var noHostRebars = new List<ElementId>();
                    var systemsOutsideHost = new List<ElementId>();

                    foreach (var rebar in rebars)
                    {
                        var hostId = rebar.GetHostId();
                        if (hostId == ElementId.InvalidElementId)
                        {
                            noHostRebars.Add(rebar.Id);
                        }
                        else
                        {
                            var hostSolids = GetHostSolids(hostDictionary, hostId, doc);

                            var rebarCurves =
                                rebar.GetCenterlineCurves(false, false, false, MultiplanarOption.IncludeAllMultiplanarCurves, 0)
                                    .ToList();

                            if (rebar.LayoutRule == RebarLayoutRule.Single)
                            {
                                if (!IntersectWithSolids(rebarCurves, hostSolids))
                                    outsideHostRebars.Add(rebar.Id);
                            }
                            else
                            {
                                if (HasOutsideCurves(rebarCurves, hostSolids))
                                    outsideHostRebars.Add(rebar.Id);
                            }
                        }
                    }

                    foreach (var rebarInSystem in rebarInSystems)
                    {
                        var hostId = rebarInSystem.GetHostId();
                        if (hostId == ElementId.InvalidElementId)
                        {
                            noHostRebars.Add(rebarInSystem.Id);
                        }
                        else
                        {
                            var systemCurves = rebarInSystem.GetCenterlineCurves(false, false, false).ToList();
                            var hostSolids = GetHostSolids(hostDictionary, hostId, doc);
                            if (HasOutsideCurves(systemCurves, hostSolids))
                                systemsOutsideHost.Add(rebarInSystem.Id);
                        }
                    }

                    var selectAll = false;
                    var allElementIds = new List<ElementId>();

                    if (outsideHostRebars.Any())
                    {
                        // Арматурные стержни, находящиеся вне основы или выступающие за основу (при компоновке):
                        taskDialog.MainContent +=
                            $"{Environment.NewLine}{Language.GetItem(LangItem, "m8")} {outsideHostRebars.Count}";

                        // Выбрать арматурные стержни
                        taskDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, Language.GetItem(LangItem, "m9"));
                        if (noHostRebars.Any() || systemsOutsideHost.Any())
                            selectAll = true;
                    }

                    if (noHostRebars.Any())
                    {
                        // Арматура, не имеющая основы:
                        taskDialog.MainContent +=
                            $"{Environment.NewLine}{Language.GetItem(LangItem, "m10")} {noHostRebars.Count}";

                        // Выбрать арматурные стержни
                        taskDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, Language.GetItem(LangItem, "m9"));
                        if (outsideHostRebars.Any() || systemsOutsideHost.Any())
                            selectAll = true;
                    }

                    if (systemsOutsideHost.Any())
                    {
                        // Арматурные стержни в системе, выступающие за основу:
                        taskDialog.MainContent +=
                            $"{Environment.NewLine}{Language.GetItem(LangItem, "m11")} {systemsOutsideHost.Count}";

                        // Выбрать системы
                        taskDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink3, Language.GetItem(LangItem, "m12"));
                        if (outsideHostRebars.Any() || noHostRebars.Any())
                            selectAll = true;
                    }

                    if (selectAll)
                    {
                        allElementIds.AddRange(outsideHostRebars);
                        allElementIds.AddRange(noHostRebars);
                        allElementIds.AddRange(systemsOutsideHost);

                        // Выбрать все
                        taskDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink4, Language.GetItem(LangItem, "m13"));
                    }

                    if (!outsideHostRebars.Any() && !noHostRebars.Any() && !systemsOutsideHost.Any())
                    {
                        // Ничего не найдено
                        taskDialog.MainContent += Environment.NewLine + Language.GetItem(LangItem, "m14");
                    }

                    dialogResult = taskDialog.Show();

                    if (dialogResult == TaskDialogResult.CommandLink1)
                    {
                        commandData.Application.ActiveUIDocument.Selection.SetElementIds(outsideHostRebars);
                    }

                    if (dialogResult == TaskDialogResult.CommandLink2)
                    {
                        commandData.Application.ActiveUIDocument.Selection.SetElementIds(noHostRebars);
                    }

                    if (dialogResult == TaskDialogResult.CommandLink3)
                    {
                        commandData.Application.ActiveUIDocument.Selection.SetElementIds(systemsOutsideHost);
                    }

                    if (dialogResult == TaskDialogResult.CommandLink4)
                    {
                        commandData.Application.ActiveUIDocument.Selection.SetElementIds(allElementIds);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
            }

            return Result.Succeeded;
        }

        /// <summary>
        /// Получить список солидов основы
        /// </summary>
        /// <param name="hostDictionary">Словарь кэшированных списков солидов</param>
        /// <param name="hostId">Идентификатор элемента-основы</param>
        /// <param name="doc">Документ</param>
        private List<Solid> GetHostSolids(Dictionary<int, List<Solid>> hostDictionary, ElementId hostId, Document doc)
        {
            List<Solid> hostSolids;
            if (hostDictionary.ContainsKey(hostId.IntegerValue))
            {
                hostSolids = hostDictionary[hostId.IntegerValue];
            }
            else
            {
                hostSolids = GetSolids(doc.GetElement(hostId));
                hostDictionary.Add(hostId.IntegerValue, hostSolids);
            }

            return hostSolids;
        }

        /// <summary>
        /// Получение списка солидов из элемента
        /// </summary>
        /// <param name="element">Элемент</param>
        private List<Solid> GetSolids(Element element)
        {
            var solids = new List<Solid>();
            foreach (var geometryObject in element.get_Geometry(new Options
            {
                ComputeReferences = false,
                IncludeNonVisibleObjects = false,
                DetailLevel = ViewDetailLevel.Fine
            }))
            {
                if (geometryObject is Solid solid &&
                   solid.Volume > 0)
                    solids.Add(solid);
            }

            return solids;
        }

        /// <summary>
        /// Проверка, что список кривых содержит хотя бы одно пересечение со списком солидов
        /// </summary>
        /// <param name="curves">Список кривых</param>
        /// <param name="solids">Список солидов</param>
        private static bool IntersectWithSolids(List<Curve> curves, List<Solid> solids)
        {
            foreach (var curve in curves)
            {
                foreach (var solid in solids)
                {
                    var intersectWithCurve = solid.IntersectWithCurve(
                        curve,
                        new SolidCurveIntersectionOptions { ResultType = SolidCurveIntersectionMode.CurveSegmentsInside });
                    if (intersectWithCurve.SegmentCount > 0)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Проверка, что список кривых содержит хотя бы одну кривую, имеющую пересечение с любым солидом из списка и выступающую
        /// за границу солида
        /// </summary>
        /// <param name="curves">Список кривых</param>
        /// <param name="solids">Список солидов</param>
        private static bool HasOutsideCurves(List<Curve> curves, List<Solid> solids)
        {
            foreach (var curve in curves)
            {
                foreach (var solid in solids)
                {
                    var intersectWithCurve = solid.IntersectWithCurve(
                        curve,
                        new SolidCurveIntersectionOptions { ResultType = SolidCurveIntersectionMode.CurveSegmentsOutside });
                    if (intersectWithCurve.SegmentCount > 0)
                        return true;
                }
            }

            return false;
        }
    }
}
