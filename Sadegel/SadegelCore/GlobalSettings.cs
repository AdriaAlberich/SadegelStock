/**
 *  Sadegel Core (SadegelStock) - GlobalSettings.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SadegelCore
{
    /// <summary>
    /// GlobalSettings class, contains setting management code
    /// </summary>
    public class GlobalSettings
    {
        
        /// <summary>
        /// Loads global settings from database
        /// </summary>
        public static void Initialize()
        {
            // Clear setting pool
            Globals.Settings.Clear();
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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_SETTINGS";

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {
                                // Add new setting to the global pool
                                Globals.Settings.Add(TempReader.GetString("key"), TempReader.GetString("value"));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar SHOPs");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
            }
        }

    }
}
