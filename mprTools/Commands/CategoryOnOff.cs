#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1600 // Elements should be documented
//// ReSharper disable UnusedMember.Global
namespace mprTools.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using ModPlusAPI;
    using ModPlusAPI.Windows;

    #region Show

    [Transaction(TransactionMode.Manual)]
    public class WallsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Walls, "Walls", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class WindowsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Windows, "Windows", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class DoorsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Doors, "Doors", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class TagsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, "Tags", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class FloorsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Floors, "Floors", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ColumnsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, "Columns", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class GridsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Grids, "Grids", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LevelsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Levels, "Levels", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class RampsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Ramps, "Ramps", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class StairsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Stairs, "Stairs", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class StairsRailingShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData,
                new List<BuiltInCategory> { BuiltInCategory.OST_Railings, BuiltInCategory.OST_StairsRailing },
                "StairsRailing", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class RoofsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Roofs, "Roofs", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class CeilingsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Ceilings, "Ceilings", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ElevationsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Elev, "Elevations", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class SectionsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, BuiltInCategory.OST_Sections, "Sections", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ComponentsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, new List<BuiltInCategory>
            {
                BuiltInCategory.OST_DetailComponents,
                BuiltInCategory.OST_Furniture,
                BuiltInCategory.OST_FurnitureSystems,
                BuiltInCategory.OST_Casework,
                BuiltInCategory.OST_Entourage,
                BuiltInCategory.OST_Site,
                BuiltInCategory.OST_Parking,
                BuiltInCategory.OST_Planting
            }, "Components", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ReferencePlanesShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_CLines, "ReferencePlane", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class StructuralFramingShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_StructuralFraming, "StructuralFraming", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class StructuralFoundationShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_StructuralFoundation, "StructuralFoundation", ViewGraphicsOverrideType.Model);
        }
    }

    #region Analytical

    [Transaction(TransactionMode.Manual)]
    public class BeamAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_BeamAnalytical, "BeamAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class BraceAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_BraceAnalytical, "BraceAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ColumnAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_ColumnAnalytical, "ColumnAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class FloorAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_FloorAnalytical, "FloorAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class FoundationSlabAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_FoundationSlabAnalytical, "FoundationSlabAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class IsolatedFoundationAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_IsolatedFoundationAnalytical, "IsolatedFoundationAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LinksAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_LinksAnalytical, "LinksAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class AnalyticalNodesShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_AnalyticalNodes, "AnalyticalNodes", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class WallFoundationAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_WallFoundationAnalytical, "WallFoundationAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class WallAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_WallAnalytical, "WallAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class BoundaryConditionsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_BoundaryConditions, "BoundaryConditions", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class InternalLoadsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_InternalLoads, "InternalLoads", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LoadCasesShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_LoadCases, "LoadCases", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LoadsShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(
                commandData, BuiltInCategory.OST_Loads, "Loads", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class AllAnalyticalShow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.ShowCategory(commandData, new List<BuiltInCategory>
            {
                BuiltInCategory.OST_BeamAnalytical,
                BuiltInCategory.OST_BraceAnalytical,
                BuiltInCategory.OST_ColumnAnalytical,
                BuiltInCategory.OST_FloorAnalytical,
                BuiltInCategory.OST_FoundationSlabAnalytical,
                BuiltInCategory.OST_IsolatedFoundationAnalytical,
                BuiltInCategory.OST_LinksAnalytical,
                BuiltInCategory.OST_AnalyticalNodes,
                BuiltInCategory.OST_WallFoundationAnalytical,
                BuiltInCategory.OST_WallAnalytical,
                BuiltInCategory.OST_BoundaryConditions,
                BuiltInCategory.OST_InternalLoads,
                BuiltInCategory.OST_LoadCases,
                BuiltInCategory.OST_Loads
            }, "AllAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    #endregion

    #endregion

    #region Hide

    [Transaction(TransactionMode.Manual)]
    public class WallsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Walls, "Walls", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class WindowsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Windows, "Windows", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class DoorsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Doors, "Doors", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class TagsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, "Tags", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class FloorsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Floors, "Floors", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ColumnsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, "Columns", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class GridsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Grids, "Grids", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LevelsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Levels, "Levels", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class RampsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Ramps, "Ramps", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class StairsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Stairs, "Stairs", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class StairsRailingHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData,
                new List<BuiltInCategory> { BuiltInCategory.OST_Railings, BuiltInCategory.OST_StairsRailing },
                "StairsRailing", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class RoofsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Roofs, "Roofs", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class CeilingsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Ceilings, "Ceilings", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ElevationsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Elev, "Elevations", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class SectionsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_Sections, "Sections", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ComponentsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, new List<BuiltInCategory>
            {
                BuiltInCategory.OST_DetailComponents,
                BuiltInCategory.OST_Furniture,
                BuiltInCategory.OST_FurnitureSystems,
                BuiltInCategory.OST_Casework,
                BuiltInCategory.OST_Entourage,
                BuiltInCategory.OST_Site,
                BuiltInCategory.OST_Parking,
                BuiltInCategory.OST_Planting
            }, "Components", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ReferencePlanesHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, BuiltInCategory.OST_CLines, "ReferencePlane", ViewGraphicsOverrideType.Annotation);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class StructuralFramingHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_StructuralFraming, "StructuralFraming", ViewGraphicsOverrideType.Model);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class StructuralFoundationHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_StructuralFoundation, "StructuralFoundation", ViewGraphicsOverrideType.Model);
        }
    }

    #region Analytical

    [Transaction(TransactionMode.Manual)]
    public class BeamAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_BeamAnalytical, "BeamAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class BraceAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_BraceAnalytical, "BraceAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ColumnAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_ColumnAnalytical, "ColumnAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class FloorAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_FloorAnalytical, "FloorAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class FoundationSlabAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_FoundationSlabAnalytical, "FoundationSlabAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class IsolatedFoundationAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_IsolatedFoundationAnalytical, "IsolatedFoundationAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LinksAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_LinksAnalytical, "LinksAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class AnalyticalNodesHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_AnalyticalNodes, "AnalyticalNodes", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class WallFoundationAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_WallFoundationAnalytical, "WallFoundationAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class WallAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_WallAnalytical, "WallAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class BoundaryConditionsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_BoundaryConditions, "BoundaryConditions", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class InternalLoadsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_InternalLoads, "InternalLoads", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LoadCasesHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_LoadCases, "LoadCases", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LoadsHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(
                commandData, BuiltInCategory.OST_Loads, "Loads", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class AllAnalyticalHide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting("mprCategoryOnOff", new ModPlusConnector().AvailProductExternalVersion);
            return ShowHideHelper.HideCategory(commandData, new List<BuiltInCategory>
            {
                BuiltInCategory.OST_BeamAnalytical,
                BuiltInCategory.OST_BraceAnalytical,
                BuiltInCategory.OST_ColumnAnalytical,
                BuiltInCategory.OST_FloorAnalytical,
                BuiltInCategory.OST_FoundationSlabAnalytical,
                BuiltInCategory.OST_IsolatedFoundationAnalytical,
                BuiltInCategory.OST_LinksAnalytical,
                BuiltInCategory.OST_AnalyticalNodes,
                BuiltInCategory.OST_WallFoundationAnalytical,
                BuiltInCategory.OST_WallAnalytical,
                BuiltInCategory.OST_BoundaryConditions,
                BuiltInCategory.OST_InternalLoads,
                BuiltInCategory.OST_LoadCases,
                BuiltInCategory.OST_Loads
            }, "AllAnalytical", ViewGraphicsOverrideType.AnalyticalModel);
        }
    }

    #endregion

    #endregion

    public static class ShowHideHelper
    {
        private const string LangItem = "mprTools";

        /// <summary>Скрыть указанную категорию с текущего вида</summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="cat">Категория</param>
        /// <param name="name">Имя категории, отображаемое в транзакции</param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        public static Result HideCategory(
            ExternalCommandData commandData, BuiltInCategory cat, string name, ViewGraphicsOverrideType graphicsOverrideType)
        {
            try
            {
                if (BlockedByCurrentViewTemplate(commandData, graphicsOverrideType))
                    return Result.Cancelled;
                var doc = commandData.Application.ActiveUIDocument.Document;
                Category category = doc.Settings.Categories.get_Item(cat);
                if (category?.get_Visible(doc.ActiveView) == true)
                {
                    using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                    {
                        tr.Start();
                        category.set_Visible(doc.ActiveView, false);
                        tr.Commit();
                    }
                }

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Скрыть указанную категорию с текущего вида</summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="cats">Список категорий</param>
        /// <param name="name">Имя категории, отображаемое в транзакции</param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        public static Result HideCategory(
            ExternalCommandData commandData, List<BuiltInCategory> cats, string name, ViewGraphicsOverrideType graphicsOverrideType)
        {
            try
            {
                if (BlockedByCurrentViewTemplate(commandData, graphicsOverrideType))
                    return Result.Cancelled;
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (var cat in cats)
                    {
                        Category category = doc.Settings.Categories.get_Item(cat);
                        if (category?.get_Visible(doc.ActiveView) == true)
                            category.set_Visible(doc.ActiveView, false);
                    }

                    tr.Commit();
                }

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Скрыть категории, название которых содержит указанное значение</summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="name">Имя категории. Оно же должно содержаться в строковом представлении перечеслителя категории</param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        public static Result HideCategory(
            ExternalCommandData commandData, string name, ViewGraphicsOverrideType graphicsOverrideType)
        {
            try
            {
                if (BlockedByCurrentViewTemplate(commandData, graphicsOverrideType))
                    return Result.Cancelled;
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (BuiltInCategory cat in Enum.GetValues(typeof(BuiltInCategory)))
                    {
                        if (cat.ToString().Contains(name))
                        {
                            Category category = doc.Settings.Categories.get_Item(cat);
                            if (category?.get_Visible(doc.ActiveView) == true)
                            {
                                category.set_Visible(doc.ActiveView, false);
                            }
                        }
                    }

                    tr.Commit();
                }

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Скрыть категории, название которых содержит указанное значение</summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="name">Имя категории</param>
        /// <param name="contains">Значение, которое должно содержаться в строковом представлении перечеслителя категории</param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        public static Result HideCategory(
            ExternalCommandData commandData, string name, string contains, ViewGraphicsOverrideType graphicsOverrideType)
        {
            try
            {
                if (BlockedByCurrentViewTemplate(commandData, graphicsOverrideType))
                    return Result.Cancelled;
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (BuiltInCategory cat in Enum.GetValues(typeof(BuiltInCategory)))
                    {
                        if (cat.ToString().Contains(contains))
                        {
                            Category category = doc.Settings.Categories.get_Item(cat);
                            if (category?.get_Visible(doc.ActiveView) == true)
                            {
                                category.set_Visible(doc.ActiveView, false);
                            }
                        }
                    }

                    tr.Commit();
                }

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Показать указанную категорию с текущего вида</summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="cat">Категория</param>
        /// <param name="name">Имя категории, отображаемое в транзакции</param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        public static Result ShowCategory(
            ExternalCommandData commandData, BuiltInCategory cat, string name, ViewGraphicsOverrideType graphicsOverrideType)
        {
            try
            {
                if (BlockedByCurrentViewTemplate(commandData, graphicsOverrideType))
                    return Result.Cancelled;
                var doc = commandData.Application.ActiveUIDocument.Document;
                Category category = doc.Settings.Categories.get_Item(cat);
                if (category?.get_Visible(doc.ActiveView) == false)
                {
                    using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Show") + " " + Language.GetItem(LangItem, name)))
                    {
                        tr.Start();
                        category.set_Visible(doc.ActiveView, true);
                        tr.Commit();
                    }
                }

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Показать указанную категорию с текущего вида</summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="cats">Список категорий</param>
        /// <param name="name">Имя категории, отображаемое в транзакции</param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        public static Result ShowCategory(
            ExternalCommandData commandData, List<BuiltInCategory> cats, string name, ViewGraphicsOverrideType graphicsOverrideType)
        {
            try
            {
                if (BlockedByCurrentViewTemplate(commandData, graphicsOverrideType))
                    return Result.Cancelled;
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Hide") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (var cat in cats)
                    {
                        Category category = doc.Settings.Categories.get_Item(cat);
                        if (category?.get_Visible(doc.ActiveView) == false)
                            category.set_Visible(doc.ActiveView, true);
                    }

                    tr.Commit();
                }

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Показать категории, название которых содержит указанное значение</summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="name">Имя категории. Оно же должно содержаться в строковом представлении перечеслителя категории</param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        public static Result ShowCategory(
            ExternalCommandData commandData, string name, ViewGraphicsOverrideType graphicsOverrideType)
        {
            try
            {
                if (BlockedByCurrentViewTemplate(commandData, graphicsOverrideType))
                    return Result.Cancelled;
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Show") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (BuiltInCategory cat in Enum.GetValues(typeof(BuiltInCategory)))
                    {
                        if (cat.ToString().Contains(name))
                        {
                            Category category = doc.Settings.Categories.get_Item(cat);
                            if (category?.get_Visible(doc.ActiveView) == false)
                            {
                                category.set_Visible(doc.ActiveView, true);
                            }
                        }
                    }

                    tr.Commit();
                }

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>Показать категории, название которых содержит указанное значение</summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="name">Имя категории</param>
        /// <param name="contains">Значение, которое должно содержаться в строковом представлении перечеслителя категории</param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        public static Result ShowCategory(
            ExternalCommandData commandData, string name, string contains, ViewGraphicsOverrideType graphicsOverrideType)
        {
            try
            {
                if (BlockedByCurrentViewTemplate(commandData, graphicsOverrideType))
                    return Result.Cancelled;
                var doc = commandData.Application.ActiveUIDocument.Document;
                using (var tr = new Transaction(doc, Language.GetItem(LangItem, "Show") + " " + Language.GetItem(LangItem, name)))
                {
                    tr.Start();
                    foreach (BuiltInCategory cat in Enum.GetValues(typeof(BuiltInCategory)))
                    {
                        if (cat.ToString().Contains(contains))
                        {
                            Category category = doc.Settings.Categories.get_Item(cat);
                            if (category?.get_Visible(doc.ActiveView) == false)
                            {
                                category.set_Visible(doc.ActiveView, true);
                            }
                        }
                    }

                    tr.Commit();
                }

                return Result.Succeeded;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
                return Result.Failed;
            }
        }

        /// <summary>
        /// Проверка текущего вида на наличие примененного шаблона вида, блокирующего смену видимости категории
        /// </summary>
        /// <param name="commandData"><see cref="ExternalCommandData"/></param>
        /// <param name="graphicsOverrideType">Тип переопределения графики в шаблоне,
        /// который должен быть отключен для возможности работы команды</param>
        private static bool BlockedByCurrentViewTemplate(
            ExternalCommandData commandData, ViewGraphicsOverrideType graphicsOverrideType)
        {
            var view = commandData.View;
            if (!view.IsTemplate && view.ViewTemplateId != ElementId.InvalidElementId &&
                commandData.Application.ActiveUIDocument.Document.GetElement(view.ViewTemplateId) is View template &&
                !IsNotControlledViewGraphicsOverrideInTemplate(template, graphicsOverrideType))
            {
                // Невозможно изменить настройки видимости для категории на текущем виде, так как к виду применен шаблон вида
                MessageBox.Show(Language.GetItem(LangItem, "m1"), MessageBoxIcon.Close);
                return true;
            }

            return false;
        }

        private static bool IsNotControlledViewGraphicsOverrideInTemplate(
            View template, ViewGraphicsOverrideType graphicsOverrideType)
        {
            // Коллекция идентификаторов настроек в шаблоне у которых снята галочка "Включить"
            var ids = template.GetNonControlledTemplateParameterIds().Select(id => id.IntegerValue);
            switch (graphicsOverrideType)
            {
                case ViewGraphicsOverrideType.Model:
                    return ids.Contains((int)BuiltInParameter.VIS_GRAPHICS_MODEL);
                case ViewGraphicsOverrideType.Annotation:
                    return ids.Contains((int)BuiltInParameter.VIS_GRAPHICS_ANNOTATION);
                case ViewGraphicsOverrideType.AnalyticalModel:
                    return ids.Contains((int)BuiltInParameter.VIS_GRAPHICS_ANALYTICAL_MODEL);
                case ViewGraphicsOverrideType.Import:
                    return ids.Contains((int)BuiltInParameter.VIS_GRAPHICS_IMPORT);
                case ViewGraphicsOverrideType.Filters:
                    return ids.Contains((int)BuiltInParameter.VIS_GRAPHICS_FILTERS);
            }

            return false;
        }
    }
}
#pragma warning restore SA1402 // File may only contain a single type
#pragma warning restore SA1600 // Elements should be documented