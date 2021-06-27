/**
 *  Sadegel Core (SadegelStock) - Shop.cs
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
    /// Shop class
    /// </summary>
    public class Shop
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Address Address { get; set; }
        public string Tpv { get; set; }
        public Country Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ShopInventory Inventory { get; set; }

        /// <summary>
        /// Creates a new shop
        /// </summary>
        /// <param name="Name">The shop name</param>
        /// <param name="Type">The shop type</param>
        /// <param name="Address">The shop address</param>
        /// <param name="Tpv">The shop TPV</param>
        /// <param name="Country">The shop country</param>
        /// <returns>The new shop object</returns>
        public static Shop Create(string Name, string Type, Address Address, string Tpv, Country Country)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_SHOP (shopName, type, address, tpv, countryIsoCode) " +
                            "VALUES (@Name, @Type, @Address, @Tpv, @CountryIsoCode)";
                        TempCmd.Parameters.AddWithValue("@Name", Name);
                        TempCmd.Parameters.AddWithValue("@Type", Type);
                        TempCmd.Parameters.AddWithValue("@Address", Address.Serialize());
                        TempCmd.Parameters.AddWithValue("@Tpv", Tpv);
                        TempCmd.Parameters.AddWithValue("@CountryIsoCode", Country.IsoCode);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            uint NewShopId = (uint)TempCmd.LastInsertedId;
                            Logs.Debug("[SadegelCore] Creat SHOP " + Name + ", TYPE: " + Type + ", TPV: " + Tpv);

                            // Try to load the new account
                            Shop NewShop = Load(NewShopId);

                            return NewShop;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error al crear SHOP " + Name + " " + Type);
                            return null;
                        }

                    }

                }

            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al crear SHOP " + Name + " " + Type);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Loads a shop from database
        /// </summary>
        /// <param name="Id">The id of the shop</param>
        /// <returns>The shop object or null if not exists</returns>
        public static Shop Load(uint Id)
        {
            try
            {
                Shop ShopLoaded = FindById(Id);
                if (ShopLoaded == null)
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
                            TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_SHOP WHERE id = @Id";
                            TempCmd.Parameters.AddWithValue("@Id", Id);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {

                                    // New shop
                                    Shop NewShop = new Shop();

                                    NewShop.Id = TempReader.GetUInt32("id");
                                    NewShop.Name = TempReader.GetString("shopName");
                                    NewShop.Type = TempReader.GetString("type");
                                    NewShop.Address = Address.Deserialize(TempReader.GetString("address"));
                                    NewShop.Tpv = TempReader.GetString("tpv");
                                    NewShop.Country = Country.FindByCode(TempReader.GetString("countryIsoCode"));
                                    NewShop.CreatedAt = TempReader.GetDateTime("createdAt");
                                    NewShop.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                    NewShop.Inventory = ShopInventory.Load(NewShop.Id);

                                    return NewShop;
                                }
                                else
                                {
                                    return null;
                                }

                            }

                        }

                    }
                }
                else
                {
                    return ShopLoaded;
                }
            }
            catch (Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// Loads all shops from database
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public static bool LoadAll()
        {
            try
            {
                // Clear shop pool
                Globals.ShopPool.Clear();

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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_SHOP WHERE isDeleted = 0";

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {
                                Shop NewShop = new Shop();
                                NewShop.Id = TempReader.GetUInt32("id");
                                NewShop.Name = TempReader.GetString("shopName");
                                NewShop.Type = TempReader.GetString("type");
                                NewShop.Address = Address.Deserialize(TempReader.GetString("address"));
                                NewShop.Tpv = TempReader.GetString("tpv");
                                NewShop.Country = Country.FindByCode(TempReader.GetString("countryIsoCode"));
                                NewShop.CreatedAt = TempReader.GetDateTime("createdAt");
                                NewShop.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                NewShop.Inventory = ShopInventory.Load(NewShop.Id);

                                // Add new shop to the global pool
                                Globals.ShopPool.Add(NewShop);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar SHOPs");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Updates a shop
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_SHOP SET shopName = @Name, type = @Type, address = @Address, tpv = @Tpv, countryIsoCode = @CountryIsoCode WHERE id = @Id";
                        TempCmd.Parameters.AddWithValue("@Name", this.Name);
                        TempCmd.Parameters.AddWithValue("@Type", this.Type);
                        TempCmd.Parameters.AddWithValue("@Address", this.Address.Serialize());
                        TempCmd.Parameters.AddWithValue("@Tpv", this.Tpv);
                        TempCmd.Parameters.AddWithValue("@CountryIsoCode", this.Country.IsoCode);

                        TempCmd.Parameters.AddWithValue("@Id", this.Id);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            this.Inventory.Update();
                            Logs.Debug("[SadegelCore] Actualitzat SHOP " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'actualitzar SHOP " + this.Id);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'actualitzar SHOP " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Safely deletes a shop from database
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_SHOP SET isDeleted = 1 WHERE id = @Id";
                        TempCmd.Parameters.AddWithValue("@Id", this.Id);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Globals.ShopPool.Remove(this);
                            Logs.Debug("[SadegelCore] Eliminat SHOP " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar SHOP " + this.Id);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar SHOP " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Inserts a manufactured product production report
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public bool AddProductProduction(Product ManufacturedProduct, float Quantity)
        {
            try
            {
                if (ManufacturedProduct.Type == ProductType.Manufactured)
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
                            TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_SHOP_PRODUCTION VALUES (shopId, manufacturedProductId, quantity) VALUES (@ShopId, @ManufacturedProductId, @Quantity)";
                            TempCmd.Parameters.AddWithValue("@ShopId", this.Id);
                            TempCmd.Parameters.AddWithValue("@ManufacturedProductId", ManufacturedProduct.Id);
                            TempCmd.Parameters.AddWithValue("@Quantity", Quantity);

                            if (TempCmd.ExecuteNonQuery() > 0)
                            {
                                Logs.Debug("[SadegelCore] Insertat nou informe de producció de PRODUCT " + ManufacturedProduct.Id + " a SHOP " + this.Id + " amb quantitat de " + Quantity);
                                return true;
                            }
                            else
                            {
                                Logs.Debug("[SadegelCore] Error al insertar informe de producció de SHOP " + this.Id + " per PRODUCT " + ManufacturedProduct.Id + " quantitat de " + Quantity);
                            }
                        }
                    }
                }
                else
                {
                    Logs.Debug("[SadegelCore] Error al insertar informe de producció de SHOP " + this.Id + ": el producte no es manufacturat");
                }

                return false;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al insertar informe de producció de SHOP " + this.Id + " per PRODUCT " + ManufacturedProduct.Id + " quantitat de " + Quantity);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Returns the total production value for a shop and product
        /// </summary>
        /// <param name="ManufacturedProduct">The product</param>
        /// <param name="InitialTimestamp">The initial timestamp</param>
        /// <param name="LastTimestamp">The last timestamp</param>
        /// <returns>The total production value or -1 in case of error</returns>
        public float GetProductProductionBetweenDates(Product ManufacturedProduct, DateTime InitialDate, DateTime FinalDate)
        {
            try
            {
                if (ManufacturedProduct.Type == ProductType.Manufactured)
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
                            TempCmd.CommandText = "SELECT SUM(quantity) AS totalQuantity FROM SADEGEL_STOCK_SHOP_PRODUCTION WHERE shopId = @ShopId AND manufacturedProductId = @ManufacturedProductId AND (producedAt BETWEEN @InitialDate AND @FinalDate)";
                            TempCmd.Parameters.AddWithValue("@ShopId", this.Id);
                            TempCmd.Parameters.AddWithValue("@ManufacturedProductId", ManufacturedProduct.Id);
                            TempCmd.Parameters.AddWithValue("@InitialDate", InitialDate);
                            TempCmd.Parameters.AddWithValue("@FinalDate", FinalDate);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {
                                    float TotalQuantity = TempReader.GetFloat("totalQuantity");

                                    return TotalQuantity;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Logs.Debug("[SadegelCore] Error al calcular informe de producció de SHOP " + this.Id + ": el producte no es manufacturat");
                }
                return -1f;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al calcular informe de producció de SHOP " + this.Id + " per PRODUCT " + ManufacturedProduct.Id + " entre " + InitialDate.ToShortDateString() + " fins a " + FinalDate.ToShortDateString());
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return -1f;
            }
        }

        /// <summary>
        /// Removes a single product production report from database
        /// </summary>
        /// <param name="ManufacturedProduct">The product</param>
        /// <param name="Timestamp">The timestamp</param>
        /// <returns>true if success, false otherwise</returns>
        public bool RemoveProductProduction(Product ManufacturedProduct, long Timestamp)
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
                        TempCmd.CommandText = "DELETE FROM SADEGEL_STOCK_SHOP WHERE shopId = @ShopId AND manufacturedProductId = @ManufacturedProductId AND producedAt = @Timestamp";
                        TempCmd.Parameters.AddWithValue("@ShopId", this.Id);
                        TempCmd.Parameters.AddWithValue("@ManufacturedProductId", ManufacturedProduct.Id);
                        TempCmd.Parameters.AddWithValue("@Timestamp", Timestamp);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Eliminat informe de producció de SHOP " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar informe de producció de SHOP " + this.Id);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar informe de producció de SHOP " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Returns the total production ice cream values for the shop
        /// </summary>
        /// <param name="InitialTimestamp">The initial timestamp</param>
        /// <param name="LastTimestamp">The last timestamp</param>
        /// <returns>The amount of ice cream produced</returns>
        public float GetIceCreamProductionBetweenDates(DateTime InitialDate, DateTime FinalDate)
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
                        TempCmd.CommandText = "SELECT SUM(PRODUCTION.quantity) AS totalQuantity FROM SADEGEL_STOCK_SHOP_PRODUCTION AS PRODUCTION "  +
                                              "INNER JOIN SADEGEL_STOCK_PRODUCT AS PRODUCT ON PRODUCT.id = PRODUCTION.manufacturedProductId " +
                                              "WHERE PRODUCTION.shopId = @ShopId AND PRODUCT.isIcecream = 1 AND (PRODUCTION.producedAt BETWEEN @InitialDate AND @FinalDate)";
                        TempCmd.Parameters.AddWithValue("@ShopId", this.Id);
                        TempCmd.Parameters.AddWithValue("@InitialDate", InitialDate);
                        TempCmd.Parameters.AddWithValue("@FinalDate", FinalDate);

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            if (TempReader.Read())
                            {
                                float TotalQuantity = TempReader.GetFloat("totalQuantity");

                                return TotalQuantity;
                            }
                        }
                    }
                }

                return -1f;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al calcular informe de producció de gelat de SHOP entre " + InitialDate.ToShortDateString() + " fins a " + FinalDate.ToShortDateString());
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return -1f;
            }
        }

        /// <summary>
        /// Returns a shop from its id (already loaded)
        /// </summary>
        /// <param name="Id">The shop id</param>
        /// <returns>The shop object</returns>
        public static Shop FindById(uint Id)
        {
            return Globals.ShopPool.Find(x => x.Id == Id);
        }

        /// <summary>
        /// Returns a shop from part of its name
        /// </summary>
        /// <param name="Name">The shop name or part of it</param>
        /// <returns>The shop object</returns>
        public static Shop FindByNamePart(string Name)
        {
            return Globals.ShopPool.Find(x => x.Name.Contains(Name));
        }

        /// <summary>
        /// Returns a shop from its name
        /// </summary>
        /// <param name="Name">The shop name</param>
        /// <returns>The shop object</returns>
        public static Shop FindByName(string Name)
        {
            return Globals.ShopPool.Find(x => x.Name == Name);
        }

    }
}
