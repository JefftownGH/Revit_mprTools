namespace mprTools.Application
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Media.Imaging;
    using Autodesk.Revit.UI;
    using Commands.CopingDistance;
    using ModPlusAPI;
    using ModPlusAPI.Windows;

    public class ToolsApp : IExternalApplication
    {
        private const string LangItem = "mprTools";

        public static CopingDistanceUpdater CopingDistanceUpdater;

        /// <inheritdoc />
        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                #region Coping Distance

                CopingDistanceUpdater = new CopingDistanceUpdater();

                // Значение отступа врезки из настроек. По умолчанию как в Ревите - 20 мм
                CopingDistanceCommand.DistanceInMm =
                    double.TryParse(UserConfigFile.GetValue("mprTools", "CopingDistanceValue"), out var d) ? d : 20.0;

                // Статус апдейтера
                var updaterWorkFromStartUp =
                    bool.TryParse(UserConfigFile.GetValue("mprTools", "CopingDistanceUpdaterStatus"), out var b) && b; // false

                if (updaterWorkFromStartUp)
                    CopingDistanceCommand.UpdaterOn(application.ActiveAddInId, ref CopingDistanceUpdater);
                else
                    CopingDistanceCommand.UpdaterOff(application.ActiveAddInId, ref CopingDistanceUpdater);

                #endregion

                // create ribbon tab
                CreateRibbonTab(application);

                ModPlus_Revit.App.RibbonBuilder.HideTextOfSmallButtons("ModPlus", new List<string> { "Grids mode", "Rebars outside host" });
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }

            // У нас всегда все хорошо
            return Result.Succeeded;
        }

        /// <inheritdoc />
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        private void CreateRibbonTab(UIControlledApplication application)
        {
            RibbonPanel panel = null;
            const string tabName = "ModPlus";
            ModPlus_Revit.App.RibbonBuilder.CreateModPlusTabIfNoExist(application);
            var rPanels = application.GetRibbonPanels(tabName);
            foreach (RibbonPanel rPanel in rPanels)
            {
                if (rPanel.Name.Equals(Language.TryGetCuiLocalGroupName("Утилиты")))
                {
                    panel = rPanel;
                    break;
                }
            }

            if (panel == null)
                panel = application.CreateRibbonPanel(tabName, Language.TryGetCuiLocalGroupName("Утилиты"));

            // interface of current ModPlus function
            var intF = new ModPlusConnector();
            var assembly = Assembly.GetExecutingAssembly().Location;
            var contextualHelp = new ContextualHelp(ContextualHelpType.Url, ModPlus_Revit.App.RibbonBuilder.GetHelpUrl(intF.Name));

            // grids mode
            var pbdGrids = new PushButtonData(
                "Grids mode",
                ModPlus_Revit.App.RibbonBuilder.ConvertLName(Language.GetItem(LangItem, "h11")),
                Assembly.GetExecutingAssembly().Location,
                "mprTools.Commands.GridsMode.GridsModeCommand")
            {
                ToolTip = Language.GetItem(LangItem, "h12"),
                Image = new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/GridsMode_16x16.png"))
            };

            pbdGrids.SetContextualHelp(contextualHelp);

            // Rebars outside host
            var pbdRebarsOutsideHost = new PushButtonData(
                "Rebars outside host",
                ModPlus_Revit.App.RibbonBuilder.ConvertLName(Language.GetItem(LangItem, "h17")),
                Assembly.GetExecutingAssembly().Location,
                "mprTools.Commands.RebarsWithoutHost")
            {
                ToolTip = Language.GetItem(LangItem, "h18"),
                Image = new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/RebarsWithoutHost_16x16.png"))
            };
            pbdRebarsOutsideHost.SetContextualHelp(contextualHelp);

            // CategoryOnOff
            var pulldownButtonDataOn = new PulldownButtonData("CategoryOn", Language.GetItem(LangItem, "Show"))
            {
                Image = new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/CategoryOnOff/CategoryOn_16x16.png")),
                ToolTip = Language.GetItem(LangItem, "ttShow")
            };
            pulldownButtonDataOn.SetContextualHelp(contextualHelp);
            var pulldownButtonDataOff = new PulldownButtonData("CategoryOff", Language.GetItem(LangItem, "Hide"))
            {
                Image = new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/CategoryOnOff/CategoryOff_16x16.png")),
                ToolTip = Language.GetItem(LangItem, "ttHide")
            };
            pulldownButtonDataOff.SetContextualHelp(contextualHelp);

            // create stacked panel
#if R2015
            var stackedItems = panel.AddStackedItems(pbdRebarsOutsideHost, pulldownButtonDataOn, pulldownButtonDataOff);
            const int onIndex = 1;
            const int offIndex = 2;
#else
            var stackedItems = panel.AddStackedItems(pulldownButtonDataOn, pulldownButtonDataOff);
            const int onIndex = 0;
            const int offIndex = 1;

            panel.AddStackedItems(pbdGrids, pbdRebarsOutsideHost);
#endif

            // add items to pulldata button
            var commands = new List<string>
                {
                    "Windows", "Doors", "Walls", "Columns", "StructuralFraming", "Components", "Separator",
                    "Roofs", "Floors", "Ceilings", "Separator",
                    "Stairs", "StairsRailing", "Ramps", "Separator",
                    "Grids", "Levels", "Sections", "Elevations", "Tags", "ReferencePlanes"
                };
            if (stackedItems[onIndex] is PulldownButton pdbOn)
            {
                commands.ForEach(c =>
                {
                    if (c.Equals("Separator"))
                        pdbOn.AddSeparator();
                    else
                        pdbOn.AddPushButton(GetCategoryOnOffPushButtonData(c, 0, intF, assembly));
                });
            }

            if (stackedItems[offIndex] is PulldownButton pdbOff)
            {
                commands.ForEach(c =>
                {
                    if (c.Equals("Separator"))
                        pdbOff.AddSeparator();
                    else
                        pdbOff.AddPushButton(GetCategoryOnOffPushButtonData(c, 1, intF, assembly));
                });
            }

            // Coping distance
            var copingDistancePushButtonData = new PushButtonData(
                "Coping Distance",
                ModPlus_Revit.App.RibbonBuilder.ConvertLName(Language.GetItem(LangItem, "h1")),
                assembly,
                "mprTools.Commands.CopingDistance.CopingDistanceCommand")
            {
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/mprTools_" +
                                                     intF.AvailProductExternalVersion +
                                                     ";component/Icons/CopingDistance_32x32.png")),
                ToolTip = Language.GetItem(LangItem, "h7")
            };
            copingDistancePushButtonData.SetContextualHelp(contextualHelp);

            // add to panel
            panel.AddItem(copingDistancePushButtonData);
        }

        private static PushButtonData GetCategoryOnOffPushButtonData(string name, int onOff, ModPlusConnector intF, string assembly)
        {
            if (onOff == 0) //// on
            {
                // Большое изображение задавать обязательно, иначе не отображается малое
                var pbd = new PushButtonData(name, Language.GetItem(LangItem, name), assembly, $"mprTools.Commands.{name}Show")
                {
                    Image = GetIconForCategoryOnOff(name, onOff, intF),
                    LargeImage = GetIconForCategoryOnOff(name, onOff, intF)
                };
                pbd.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, ModPlus_Revit.App.RibbonBuilder.GetHelpUrl(intF.Name)));
                return pbd;
            }
            else
            {
                var pbd = new PushButtonData(name, Language.GetItem(LangItem, name), assembly, $"mprTools.Commands.{name}Hide")
                {
                    Image = GetIconForCategoryOnOff(name, onOff, intF),
                    LargeImage = GetIconForCategoryOnOff(name, onOff, intF)
                };
                pbd.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, ModPlus_Revit.App.RibbonBuilder.GetHelpUrl(intF.Name)));
                return pbd;
            }
        }

        private static BitmapImage GetIconForCategoryOnOff(string name, int onOff, ModPlusConnector intF)
        {
            if (onOff == 0) //// on
            {
                return new BitmapImage(
                    new Uri(
                        "pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                        ";component/Icons/CategoryOnOff/" + name + "On_16x16.png", UriKind.RelativeOrAbsolute));
            }

            return new BitmapImage(
                new Uri(
                    "pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                    ";component/Icons/CategoryOnOff/" + name + "Off_16x16.png", UriKind.RelativeOrAbsolute));
        }
    }
}
