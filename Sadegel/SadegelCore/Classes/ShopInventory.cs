/**
 *  Sadegel Core (SadegelStock) - ShopInventory.cs
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
    /// ShopInventory class
    /// </summary>
    public class ShopInventory
    {
        /// <summary>
        /// Inventory content
        /// </summary>
        public List<ProductAmount> Content { get; set; }

        /// <summary>
        /// Shop Id
        /// </summary>
        public uint ShopId { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ShopInventory(uint ShopId)
        {
            this.Content = new List<ProductAmount>();
            this.ShopId = ShopId;
        }

        /// <summary>
        /// Loads shop inventory from database
        /// </summary>
        /// <param name="ShopId">The shop id</param>
        /// <returns>ShopInventory object</returns>
        public static ShopInventory Load(uint ShopId)
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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_SHOP_INVENTORY WHERE shopId = @ShopId";
                        TempCmd.Parameters.AddWithValue("@ShopId", ShopId);

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            // New shop inventory
                            ShopInventory NewShopInventory = new ShopInventory(ShopId);
                            while (TempReader.Read())
                            {
                                ProductAmount ProductAmount = new ProductAmount();
                                ProductAmount.Product = Product.FindById(TempReader.GetUInt32("productId"));
                                ProductAmount.Amount = TempReader.GetInt32("amount");

                                // Add new product amount to the inventory
                                NewShopInventory.Content.Add(ProductAmount);
                            }

                            return NewShopInventory;

                        }

                    }

                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar SHOP INVENTORY " + ShopId);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// Updates the inventory
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public bool Update()
        {
            try
            {
                foreach (ProductAmount ProductAmount in Content)
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
                            TempCmd.CommandText = "SELECT productId FROM SADEGEL_STOCK_SHOP_INVENTORY WHERE shopId = @ShopId AND productId = @ProductId";
                            TempCmd.Parameters.AddWithValue("@ShopId", ShopId);
                            TempCmd.Parameters.AddWithValue("@ProductId", ProductAmount.Product.Id);
                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {
                                    TempReader.Close();
                                    // Command query
                                    TempCmd.CommandText = "UPDATE SADEGEL_STOCK_SHOP_INVENTORY SET amount = @Amount WHERE shopId = @ShopId AND productId = @ProductId";
                                    TempCmd.Parameters.AddWithValue("@Amount", ProductAmount.Amount);
                                    TempCmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    TempReader.Close();
                                    // Command query
                                    TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_SHOP_INVENTORY VALUES (@ShopId,@ProductId,@Amount)";
                                    TempCmd.Parameters.AddWithValue("@Amount", ProductAmount.Amount);

                                    TempCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'actualitzar SHOP INVENTORY " + ShopId);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Deletes a product from de inventory
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public bool Delete(ProductAmount Product)
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
                        TempCmd.CommandText = "DELETE FROM SADEGEL_STOCK_SHOP_INVENTORY WHERE shopId = @ShopId AND productId = @ProductId";
                        TempCmd.Parameters.AddWithValue("@ShopId", ShopId);
                        TempCmd.Parameters.AddWithValue("@ProductId", Product.Product.Id);

                        if(TempCmd.ExecuteNonQuery() > 0)
                        {
                            Content.Remove(Product);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'eliminar producte de SHOP INVENTORY " + ShopId);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public int ProcessMassiveStockModification(string Path, User User = null)
        {
            int Modifications = 0;
            bool ErrorStatus = false;
            try
            {
                Dictionary<string, string> Data = Util.ReadExcelReport(Path);
                if(Data.Count > 0)
                {
                    long MainLog = Logs.EventLog("COMENÇANT PROCESSAMENT MASSIU DE STOCK (Excel)", EventLogOrigin.SadegelCore, EventLogType.ShopStockMovement, "SYSTEM", "SYSTEM", (int)ShopId);
                    foreach(KeyValuePair<string, string> StockModification in Data)
                    {
                        if(StockModification.Key != string.Empty && StockModification.Value != string.Empty)
                        {
                            foreach (ProductAmount Stock in Content)
                            {
                                if (Stock.Product.Identifiers.Contains(StockModification.Key))
                                {
                                    int ResultCode = ProcessStockModification(Stock, StockModification.Value, MainLog);
                                    if (ResultCode == 1)
                                    {
                                        Modifications++;
                                    }
                                    else
                                    {
                                        if(ResultCode == -1)
                                        {
                                            ErrorStatus = true;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (ErrorStatus)
                            {
                                break;
                            }
                        }
                    }

                    if (!ErrorStatus && Globals.Settings["use_of_stock"] == "Si")
                    {
                        this.Update();
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
            }

            if (ErrorStatus)
            {

                // Rollback if error

                if(Globals.Settings["use_of_stock"] == "Si")
                {
                    Shop Shop = Shop.FindById(ShopId);
                    if (Shop != null)
                    {
                        Shop.Inventory = Load(ShopId);
                    }
                }

                // Set Modifications to -1 to inform of the error
                Modifications = -1;
            }

            return Modifications;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Stock"></param>
        /// <param name="Modification"></param>
        /// <param name="MainLog"></param>
        /// <returns></returns>
        public int ProcessStockModification(ProductAmount Stock, string Modification, long MainLog)
        {
            int Success = 0;
            try
            {
                if (Modification != string.Empty)
                {
                    Modification = Modification.Trim();
                    char FirstChar = Modification.ToCharArray()[0];
                    if (FirstChar == '+' || FirstChar == '-')
                    {
                        string Number = Modification.Remove(0, 1);
                        if (Util.IsNumeric(Number))
                        {
                            int Quantity = int.Parse(Number);
                            if (Quantity > 0)
                            {
                                switch (FirstChar)
                                {
                                    case '+':
                                        {
                                            if(Globals.Settings["use_of_stock"] == "Si")
                                            {
                                                Stock.Amount += Quantity;
                                            }
                                            Logs.EventLog("Sumades " + Quantity + " unitats de " + Stock.Product.Name + ". Establiment: " + Shop.FindById(ShopId).Name, EventLogOrigin.SadegelCore, EventLogType.ShopStockMovement, "SYSTEM", "SYSTEM", (int)ShopId, (int)Stock.Product.Id, Quantity, MainLog);
                                            Success = 1;
                                            break;
                                        }
                                    case '-':
                                        {
                                            if (Globals.Settings["use_of_stock"] == "Si")
                                            {
                                                Stock.Amount -= Quantity;
                                            }
                                            Logs.EventLog("Restades " + Quantity + " unitats de " + Stock.Product.Name + ". Establiment: " + Shop.FindById(ShopId).Name, EventLogOrigin.SadegelCore, EventLogType.ShopStockMovement, "SYSTEM", "SYSTEM", (int)ShopId, (int)Stock.Product.Id, Quantity * -1, MainLog);
                                            Success = 1;
                                            break;
                                        }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Util.IsNumeric(Modification))
                        {
                            int Quantity = int.Parse(Modification);
                            if (Quantity >= 0)
                            {
                                if (Globals.Settings["use_of_stock"] == "Si")
                                {
                                    Stock.Amount = Quantity;
                                }
                                Logs.EventLog("Modificades " + Quantity + " unitats de " + Stock.Product.Name + ". Establiment: " + Shop.FindById(ShopId).Name, EventLogOrigin.SadegelCore, EventLogType.ShopStockMovement, "SYSTEM", "SYSTEM", (int)ShopId, (int)Stock.Product.Id, Quantity, MainLog);
                                Success = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                Success = -1;
            }

            return Success;
        }
    }
}
