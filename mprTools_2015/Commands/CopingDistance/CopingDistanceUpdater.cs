using System;
using Autodesk.Revit.DB;
using ModPlusAPI.Windows;

namespace mprTools.Commands.CopingDistance
{
    public class CopingDistanceUpdater : IUpdater
    {
        private static UpdaterId _updaterId;

        public CopingDistanceUpdater()
        {
            _updaterId = new UpdaterId(new AddInId(new Interface().AddInId), new Guid("a0d36406-d2fd-4cbe-902b-da1929a0aec0") );
        }

        public void Execute(UpdaterData data)
        {
            Document doc = data.GetDocument();
            // ReSharper disable once UseNullPropagation
            if(doc == null) return;
            if(doc.ActiveView == null) return;
            if(doc.IsFamilyDocument) return;
            foreach (ElementId elementId in data.GetModifiedElementIds())
            {
                if (doc.GetElement(elementId) is FamilyInstance familyInstance &&
                    familyInstance.Category.Id.IntegerValue == (int) BuiltInCategory.OST_StructuralFraming)
                {
                    try
                    {
                        var parameter = familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_COPING_DISTANCE);
                        parameter?.Set(UnitUtils.ConvertToInternalUnits(CopingDistanceCommand.DistanceInMm, DisplayUnitType.DUT_MILLIMETERS));
                    }
                    catch (Exception exception)
                    {
                        ExceptionBox.Show(exception);
                    }
                }
            }
        }

        public UpdaterId GetUpdaterId()
        {
            return _updaterId;
        }

        public ChangePriority GetChangePriority()
        {
            return ChangePriority.Structure;
        }

        public string GetUpdaterName()
        {
            return "CopingDistanceUpdater";
        }

        public string GetAdditionalInformation()
        {
            return "modplus.org";
        }
    }
}
