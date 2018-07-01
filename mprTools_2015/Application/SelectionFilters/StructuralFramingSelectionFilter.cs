using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace mprTools.Application.SelectionFilters
{
    public class StructuralFramingSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == (int) BuiltInCategory.OST_StructuralFraming)
                return true;
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
