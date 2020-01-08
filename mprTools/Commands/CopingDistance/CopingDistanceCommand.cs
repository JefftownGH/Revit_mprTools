namespace mprTools.Commands.CopingDistance
{
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using ModPlusAPI;

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class CopingDistanceCommand : IExternalCommand
    {
        public static double DistanceInMm;

        /// <inheritdoc />
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCopingDistance", new ModPlusConnector().AvailProductExternalVersion);
            var window = new CopingDistanceSettings(commandData.Application);
            window.ShowDialog();
            return Result.Succeeded;
        }

        public static void UpdaterOn(AddInId activeAddInId, ref CopingDistanceUpdater updater)
        {
            if (!UpdaterRegistry.IsUpdaterRegistered(updater.GetUpdaterId()))
            {
                UpdaterRegistry.RegisterUpdater(updater, true);
                ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);
                UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), filter, Element.GetChangeTypeGeometry());
            }
        }

        public static void UpdaterOff(AddInId activeAddInId, ref CopingDistanceUpdater updater)
        {
            if (UpdaterRegistry.IsUpdaterRegistered(updater.GetUpdaterId()))
            {
                UpdaterRegistry.UnregisterUpdater(updater.GetUpdaterId());
            }
        }
    }
}
