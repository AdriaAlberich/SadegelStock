/**
 *  Sadegel Core (SadegelStock) - Country.cs
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
    /// Country class
    /// </summary>
    public class Country
    {
        public string IsoCode { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Creates a new country
        /// </summary>
        /// <param name="IsoCode">The country iso code</param>
        /// <param name="Name">The country name</param>
        /// <returns>Country object</returns>
        public static Country Create(string IsoCode, string Name)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_COUNTRY (isoCode, countryName) " +
                            "VALUES (@IsoCode, @Name)";
                        TempCmd.Parameters.AddWithValue("@IsoCode", IsoCode);
                        TempCmd.Parameters.AddWithValue("@Name", Name);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Creat COUNTRY " + Name);

                            // Try to load the new country
                            Country NewCountry = Load(IsoCode);

                            return NewCountry;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error al crear COUNTRY " + Name);
                            return null;
                        }

                    }

                }

            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al crear COUNTRY " + Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Try to retrieve a country from database
        /// </summary>
        /// <param name="IsoCode">The country's iso code</param>
        /// <returns>The country object</returns>
        public static Country Load(string IsoCode)
        {
            try
            {
                Country CountryLoaded = FindByCode(IsoCode);
                if (CountryLoaded == null)
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
                            TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_COUNTRY WHERE isoCode = @IsoCode";
                            TempCmd.Parameters.AddWithValue("@IsoCode", IsoCode);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {

                                    // New country
                                    Country NewCountry = new Country();

                                    NewCountry.IsoCode = TempReader.GetString("isoCode");
                                    NewCountry.Name = TempReader.GetString("countryName");

                                    return NewCountry;
                                }
                                else
                                {
                                    Logs.Debug("[SadegelCore] Error al carregar COUNTRY " + IsoCode + " no existeix");
                                    return null;
                                }

                            }

                        }

                    }
                }
                else
                {
                    Logs.Debug("[SadegelCore] Ja existeix COUNTRY " + IsoCode + " retornant objecte");
                    return CountryLoaded;
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar COUNTRY " + IsoCode);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// Loads all the countries from the database into the country pool
        /// </summary>
        /// <returns></returns>
        public static bool LoadAll()
        {
            try
            {
                // Clear country pool
                Globals.CountryPool.Clear();

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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_COUNTRY";

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {
                                Country NewCountry = new Country();
                                NewCountry.IsoCode = TempReader.GetString("isoCode");
                                NewCountry.Name = TempReader.GetString("countryName");

                                // Add new country to the global pool
                                Globals.CountryPool.Add(NewCountry);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar COUNTRYs");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Updates country data
        /// </summary>
        /// <returns>true if ok, false if fail</returns>
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_COUNTRY SET countryName = @Name WHERE isoCode = @IsoCode";
                        TempCmd.Parameters.AddWithValue("@IsoCode", this.IsoCode);
                        TempCmd.Parameters.AddWithValue("@Name", this.Name);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Actualitzat COUNTRY " + this.IsoCode);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'actualitzar COUNTRY " + this.IsoCode);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'actualitzar COUNTRY " + this.IsoCode);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Deletes the country
        /// </summary>
        /// <returns>true if ok, false if fail</returns>
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
                        TempCmd.CommandText = "DELETE FROM SADEGEL_STOCK_COUNTRY WHERE isoCode = @IsoCode";
                        TempCmd.Parameters.AddWithValue("@IsoCode", this.IsoCode);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Globals.CountryPool.Remove(this);
                            Logs.Debug("[SadegelCore] Eliminat COUNTRY " + this.IsoCode);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar COUNTRY " + this.IsoCode);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar COUNTRY " + this.IsoCode);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Try to get the country from the pool by its code
        /// </summary>
        /// <param name="IsoCode">The country iso code</param>
        /// <returns>The country object or null if not found</returns>
        public static Country FindByCode(string IsoCode)
        {
            return Globals.CountryPool.Find(x => x.IsoCode == IsoCode);
        }

        /// <summary>
        /// Try to get the country from the pool by its name
        /// </summary>
        /// <param name="Name">The country name</param>
        /// <returns>The country object or null if not found</returns>
        public static Country FindByName(string Name)
        {
            return Globals.CountryPool.Find(x => x.Name == Name);
        }
    }
}
