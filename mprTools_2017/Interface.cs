using System;
using System.Collections.Generic;
using ModPlusAPI.Interfaces;

namespace mprTools
{
    /// <summary>Интерфейс функции ModPlus</summary>
    public class Interface : IModPlusFunctionInterface
    {
        public SupportedProduct SupportedProduct => SupportedProduct.Revit;
        public string Name => "mprTools";
        public string AvailProductExternalVersion => "2017";
        public string FullClassName => string.Empty;
        public string AppFullClassName => "mprTools.Application.ToolsApp";
        public Guid AddInId => Guid.Parse("93880b99-ac51-41d9-8395-358a8286dd32");
        public string LName => "Утилиты";
        public string Description => "Сборник небольших вспомогательных функций";
        public string Author => "Пекшев Александр aka Modis";
        public string Price => "0";
        public bool CanAddToRibbon => false;
        public string FullDescription => "";
        public string ToolTipHelpImage => "";
        public List<string> SubFunctionsNames => new List<string>();
        public List<string> SubFunctionsLames => new List<string>();
        public List<string> SubDescriptions => new List<string>();
        public List<string> SubFullDescriptions => new List<string>();
        public List<string> SubHelpImages => new List<string>();
        public List<string> SubClassNames => new List<string>();
    }
}
