/**
 *  Sadegel Core (SadegelStock) - EventLogType.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SadegelCore
{
    /// <summary>
    /// EventLogType class
    /// </summary>
    public static class EventLogType
    {
        public const string CountryMaintenance = "country_maintenance";
        public const string ProductCategoryMaintenance = "category_maintenance";
        public const string ProductMaintenance = "product_maintenance";
        public const string ProviderMaintenance = "provider_maintenance";
        public const string ShopMaintenance = "shop_maintenance";
        public const string ShopStockSummary = "shop_stock_summary";
        public const string ShopStockMovement = "shop_stock_movement";
        public const string ShopStockProductionSummary = "shop_stock_production_summary";

        public static Dictionary<string, string> Text = new Dictionary<string,string>()
        {
            { CountryMaintenance, "Manteniment Països" },
            { ProductCategoryMaintenance, "Manteniment Categories" },
            { ProductMaintenance, "Manteniment Productes" },
            { ProviderMaintenance, "Manteniment Proveïdors" },
            { ShopMaintenance, "Manteniment Establiments" },
            { ShopStockSummary, "Tancament de caixa" },
            { ShopStockMovement, "Moviment stock" },
            { ShopStockProductionSummary, "Informe de producció" }
        };
    }
}
