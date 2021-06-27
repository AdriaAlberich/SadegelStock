/**
 *  Sadegel Core (SadegelStock) - ProductAmount.cs
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
    /// ProductAmount class
    /// </summary>
    public class ProductAmount
    {
        public Product Product { get; set; }
        public float Amount { get; set; }
        public bool Unit { get; set; }
    }
}
