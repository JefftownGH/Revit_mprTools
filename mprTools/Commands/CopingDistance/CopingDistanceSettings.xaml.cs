namespace mprTools.Commands.CopingDistance
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using Autodesk.Revit.UI.Selection;
    using ModPlusAPI;
    using ModPlusAPI.Windows;
    using mprTools.Application;
    using mprTools.Application.SelectionFilters;

    public partial class CopingDistanceSettings
    {
        private const string LangItem = "mprTools";

        private readonly UIApplication _uiApplication;

        public CopingDistanceSettings(UIApplication uiApplication)
        {
            InitializeComponent();
            Title = ModPlusAPI.Language.GetItem(LangItem, "h1");
            _uiApplication = uiApplication;
            ChkUpdaterState.IsChecked =
                bool.TryParse(UserConfigFile.GetValue("mprTools", "CopingDistanceUpdaterStatus"), out var b) && b; // false
            CopingDistanceValue.Value =
                double.TryParse(UserConfigFile.GetValue("mprTools", "CopingDistanceValue"), out var d) ? d : 20.0;
        }

        private void CopingDistanceSettings_OnClosed(object sender, EventArgs e)
        {
            if (CopingDistanceValue.Value != null)
            {
                UserConfigFile.SetValue("mprTools", "CopingDistanceValue",
                    CopingDistanceValue.Value.Value.ToString(CultureInfo.InvariantCulture), true);
                CopingDistanceCommand.DistanceInMm = CopingDistanceValue.Value.Value;
            }
        }

        private void ChkUpdaterState_OnChecked(object sender, RoutedEventArgs e)
        {
            UserConfigFile.SetValue("mprTools", "CopingDistanceUpdaterStatus", true.ToString(), true);
            CopingDistanceCommand.UpdaterOn(_uiApplication.ActiveAddInId, ref ToolsApp.CopingDistanceUpdater);
        }

        private void ChkUpdaterState_OnUnchecked(object sender, RoutedEventArgs e)
        {
            UserConfigFile.SetValue("mprTools", "CopingDistanceUpdaterStatus", false.ToString(), true);
            CopingDistanceCommand.UpdaterOff(_uiApplication.ActiveAddInId, ref ToolsApp.CopingDistanceUpdater);
        }

        private void BtChangeForSelected_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CopingDistanceValue.Value.HasValue)
                {
                    Hide();
                    var distanceValue = CopingDistanceValue.Value;
                    var selection = _uiApplication.ActiveUIDocument.Selection;
                    var selResult = selection.PickObjects(ObjectType.Element, new StructuralFramingSelectionFilter(),
                        ModPlusAPI.Language.GetItem(LangItem, "h8") /*"Выберите балки"*/);
                    if (selResult.Any())
                    {
                        using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem(LangItem, "h9")))
                        {
                            tr.Start();
                            foreach (var reference in selResult)
                            {
                                var el = _uiApplication.ActiveUIDocument.Document.GetElement(reference);
                                var parameter = el.get_Parameter(BuiltInParameter.STRUCTURAL_COPING_DISTANCE);
                                parameter?.Set(UnitUtils.ConvertToInternalUnits(distanceValue.Value, DisplayUnitType.DUT_MILLIMETERS));
                            }
                            tr.Commit();
                        }
                    }
                }
                else
                {
                    ModPlusAPI.Windows.MessageBox.Show(
                        ModPlusAPI.Language.GetItem(LangItem, "h10"), //// "Введено некорректное значение!"
                        MessageBoxIcon.Alert);
                }
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
            }
            finally
            {
                ShowDialog();
            }
        }

        private void BtChangeOnView_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CopingDistanceValue.Value.HasValue)
                {
                    Hide();
                    var distanceValue = CopingDistanceValue.Value;
                    var doc = _uiApplication.ActiveUIDocument.Document;
                    var elements = new FilteredElementCollector(doc, doc.ActiveView.Id)
                        .OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsNotElementType().ToElements();
                    if (elements.Any())
                    {
                        using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem(LangItem, "h9")))
                        {
                            tr.Start();
                            foreach (var el in elements)
                            {
                                var parameter = el.get_Parameter(BuiltInParameter.STRUCTURAL_COPING_DISTANCE);
                                parameter?.Set(UnitUtils.ConvertToInternalUnits(distanceValue.Value, DisplayUnitType.DUT_MILLIMETERS));
                            }

                            tr.Commit();
                        }
                    }
                }
                else
                {
                    ModPlusAPI.Windows.MessageBox.Show(
                        ModPlusAPI.Language.GetItem(LangItem, "h10"), //// "Введено некорректное значение!"
                        MessageBoxIcon.Alert);
                }
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
            }
            finally
            {
                ShowDialog();
            }
        }
    }
}
