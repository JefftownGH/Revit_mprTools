using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ModPlusAPI;
using ModPlusAPI.Windows;

namespace mprTools.Commands.GridsMode
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GridsModeCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Statistic.SendCommandStarting("mprGridsMode", new Interface().AvailProductExternalVersion);
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
