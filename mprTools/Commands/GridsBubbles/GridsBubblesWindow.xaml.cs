namespace mprTools.Commands.GridsBubbles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using Autodesk.Revit.UI.Selection;
    using ModPlusAPI.Windows;

    /// <summary>
    /// Логика взаимодействия для GridsBubblesWindow.xaml
    /// </summary>
    public partial class GridsBubblesWindow
    {
        private readonly UIApplication _uiApplication;

        public GridsBubblesWindow(UIApplication uiApplication)
        {
            _uiApplication = uiApplication;
            InitializeComponent();
            Title = ModPlusAPI.Language.GetItem("h19");
        }

        private void BtShowBubblesStartOfSelected_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = PickGrids();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h21")))
                    {
                        tr.Start();

                        ShowBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids,
                            DatumEnds.End0);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtShowBubblesStartOnView_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = GetGridsOnView();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h21")))
                    {
                        tr.Start();

                        ShowBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids,
                            DatumEnds.End0);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtShowBubblesEndOfSelected_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = PickGrids();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h22")))
                    {
                        tr.Start();

                        ShowBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids,
                            DatumEnds.End1);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtShowBubblesEndOnView_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = GetGridsOnView();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h22")))
                    {
                        tr.Start();

                        ShowBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids,
                            DatumEnds.End1);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtHideBubblesStartOfSelected_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = PickGrids();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h23")))
                    {
                        tr.Start();

                        HideBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids,
                            DatumEnds.End0);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtHideBubblesStartOnView_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = GetGridsOnView();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h23")))
                    {
                        tr.Start();

                        HideBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids,
                            DatumEnds.End0);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtHideBubblesEndOfSelected_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = PickGrids();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h24")))
                    {
                        tr.Start();

                        HideBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids,
                            DatumEnds.End1);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtHideBubblesEndOnView_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = GetGridsOnView();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h24")))
                    {
                        tr.Start();

                        HideBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids,
                            DatumEnds.End1);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtInverseBubblesOfSelected_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = PickGrids();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h25")))
                    {
                        tr.Start();

                        InvertBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids);

                        tr.Commit();
                    }
                }
            });
        }

        private void BtInverseBubblesOnView_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessAndClose(() =>
            {
                var grids = GetGridsOnView();
                if (grids.Any())
                {
                    using (var tr = new Transaction(_uiApplication.ActiveUIDocument.Document, ModPlusAPI.Language.GetItem("h25")))
                    {
                        tr.Start();

                        InvertBubbles(
                            _uiApplication.ActiveUIDocument.ActiveGraphicalView,
                            grids);

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

        private static void ShowBubbles(View view, IEnumerable<Grid> grids, DatumEnds ends)
        {
            foreach (var grid in grids)
            {
                if (grid.HasBubbleInView(ends, view))
                    grid.ShowBubbleInView(ends, view);
            }
        }

        private static void HideBubbles(View view, IEnumerable<Grid> grids, DatumEnds ends)
        {
            foreach (var grid in grids)
            {
                if (grid.HasBubbleInView(ends, view))
                    grid.HideBubbleInView(ends, view);
            }
        }

        private static void InvertBubbles(View view, IEnumerable<Grid> grids)
        {
            foreach (var grid in grids)
            {
                foreach (var ends in new[] { DatumEnds.End0, DatumEnds.End1 })
                {
                    if (grid.HasBubbleInView(ends, view))
                    {
                        if (grid.IsBubbleVisibleInView(ends, view))
                            grid.HideBubbleInView(ends, view);
                        else
                            grid.ShowBubbleInView(ends, view);
                    }
                }
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

        private IList<Grid> PickGrids()
        {
            var selection = _uiApplication.ActiveUIDocument.Selection;

            try
            {
                return selection.PickElementsByRectangle(
                    new GridsSelectionFilter(), ModPlusAPI.Language.GetItem("h28"))
                    .Cast<Grid>()
                    .ToList();
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return new List<Grid>();
            }
        }

        /// <summary>
        /// Grids selection filter
        /// </summary>
        internal class GridsSelectionFilter : ISelectionFilter
        {
            /// <inheritdoc/>
            public bool AllowElement(Element elem)
            {
                return elem is Grid;
            }

            /// <inheritdoc/>
            public bool AllowReference(Reference reference, XYZ position)
            {
                throw new NotImplementedException();
            }
        }
    }
}
