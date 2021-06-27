/**
 *  Sadegel Core (SadegelStock) - EventLogOrigin.cs
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
    /// EventLogOrigin class
    /// </summary>
    public static class EventLogOrigin
    {
        public const string SadegelCore = "core";
        public const string SadegelBot = "bot";
        public const string SadegelStock = "stock";

        public static Dictionary<string, string> Text = new Dictionary<string, string>()
        {
            { SadegelCore, "Sadegel Core" },
            { SadegelBot, "Sadegel Bot" },
            { SadegelStock, "Sadegel Stock" }
        };
    }
}
