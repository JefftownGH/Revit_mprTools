using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ModPlusAPI.Windows;

namespace mprTools.Commands.GridsMode
{
    public partial class GridsModeWindow
    {
        private readonly UIApplication _uiApplication;
        private const string LangItem = "mprTools";

        public GridsModeWindow(UIApplication uiApplication)
        {
            _uiApplication = uiApplication;
            InitializeComponent();
            Title = ModPlusAPI.Language.GetItem(LangItem, "h11");
        }

        private void BtSwitchTo2D_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Hide();
                var doc = _uiApplication.ActiveUIDocument.Document;
                var view = doc.ActiveView;
                var grids = new FilteredElementCollector(doc, doc.ActiveView.Id)
                    .OfCategory(BuiltInCategory.OST_Grids)
                    .WhereElementIsNotElementType().ToElements();
                var gridsIn3D = grids.Where(g => ((Grid)g).GetDatumExtentTypeInView(DatumEnds.End0, view) == DatumExtentType.Model ||
                                                 ((Grid)g).GetDatumExtentTypeInView(DatumEnds.End1, view) == DatumExtentType.Model).ToList();
                if (gridsIn3D.Any())
                {
                    using (var tr = new Transaction(doc, ModPlusAPI.Language.GetItem(LangItem, "h13")))
                    {
                        tr.Start();
                        SwitchDatumExtentType(view, gridsIn3D, DatumExtentType.ViewSpecific);
                        tr.Commit();
                    }
                }
                Close();
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                ShowDialog();
            }
        }

        private void BtSwitchTo3D_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Hide();
                var doc = _uiApplication.ActiveUIDocument.Document;
                var view = doc.ActiveView;
                var grids = new FilteredElementCollector(doc, doc.ActiveView.Id)
                    .OfCategory(BuiltInCategory.OST_Grids)
                    .WhereElementIsNotElementType().ToElements();
                var gridsIn2D = grids.Where(g => ((Grid)g).GetDatumExtentTypeInView(DatumEnds.End0, view) == DatumExtentType.ViewSpecific ||
                                                 ((Grid)g).GetDatumExtentTypeInView(DatumEnds.End1, view) == DatumExtentType.ViewSpecific).ToList();
                if (gridsIn2D.Any())
                {
                    using (var tr = new Transaction(doc, ModPlusAPI.Language.GetItem(LangItem, "h14")))
                    {
                        tr.Start();
                        SwitchDatumExtentType(view, gridsIn2D, DatumExtentType.Model);
                        tr.Commit();
                    }
                }
                Close();
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                ShowDialog();
            }
        }

        private void BtInvertGridsMode_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Hide();
                var doc = _uiApplication.ActiveUIDocument.Document;
                var view = doc.ActiveView;
                var grids = new FilteredElementCollector(doc, doc.ActiveView.Id)
                    .OfCategory(BuiltInCategory.OST_Grids)
                    .WhereElementIsNotElementType().ToElements();
                if (grids.Any())
                {
                    var gridsIn2D = grids.Where(g => ((Grid)g).GetDatumExtentTypeInView(DatumEnds.End0, view) == DatumExtentType.ViewSpecific ||
                                                     ((Grid)g).GetDatumExtentTypeInView(DatumEnds.End1, view) == DatumExtentType.ViewSpecific).ToList();
                    var gridsIn3D = grids.Where(g => ((Grid)g).GetDatumExtentTypeInView(DatumEnds.End0, view) == DatumExtentType.Model ||
                                                     ((Grid)g).GetDatumExtentTypeInView(DatumEnds.End1, view) == DatumExtentType.Model).ToList();
                    using (var tr = new Transaction(doc, ModPlusAPI.Language.GetItem(LangItem, "h15")))
                    {
                        tr.Start();
                        SwitchDatumExtentType(view, gridsIn2D, DatumExtentType.Model);
                        SwitchDatumExtentType(view, gridsIn3D, DatumExtentType.ViewSpecific);
                        tr.Commit();
                    }
                }
                Close();
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                ShowDialog();
            }
        }

        private static void SwitchDatumExtentType(View view, IList<Element> grids, DatumExtentType datumExtentType)
        {
            foreach (var element in grids)
            {
                var grid = (Grid)element;
                grid.SetDatumExtentType(DatumEnds.End0, view, datumExtentType);
                grid.SetDatumExtentType(DatumEnds.End1, view, datumExtentType);
            }
        }
    }
}
