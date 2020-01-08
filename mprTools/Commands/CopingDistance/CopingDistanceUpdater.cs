namespace mprTools.Commands.CopingDistance
{
    using System;
    using Autodesk.Revit.DB;
    using ModPlusAPI.Windows;

    public class CopingDistanceUpdater : IUpdater
    {
        private static UpdaterId _updaterId;

        public CopingDistanceUpdater()
        {
            _updaterId = new UpdaterId(new AddInId(new ModPlusConnector().AddInId), new Guid("a0d36406-d2fd-4cbe-902b-da1929a0aec0"));
        }

        /// <inheritdoc />
        public void Execute(UpdaterData data)
        {
            var doc = data.GetDocument();

            // ReSharper disable once UseNullPropagation
            if (doc == null)
                return;
            if (doc.ActiveView == null)
                return;
            if (doc.IsFamilyDocument) 
                return;
            foreach (var elementId in data.GetModifiedElementIds())
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

        /// <inheritdoc />
        public UpdaterId GetUpdaterId()
        {
            return _updaterId;
        }

        /// <inheritdoc />
        public ChangePriority GetChangePriority()
        {
            return ChangePriority.Structure;
        }

        /// <inheritdoc />
        public string GetUpdaterName()
        {
            return "CopingDistanceUpdater";
        }

        /// <inheritdoc />
        public string GetAdditionalInformation()
        {
            return "modplus.org";
        }
    }
}
