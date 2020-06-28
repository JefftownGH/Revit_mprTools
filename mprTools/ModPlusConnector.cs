#pragma warning disable SA1600 // Elements should be documented
namespace mprTools
{
    using System;
    using System.Collections.Generic;
    using ModPlusAPI.Interfaces;

    /// <summary>Интерфейс функции ModPlus</summary>
    public class ModPlusConnector : IModPlusFunctionInterface
    {
        public SupportedProduct SupportedProduct => SupportedProduct.Revit;

        public string Name => "mprTools";
        
#if R2017
        public string AvailProductExternalVersion => "2017";
#elif R2018
        public string AvailProductExternalVersion => "2018";
#elif R2019
        public string AvailProductExternalVersion => "2019";
#elif R2020
        public string AvailProductExternalVersion => "2020";
#elif R2021
        public string AvailProductExternalVersion => "2021";
#endif
        
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
#pragma warning restore SA1600 // Elements should be documented