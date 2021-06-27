/**
 *  Sadegel Core (SadegelStock) - Logs.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SadegelCore
{
    /// <summary>
    /// Custom text logs
    /// </summary>
    public class Logs
    {
        /// <summary>
        /// Log system initialization
        /// </summary>
        public static void Initialize()
        {
            try
            {
                List<string> logs = new List<string>();

                // Add here the list of available log types.
                logs.Add("debug");
                logs.Add("general");

                // Check if log directories exist, if not then creates them
                foreach (string log in logs)
                {
                    string tempPath = Globals.LogsDir + "/" + log;
                    if (!File.Exists(tempPath))
                    {
                        Directory.CreateDirectory(tempPath);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }

        /// <summary>
        /// Registers a log line
        /// </summary>
        /// <param name="type">The type of log</param>
        /// <param name="text">The text</param>
        public static void Register(string type, string text)
        {
            try
            {
                // Get time and date
                DateTime date = DateTime.UtcNow;

                // Give format to the path and file name
                string tempPath = string.Format("{0}/{1}/{2}-{3}-{4}.log", Globals.LogsDir, type, date.Day, date.Month, date.Year);

                // Check if log file exist, otherwise create it.
                if (!File.Exists(tempPath))
                {
                    StreamWriter tempWr = File.CreateText(tempPath);
                    tempWr.Close();

                }

                // Open file to write
                StreamWriter wr = File.AppendText(tempPath);

                // Give format to the message
                string finalLog = string.Format("\r[{0:D2}:{1:D2}:{2:D2}] {3}", date.Hour, date.Minute, date.Second, text);

                // Write the message on the file
                wr.WriteLine(finalLog);

                // Clean the buffer and close writer.
                wr.Flush();
                wr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// General log method
        /// </summary>
        /// <param name="text">Log text</param>
        public static void GeneralLog(string text)
        {
            Console.WriteLine(text);
            Register("general", text);
        }

        /// <summary>
        /// Debug log
        /// </summary>
        /// <param name="text">The debug text</param>
        public static void Debug(string text)
        {
            Console.WriteLine("[DEBUG] " + text);
            Register("debug", text);
        }

        /// <summary>
        /// Eventlog system
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="pcName"></param>
        /// <param name="userName"></param>
        /// <param name="shopId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public static long EventLog(string message, string origin = "core", string type = "general", string pcName = "SYSTEM", string userName = "SYSTEM", int shopId = -1, int productId = -1, float quantity = 0, long relatedWith = -1)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_EVENTLOG (message, origin, type, pcName, userName, shopId, productId, quantity, relatedWith) VALUES (@message, @origin, @type, @pcName, @userName, @shopId, @productId, @quantity, @relatedWith)";
                        TempCmd.Parameters.AddWithValue("@message", message);
                        TempCmd.Parameters.AddWithValue("@origin", origin);
                        TempCmd.Parameters.AddWithValue("@type", type);
                        TempCmd.Parameters.AddWithValue("@pcName", pcName);
                        TempCmd.Parameters.AddWithValue("@userName", userName);
                        TempCmd.Parameters.AddWithValue("@shopId", shopId);
                        TempCmd.Parameters.AddWithValue("@productId", productId);
                        TempCmd.Parameters.AddWithValue("@quantity", quantity);
                        TempCmd.Parameters.AddWithValue("@relatedWith", relatedWith);

                        if (TempCmd.ExecuteNonQuery() == 0)
                        {
                            Debug("[EventLog] Error de MySQL a l\'insertar: " + message + " " + origin + " " + type + " " + pcName + " " + userName + " " + shopId + " " + productId + " " + quantity + " " + relatedWith);
                        }
                        else
                        {
                            return TempCmd.LastInsertedId;
                        }
                    }
                }

                return -1;
            }
            catch (Exception e)
            {
                Debug(e.Message);
                Debug(e.StackTrace);
                Debug("[EventLog] Excepció a l\'insertar: " + message + " " + origin + " " + type + " " + pcName + " " + userName + " " + shopId + " " + productId + " " + quantity + " " + relatedWith);
                return -1;
            }
        }

        /// <summary>
        /// Returns a part of the eventlog
        /// </summary>
        /// <param name="Since"></param>
        /// <param name="Last"></param>
        /// <param name="Type"></param>
        /// <param name="Importance"></param>
        /// <returns></returns>
        public static List<EventLogModel> GetEventLog(int Last = 0, string Origin = "", string Type = "", uint ShopId = 0, uint ProductId = 0, int RelatedWith = -1, DateTime? Since = null, DateTime? To = null)
        {
            try
            {
                List<EventLogModel> Logs = new List<EventLogModel>();
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
                         
                        string TempQuery = "SELECT * FROM SADEGEL_STOCK_EVENTLOG";
                        
                        bool LastCondition = false;

                        if(Since != null || Origin != string.Empty || Type != string.Empty || RelatedWith != -1)
                        {
                            TempQuery += " WHERE";
                        }

                        if(Origin != string.Empty)
                        {
                            if (LastCondition)
                            {
                                TempQuery += " AND origin = @Origin";
                            }
                            else
                            {
                                TempQuery += " origin = @Origin";
                                LastCondition = true;
                            }

                            TempCmd.Parameters.AddWithValue("@Origin", Origin);
                        }

                        if (Type != string.Empty)
                        {
                            if (LastCondition)
                            {
                                TempQuery += " AND type = @Type";
                            }
                            else
                            {
                                TempQuery += " type = @Type";
                                LastCondition = true;
                            }

                            TempCmd.Parameters.AddWithValue("@Type", Type);
                        }

                        if (ShopId > 0)
                        {
                            if (LastCondition)
                            {
                                TempQuery += " AND shopId = @ShopId";
                            }
                            else
                            {
                                TempQuery += " shopId = @ShopId";
                                LastCondition = true;
                            }

                            TempCmd.Parameters.AddWithValue("@ShopId", ShopId);
                        }

                        if (ProductId > 0)
                        {
                            if (LastCondition)
                            {
                                TempQuery += " AND productId = @ProductId";
                            }
                            else
                            {
                                TempQuery += " productId = @ProductId";
                                LastCondition = true;
                            }

                            TempCmd.Parameters.AddWithValue("@ProductId", ProductId);
                        }

                        if (RelatedWith != -1)
                        {
                            if (LastCondition)
                            {
                                TempQuery += " AND relatedWith = @RelatedWith";
                            }
                            else
                            {
                                TempQuery += " relatedWith = @RelatedWith";
                                LastCondition = true;
                            }

                            TempCmd.Parameters.AddWithValue("@RelatedWith", RelatedWith);
                        }

                        if (Since != null)
                        {
                            if(LastCondition)
                            {
                                TempQuery += " AND logDate >= @Since";
                            }
                            else
                            {
                                TempQuery += " logDate >= @Since";
                                LastCondition = true;
                            }
                            
                            TempCmd.Parameters.AddWithValue("@Since", Since);
                        }

                        if (To != null)
                        {
                            if (LastCondition)
                            {
                                TempQuery += " AND logDate <= @To";
                            }
                            else
                            {
                                TempQuery += " logDate <= @To";
                            }

                            TempCmd.Parameters.AddWithValue("@To", To);
                        }

                        if(Last > 0)
                        {
                            TempQuery += " ORDER BY logDate DESC LIMIT " + Last;
                        }

                        TempCmd.CommandText = TempQuery;

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {
                                EventLogModel Log = new EventLogModel();

                                Log.Missatge = TempReader.GetString("message");
                                Log.Origen = TempReader.GetString("origin");
                                Log.Tipus = TempReader.GetString("type");
                                Log.PC = TempReader.GetString("pcName");
                                Log.Usuari = TempReader.GetString("userName");
                                int ShopId2 = TempReader.GetInt32("shopId");
                                if(ShopId2 != -1)
                                {
                                    Shop Shop = Shop.FindById(uint.Parse(ShopId2.ToString()));
                                    if(Shop != null)
                                    {
                                        Log.Establiment = Shop.Name;
                                    }
                                    else
                                    {
                                        Log.Establiment = "-";
                                    }

                                }
                                else
                                {
                                    Log.Establiment = "-";
                                }

                                int ProductId2 = TempReader.GetInt32("productId");
                                if (ProductId2 != -1)
                                {
                                    Product Product = Product.FindById(uint.Parse(ProductId2.ToString()));
                                    if (Product != null)
                                    {
                                        Log.Producte = Product.Name;
                                    }
                                    else
                                    {
                                        Log.Producte = "-";
                                    }

                                }
                                else
                                {
                                    Log.Producte = "-";
                                }

                                Log.Quantitat = TempReader.GetFloat("quantity").ToString();
                                Log.Data = TempReader.GetDateTime("logDate");

                                Logs.Add(Log);
                            }

                            return Logs;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug(e.Message);
                Debug(e.StackTrace);
                return null;
            }
        }
    }
}