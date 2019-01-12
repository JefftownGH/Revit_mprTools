using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using mprTools.Commands.CopingDistance;
using ModPlusAPI;
using ModPlusAPI.Windows;

namespace mprTools.Application
{
    public class ToolsApp : IExternalApplication
    {
        private const string LangItem = "mprTools";
        public static CopingDistanceUpdater CopingDistanceUpdater;

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                #region Coping Distance

                CopingDistanceUpdater = new CopingDistanceUpdater();

                // Значение оступа врезки из настроек. По умолчанию как в Ревите - 20 мм
                CopingDistanceCommand.DistanceInMm =
                    double.TryParse(UserConfigFile.GetValue(UserConfigFile.ConfigFileZone.Settings, "mprTools", "CopingDistanceValue"),
                        out var d)
                        ? d
                        : 20.0;

                // Статус апдейтера
                var updaterWorkFromStartUp =
                    bool.TryParse(UserConfigFile.GetValue(UserConfigFile.ConfigFileZone.Settings, "mprTools", "CopingDistanceUpdaterStatus"),
                        out var b) && b; // false

                if (updaterWorkFromStartUp)
                    CopingDistanceCommand.UpdaterOn(application.ActiveAddInId, ref CopingDistanceUpdater);
                else CopingDistanceCommand.UpdaterOff(application.ActiveAddInId, ref CopingDistanceUpdater);

                #endregion

                // create ribbon tab
                CreateRibbonTab(application);
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
            // У нас всегда все хорошо
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        private void CreateRibbonTab(UIControlledApplication application)
        {
            RibbonPanel panel = null;
            var rPanels = application.GetRibbonPanels("ModPlus");
            foreach (RibbonPanel rPanel in rPanels)
            {
                if (rPanel.Name.Equals(Language.TryGetCuiLocalGroupName("Утилиты")))
                {
                    panel = rPanel;
                    break;
                }
            }
            if (panel == null)
                panel = application.CreateRibbonPanel("ModPlus", Language.TryGetCuiLocalGroupName("Утилиты"));
            // interface of current modplus function
            var intF = new Interface();
            var assembly = Assembly.GetExecutingAssembly().Location;

            // grids mode
            var pbdGrids = new PushButtonData(
                "Grids mode",
                ConvertLName(Language.GetItem(LangItem, "h11")),
                Assembly.GetExecutingAssembly().Location,
                "mprTools.Commands.GridsMode.GridsModeCommand")
            {
                ToolTip = Language.GetItem(LangItem, "h12"),
                Image = new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/GridsMode_16x16.png"))
            };

            // Rebars outside host
            var pbdRebarsOutsideHost = new PushButtonData(
                "Rebars outside host",
                ConvertLName(Language.GetItem(LangItem, "h17")),
                Assembly.GetExecutingAssembly().Location,
                "mprTools.Commands.RebarsWithoutHost"
                )
            {
                ToolTip = Language.GetItem(LangItem, "h18"),
                Image = new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/RebarsWithoutHost_16x16.png"))
            };

            // CategoryOnOff
            var pulldownButtonDataOn = new PulldownButtonData("CategoryOn",
                Language.GetItem(LangItem, "Show"))
            {
                Image = new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/CategoryOnOff/CategoryOn_16x16.png")),
                ToolTip = Language.GetItem(LangItem, "ttShow")
            };
            var pulldownButtonDataOff = new PulldownButtonData("CategoryOff",
                Language.GetItem(LangItem, "Hide"))
            {
                Image = new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/CategoryOnOff/CategoryOff_16x16.png")),
                ToolTip = Language.GetItem(LangItem, "ttHide")
            };
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
                ConvertLName(Language.GetItem(LangItem, "h1")),
                assembly,
                "mprTools.Commands.CopingDistance.CopingDistanceCommand")
            {
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/mprTools_" +
                                                     intF.AvailProductExternalVersion +
                                                     ";component/Icons/CopingDistance_32x32.png")),
                ToolTip = Language.GetItem(LangItem, "h7")
            };

            // add to panel
            panel.AddItem(copingDistancePushButtonData);

        }
        private static string ConvertLName(string lName)
        {
            if (!lName.Contains(" ")) return lName;
            if (lName.Length <= 8) return lName;
            if (lName.Count(x => x == ' ') == 1)
            {
                return lName.Split(' ')[0] + Environment.NewLine + lName.Split(' ')[1];
            }
            var center = lName.Length * 0.5;
            var nearestDelta = lName.Select((c, i) => new { index = i, value = c }).Where(w => w.value == ' ')
                .OrderBy(x => Math.Abs(x.index - center)).First().index;
            return lName.Substring(0, nearestDelta) + Environment.NewLine + lName.Substring(nearestDelta + 1);
        }

        private static PushButtonData GetCategoryOnOffPushButtonData(string name, int onOff, Interface intF, string assembly)
        {
            if (onOff == 0) // on
            {
                // Большое изображение задавать обязательно, иначе не отображается малое
                var pbd = new PushButtonData(name, Language.GetItem(LangItem, name), assembly, $"mprTools.Commands.{name}Show")
                {
                    Image = GetIconForCategoryOnOff(name, onOff, intF),
                    LargeImage = GetIconForCategoryOnOff(name, onOff, intF)
                };
                return pbd;
            }
            else
            {
                var pbd = new PushButtonData(name, Language.GetItem(LangItem, name), assembly, $"mprTools.Commands.{name}Hide")
                {
                    Image = GetIconForCategoryOnOff(name, onOff, intF),
                    LargeImage = GetIconForCategoryOnOff(name, onOff, intF)
                };
                return pbd;
            }
        }

        private static BitmapImage GetIconForCategoryOnOff(string name, int onOff, Interface intF)
        {
            if (onOff == 0) // on
                return new BitmapImage(
                    new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                            ";component/Icons/CategoryOnOff/" + name + "On_16x16.png", UriKind.RelativeOrAbsolute));
            return new BitmapImage(
                new Uri("pack://application:,,,/mprTools_" + intF.AvailProductExternalVersion +
                        ";component/Icons/CategoryOnOff/" + name + "Off_16x16.png", UriKind.RelativeOrAbsolute));
        }
    }
}
