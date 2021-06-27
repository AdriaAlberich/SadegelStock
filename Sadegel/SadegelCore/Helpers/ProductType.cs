/**
 *  Sadegel Core (SadegelStock) - ProductType.cs
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
    /// ProductType class
    /// </summary>
    public static class ProductType
    {
        public const string Raw = "raw";
        public const string Manufactured = "manufactured";
        public const string Consumable = "consumable";
    }
}
