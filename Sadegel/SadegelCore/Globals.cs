/**
 *  Sadegel Core (SadegelStock) - Globals.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadegelCore
{
    /// <summary>
    /// Globals class, contains constants, public variables and global definitions.
    /// </summary>
    public class Globals
    {
        /// <summary>
        /// Database connection string (PLACEHOLDER)
        /// </summary>
        public const string ConnectionString =
            "Server=localhost;" +           // MySQL server
            "Uid=root;" +                   // MySQL user
            "Pwd=;" +                       // MySQL password
            "Database=sadegel_stock;" +     // MySQL database name
            "Port=3307;";                   // MySQL port

        /// <summary>
        /// Relative logs path
        /// </summary>
        public static string LogsDir = @"logs";

        /// <summary>
        /// Shop pool
        /// </summary>
        public static List<Shop> ShopPool = new List<Shop>();

        /// <summary>
        /// Country pool
        /// </summary>
        public static List<Country> CountryPool = new List<Country>();

        /// <summary>
        /// ProductCategory pool
        /// </summary>
        public static List<ProductCategory> ProductCategoryPool = new List<ProductCategory>();

        /// <summary>
        /// Product pool
        /// </summary>
        public static List<Product> ProductPool = new List<Product>();

        /// <summary>
        /// Provider pool
        /// </summary>
        public static List<Provider> ProviderPool = new List<Provider>();

        /// <summary>
        /// User pool
        /// </summary>
        public static List<User> UserPool = new List<User>();

        /// <summary>
        /// Role pool
        /// </summary>
        public static List<Role> RolePool = new List<Role>();

        /// <summary>
        /// Global settings
        /// </summary>
        public static Dictionary<string, string> Settings = new Dictionary<string, string>();
    }
}
