namespace mprTools.Commands.GridsMode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using ModPlusAPI.Windows;

    public partial class GridsModeWindow
    {
        private readonly UIApplication _uiApplication;

        public GridsModeWindow(UIApplication uiApplication)
        {
            _uiApplication = uiApplication;
            InitializeComponent();
            Title = ModPlusAPI.Language.GetItem("h11");
        }

        private void BtSwitchTo2D_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var doc = _uiApplication.ActiveUIDocument.Document;
                var view = doc.ActiveView;
                var grids = GetGridsOnView();
                var gridsIn3D = grids.Where(g => g.GetDatumExtentTypeInView(DatumEnds.End0, view) == DatumExtentType.Model ||
                                                 g.GetDatumExtentTypeInView(DatumEnds.End1, view) == DatumExtentType.Model).ToList();
                if (gridsIn3D.Any())
                {
                    using (var tr = new Transaction(doc, ModPlusAPI.Language.GetItem("h13")))
                    {
                        tr.Start();
                        SwitchDatumExtentType(view, gridsIn3D, DatumExtentType.ViewSpecific);
                        tr.Commit();
                    }
                }
            });
        }

        private void BtSwitchTo3D_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var doc = _uiApplication.ActiveUIDocument.Document;
                var view = doc.ActiveView;
                var grids = GetGridsOnView();
                var gridsIn2D = grids.Where(g => g.GetDatumExtentTypeInView(DatumEnds.End0, view) == DatumExtentType.ViewSpecific ||
                                                 g.GetDatumExtentTypeInView(DatumEnds.End1, view) == DatumExtentType.ViewSpecific).ToList();
                if (gridsIn2D.Any())
                {
                    using (var tr = new Transaction(doc, ModPlusAPI.Language.GetItem("h14")))
                    {
                        tr.Start();
                        SwitchDatumExtentType(view, gridsIn2D, DatumExtentType.Model);
                        tr.Commit();
                    }
                }
            });
        }

        private void BtInvertGridsMode_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var doc = _uiApplication.ActiveUIDocument.Document;
                var view = doc.ActiveView;
                var grids = GetGridsOnView();
                if (grids.Any())
                {
                    var gridsIn2D = grids.Where(g => g.GetDatumExtentTypeInView(DatumEnds.End0, view) == DatumExtentType.ViewSpecific ||
                                                     g.GetDatumExtentTypeInView(DatumEnds.End1, view) == DatumExtentType.ViewSpecific).ToList();
                    var gridsIn3D = grids.Where(g => g.GetDatumExtentTypeInView(DatumEnds.End0, view) == DatumExtentType.Model ||
                                                     g.GetDatumExtentTypeInView(DatumEnds.End1, view) == DatumExtentType.Model).ToList();
                    using (var tr = new Transaction(doc, ModPlusAPI.Language.GetItem("h15")))
                    {
                        tr.Start();
                        SwitchDatumExtentType(view, gridsIn2D, DatumExtentType.Model);
                        SwitchDatumExtentType(view, gridsIn3D, DatumExtentType.ViewSpecific);
                        tr.Commit();
                    }
                }
            });
        }

        private void ProcessAndClose(Action action)
        {
            try
            {
                Hide();
                action.Invoke();
                Close();
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                ShowDialog();
            }
        }

        private static void SwitchDatumExtentType(View view, IEnumerable<Grid> grids, DatumExtentType datumExtentType)
        {
            foreach (var grid in grids)
            {
                grid.SetDatumExtentType(DatumEnds.End0, view, datumExtentType);
                grid.SetDatumExtentType(DatumEnds.End1, view, datumExtentType);
            }
        }

        private IList<Grid> GetGridsOnView()
        {
            return new FilteredElementCollector(
                    _uiApplication.ActiveUIDocument.Document,
                    _uiApplication.ActiveUIDocument.ActiveGraphicalView.Id)
                .OfCategory(BuiltInCategory.OST_Grids)
                .OfClass(typeof(Grid))
                .WhereElementIsNotElementType()
                .Cast<Grid>()
                .ToList();
        }
    }
}