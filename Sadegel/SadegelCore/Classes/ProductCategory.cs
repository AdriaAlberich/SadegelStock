/**
 *  Sadegel Core (SadegelStock) - ProductCategory.cs
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
    /// ProductCategory class
    /// </summary>
    public class ProductCategory
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Creates a new product category
        /// </summary>
        /// <param name="Name">The category name</param>
        /// <returns>The product category object</returns>
        public static ProductCategory Create(string Name)
        {
            try
            {

                // Instantiate a new disposable connection
                using (MySqlConnection TempConnection = new MySqlConnection())
                {
                    // Try to connect to database
                    TempConnection.ConnectionString = Globals.ConnectionString;
                    TempConnection.Open();
                    // If success, instantiate a new disposable command
                    using (MySqlCommand TempCmd = TempConnection.CreateCommand())
                    {
                        // Command query
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_PRODUCT_CATEGORY (categoryName) " +
                            "VALUES (@Name)";
                        TempCmd.Parameters.AddWithValue("@Name", Name);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Creat PRODUCTCATEGORY " + Name);

                            // Try to load the new product category
                            ProductCategory NewCategory = Load(Name);

                            return NewCategory;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error al crear PRODUCTCATEGORY " + Name);
                            return null;
                        }

                    }

                }

            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al crear PRODUCTCATEGORY " + Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Loads a category from database
        /// </summary>
        /// <param name="Name">The category name</param>
        /// <returns>The category object</returns>
        public static ProductCategory Load(string Name)
        {
            try
            {
                ProductCategory CategoryLoaded = FindByName(Name);
                if (CategoryLoaded == null)
                {
                    // Instantiate a new disposable connection
                    using (MySqlConnection TempConnection = new MySqlConnection())
                    {
                        // Try to connect to database
                        TempConnection.ConnectionString = Globals.ConnectionString;
                        TempConnection.Open();
                        // If success, instantiate a new disposable command
                        using (MySqlCommand TempCmd = TempConnection.CreateCommand())
                        {
                            // Command query
                            TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PRODUCT_CATEGORY WHERE categoryName = @Name AND isDeleted = 0";
                            TempCmd.Parameters.AddWithValue("@Name", Name);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {

                                    // New product category
                                    ProductCategory NewCategory = new ProductCategory();

                                    NewCategory.Id = TempReader.GetUInt32("id");
                                    NewCategory.Name = TempReader.GetString("categoryName");
                                    NewCategory.CreatedAt = TempReader.GetDateTime("createdAt");
                                    NewCategory.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                    return NewCategory;
                                }
                                else
                                {
                                    Logs.Debug("[SadegelCore] Error al carregar PRODUCTCATEGORY " + Name + " no existeix");
                                    return null;
                                }

                            }

                        }

                    }
                }
                else
                {
                    Logs.Debug("[SadegelCore] Ja existeix PRODUCTCATEGORY " + Name + " retornant objecte");
                    return CategoryLoaded;
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar PRODUCTCATEGORY " + Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// Loads all categories from database
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public static bool LoadAll()
        {
            try
            {
                // Clear product category pool
                Globals.ProductCategoryPool.Clear();

                // Instantiate a new disposable connection
                using (MySqlConnection TempConnection = new MySqlConnection())
                {
                    // Try to connect to database
                    TempConnection.ConnectionString = Globals.ConnectionString;
                    TempConnection.Open();
                    // If success, instantiate a new disposable command
                    using (MySqlCommand TempCmd = TempConnection.CreateCommand())
                    {
                        // Command query
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PRODUCT_CATEGORY WHERE isDeleted = 0";

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {
                                ProductCategory NewCategory = new ProductCategory();
                                NewCategory.Id = TempReader.GetUInt32("id");
                                NewCategory.Name = TempReader.GetString("categoryName");
                                NewCategory.CreatedAt = TempReader.GetDateTime("createdAt");
                                NewCategory.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                // Add new product category to the global pool
                                Globals.ProductCategoryPool.Add(NewCategory);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar PRODUCTCATEGORYs");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Updates a category
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public bool Update()
        {
            try
            {
                // Instantiate a new disposable connection
                using (MySqlConnection TempConnection = new MySqlConnection())
                {
                    // Try to connect to database
                    TempConnection.ConnectionString = Globals.ConnectionString;
                    TempConnection.Open();
                    // If success, instantiate a new disposable command
                    using (MySqlCommand TempCmd = TempConnection.CreateCommand())
                    {
                        // Command query
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_PRODUCT_CATEGORY SET categoryName = @Name WHERE id = @Id";
                        TempCmd.Parameters.AddWithValue("@Id", this.Id);
                        TempCmd.Parameters.AddWithValue("@Name", this.Name);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Actualitzat PRODUCTCATEGORY " + this.Name);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'actualitzar PRODUCTCATEGORY " + this.Name);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'actualitzar PRODUCTCATEGORY " + this.Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Deletes a category
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public bool Delete()
        {
            try
            {
                // Instantiate a new disposable connection
                using (MySqlConnection TempConnection = new MySqlConnection())
                {
                    // Try to connect to database
                    TempConnection.ConnectionString = Globals.ConnectionString;
                    TempConnection.Open();
                    // If success, instantiate a new disposable command
                    using (MySqlCommand TempCmd = TempConnection.CreateCommand())
                    {
                        // Command query
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_PRODUCT_CATEGORY SET isDeleted = 1 WHERE id = @Id";
                        TempCmd.Parameters.AddWithValue("@Id", this.Id);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Globals.ProductCategoryPool.Remove(this);
                            Logs.Debug("[SadegelCore] Eliminat PRODUCTCATEGORY " + this.Name);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar PRODUCTCATEGORY " + this.Name);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar PRODUCTCATEGORY " + this.Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Try to get the category from the pool by its name
        /// </summary>
        /// <param name="Name">The category name</param>
        /// <returns>The product category object or null if not found</returns>
        public static ProductCategory FindByNamePart(string Name)
        {
            return Globals.ProductCategoryPool.Find(x => x.Name.Contains(Name));
        }

        /// <summary>
        /// Try to get the category from the pool by its name
        /// </summary>
        /// <param name="Name">The category name</param>
        /// <returns>The product category object or null if not found</returns>
        public static ProductCategory FindByName(string Name)
        {
            return Globals.ProductCategoryPool.Find(x => x.Name == Name);
        }
    }
}
