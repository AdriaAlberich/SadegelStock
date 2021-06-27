/**
 *  Sadegel Core (SadegelStock) - ProductProvider.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadegelCore
{
    /// <summary>
    /// ProductProvider class
    /// </summary>
    public class ProductProvider
    {
        public Product Product { get; set; }
        public Provider Provider { get; set; }
        public float Price { get; set; }
        public string Currency { get; set; }
    }
}
