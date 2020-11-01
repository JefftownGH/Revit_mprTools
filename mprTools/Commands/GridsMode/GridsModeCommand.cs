namespace mprTools.Commands.GridsMode
{
    using System;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using ModPlusAPI.Windows;

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GridsModeCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
#if !DEBUG
                ModPlusAPI.Statistic.SendCommandStarting("mprGridsMode", new ModPlusConnector().AvailProductExternalVersion);
#endif
                var gridsModeWindow = new GridsModeWindow(commandData.Application);
                gridsModeWindow.ShowDialog();

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }
    }
}