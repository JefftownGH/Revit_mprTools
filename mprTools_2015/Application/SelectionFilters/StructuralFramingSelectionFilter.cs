namespace mprTools.Application.SelectionFilters
{
    using System;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI.Selection;

    public class StructuralFramingSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
