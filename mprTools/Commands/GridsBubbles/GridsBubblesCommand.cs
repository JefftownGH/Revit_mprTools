namespace mprTools.Commands.GridsBubbles
{
    using System;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using ModPlusAPI.Windows;

    /// <summary>
    /// Команда "Видимость кружков"
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GridsBubblesCommand : IExternalCommand
    {
        /// <inheritdoc/>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
#if !DEBUG
                ModPlusAPI.Statistic.SendCommandStarting("mprGridsBubbles", new ModPlusConnector().AvailProductExternalVersion);
#endif
                var gridsModeWindow = new GridsBubblesWindow(commandData.Application);
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
