using System;
using System.Collections.Generic;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ModPlusAPI;
using ModPlusAPI.Windows;
// ReSharper disable UnusedMember.Global

namespace mprTools.Commands
{
    #region Show
    [Transaction(TransactionMode.Manual)]
    public class WallsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Walls, "Walls");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class WindowsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Windows, "Windows");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class DoorsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Doors, "Doors");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class TagsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, "Tags");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class FloorsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Floors, "Floors");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class ColumnsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, "Columns");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class GridsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Grids, "Grids");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class LevelsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Levels, "Levels");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class RampsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Ramps, "Ramps");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class StairsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Stairs, "Stairs");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class StairsRailingShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData,
                new List<BuiltInCategory> { BuiltInCategory.OST_Railings, BuiltInCategory.OST_StairsRailing },
                "StairsRailing");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class RoofsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Roofs, "Roofs");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class CeilingsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Ceilings, "Ceilings");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class ElevationsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Elev, "Elevations");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class SectionsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Sections, "Sections");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class ComponentsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, new List<BuiltInCategory>
            {
                BuiltInCategory.OST_DetailComponents,
                BuiltInCategory.OST_Furniture,
                BuiltInCategory.OST_FurnitureSystems,
                BuiltInCategory.OST_Casework,
                BuiltInCategory.OST_Entourage,
                BuiltInCategory.OST_Site,
                BuiltInCategory.OST_Parking,
                BuiltInCategory.OST_Planting
            }, "Components");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class ReferencePlanesShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_CLines, "ReferencePlane");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class StructuralFramingShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_StructuralFraming, "StructuralFraming");
        }
    }
    #endregion

    #region Hide
    [Transaction(TransactionMode.Manual)]
    public class WallsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Walls, "Walls");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class WindowsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Windows, "Windows");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class DoorsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Doors, "Doors");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class TagsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, "Tags");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class FloorsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Floors, "Floors");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class ColumnsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, "Columns");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class GridsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Grids, "Grids");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class LevelsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Levels, "Levels");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class RampsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Ramps, "Ramps");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class StairsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Stairs, "Stairs");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class StairsRailingHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData,
                new List<BuiltInCategory> { BuiltInCategory.OST_Railings, BuiltInCategory.OST_StairsRailing },
                "StairsRailing");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class RoofsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Roofs, "Roofs");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class CeilingsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Ceilings, "Ceilings");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class ElevationsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Elev, "Elevations");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class SectionsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Sections, "Sections");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class ComponentsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, new List<BuiltInCategory>
            {
                BuiltInCategory.OST_DetailComponents,
                BuiltInCategory.OST_Furniture,
                BuiltInCategory.OST_FurnitureSystems,
                BuiltInCategory.OST_Casework,
                BuiltInCategory.OST_Entourage,
                BuiltInCategory.OST_Site,
                BuiltInCategory.OST_Parking,
                BuiltInCategory.OST_Planting
            }, "Components");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class ReferencePlanesHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_CLines, "ReferencePlane");
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class StructuralFramingHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new Interface().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_StructuralFraming, "StructuralFraming");
        }
    }
    #endregion

    public static class ShowHideHelper
    {
        private const string LangItem = "mprTools";

        /// <summary>Скрыть указанную категорию с текущего вида</summary>
        /// <param name="commandData"></param>
        /// <param name="cat">Категория</param>
        /// <param name="name">Имя категории, отображаемое в транзакции</param>
        public static Result HideCategory(ExternalCommandData commandData, BuiltInCategory cat, string name)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;
                Category category = doc.Settings.Categories.get_Item(cat);
                if (category?.get_Visible(doc.ActiveView) == true)
                    using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                    {
                        tr.Start();
                        category.set_Visible(doc.ActiveView, false);
                        tr.Commit();
                    }
                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Скрыть указанную категорию с текущего вида</summary>
        /// <param name="commandData"></param>
        /// <param name="cats">Список категорий</param>
        /// <param name="name">Имя категории, отображаемое в транзакции</param>
        public static Result HideCategory(ExternalCommandData commandData, List<BuiltInCategory> cats, string name)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (var cat in cats)
                    {
                        Category category = doc.Settings.Categories.get_Item(cat);
                        if (category?.get_Visible(doc.ActiveView) == true)
                            category.set_Visible(doc.ActiveView, false);
                    }
                    tr.Commit();
                }
                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Скрыть категории, название которых содержит указанное значение</summary>
        /// <param name="commandData"></param>
        /// <param name="name">Имя категории. Оно же должно содержаться в строковм представлении перечеслителя категории</param>
        public static Result HideCategory(ExternalCommandData commandData, string name)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (BuiltInCategory cat in Enum.GetValues(typeof(BuiltInCategory)))
                    {
                        if (cat.ToString().Contains(name))
                        {
                            Category category = doc.Settings.Categories.get_Item(cat);
                            if (category?.get_Visible(doc.ActiveView) == true)
                            {
                                category.set_Visible(doc.ActiveView, false);
                            }
                        }
                    }
                    tr.Commit();
                }
                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Скрыть категории, название которых содержит указанное значение</summary>
        /// <param name="commandData"></param>
        /// <param name="name">Имя категории</param>
        /// <param name="contains">Значение, которое должно содержаться в строковм представлении перечеслителя категории</param>
        public static Result HideCategory(ExternalCommandData commandData, string name, string contains)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (BuiltInCategory cat in Enum.GetValues(typeof(BuiltInCategory)))
                    {
                        if (cat.ToString().Contains(contains))
                        {
                            Category category = doc.Settings.Categories.get_Item(cat);
                            if (category?.get_Visible(doc.ActiveView) == true)
                            {
                                category.set_Visible(doc.ActiveView, false);
                            }
                        }
                    }
                    tr.Commit();
                }
                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Показать указанную категорию с текущего вида</summary>
        /// <param name="commandData"></param>
        /// <param name="cat">Категория</param>
        /// <param name="name">Имя категории, отображаемое в транзакции</param>
        public static Result ShowCategory(ExternalCommandData commandData, BuiltInCategory cat, string name)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;
                Category category = doc.Settings.Categories.get_Item(cat);
                if (category?.get_Visible(doc.ActiveView) == false)
                    using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Show") + " " + Language.GetItem(LangItem, name)))
                    {
                        tr.Start();
                        category.set_Visible(doc.ActiveView, true);
                        tr.Commit();
                    }
                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Показать указанную категорию с текущего вида</summary>
        /// <param name="commandData"></param>
        /// <param name="cats">Список категорий</param>
        /// <param name="name">Имя категории, отображаемое в транзакции</param>
        public static Result ShowCategory(ExternalCommandData commandData, List<BuiltInCategory> cats, string name)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (var cat in cats)
                    {
                        Category category = doc.Settings.Categories.get_Item(cat);
                        if (category?.get_Visible(doc.ActiveView) == false)
                            category.set_Visible(doc.ActiveView, true);
                    }
                    tr.Commit();
                }
                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Показать категории, название которых содержит указанное значение</summary>
        /// <param name="commandData"></param>
        /// <param name="name">Имя категории. Оно же должно содержаться в строковм представлении перечеслителя категории</param>
        public static Result ShowCategory(ExternalCommandData commandData, string name)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Show") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (BuiltInCategory cat in Enum.GetValues(typeof(BuiltInCategory)))
                    {
                        if (cat.ToString().Contains(name))
                        {
                            Category category = doc.Settings.Categories.get_Item(cat);
                            if (category?.get_Visible(doc.ActiveView) == false)
                            {
                                category.set_Visible(doc.ActiveView, true);
                            }
                        }
                    }

                    tr.Commit();
                }
                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Показать категории, название которых содержит указанное значение</summary>
        /// <param name="commandData"></param>
        /// <param name="name">Имя категории</param>
        /// <param name="contains">Значение, которое должно содержаться в строковм представлении перечеслителя категории</param>
        public static Result ShowCategory(ExternalCommandData commandData, string name, string contains)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Show") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (BuiltInCategory cat in Enum.GetValues(typeof(BuiltInCategory)))
                    {
                        if (cat.ToString().Contains(contains))
                        {
                            Category category = doc.Settings.Categories.get_Item(cat);
                            if (category?.get_Visible(doc.ActiveView) == false)
                            {
                                category.set_Visible(doc.ActiveView, true);
                            }
                        }
                    }

                    tr.Commit();
                }
                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }
    }
}
