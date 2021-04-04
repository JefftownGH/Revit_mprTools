namespace mprTools.Commands
{
    using System;
    using System.Linq;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using Autodesk.Revit.UI.Selection;
    using ModPlusAPI.Windows;

    /// <summary>
    /// Выбор аннотаций
    /// </summary>
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class PickAnnotationsCommand : IExternalCommand
    {
        /// <inheritdoc/>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
#if !DEBUG
            ModPlusAPI.Statistic.SendCommandStarting("mprPickAnnotations", new ModPlusConnector().AvailProductExternalVersion);
#endif
            try
            {
                var selection = commandData.Application.ActiveUIDocument.Selection;
                var ids = selection.PickElementsByRectangle(new AnnotationsFilter())
                    .Select(e => e.Id)
                    .ToList();

                if (ids.Any())
                {
                    selection.SetElementIds(ids);
                }

                return Result.Succeeded;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }
        
        /// <summary>
        /// Фильтр аннотаций
        /// </summary>
        internal class AnnotationsFilter : ISelectionFilter
        {
            /// <inheritdoc/>
            public bool AllowElement(Element elem)
            {
                return elem.Category != null &&
                       ((elem.Category.CategoryType == CategoryType.Annotation && elem.Category.Id.IntegerValue is int catId &&
                       (elem is FamilyInstance || IsTag(elem.Category) || IsDimension(elem.Category) || ((BuiltInCategory)catId).ToString().Contains("Text"))) ||
                       elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DetailComponents);
            }

            /// <inheritdoc/>
            public bool AllowReference(Reference reference, XYZ position)
            {
                throw new NotImplementedException();
            }

            private bool IsTag(Category category)
            {
                return ((BuiltInCategory)category.Id.IntegerValue).ToString().Contains("Tags");
            }

            private bool IsDimension(Category category)
            {
                return category.Id.IntegerValue == (int)BuiltInCategory.OST_Dimensions ||
                       ((BuiltInCategory)category.Id.IntegerValue).ToString().Contains("Spot");
            }
        }
    }
}
