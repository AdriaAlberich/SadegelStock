/**
 *  Sadegel Core (SadegelStock) - Provider.cs
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
    /// Provider class
    /// </summary>
    public class Provider
    {
        public string Name { get; set; }
        public string Id { get; set; } // NIF / CIF
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public Country Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Creates a new provider
        /// </summary>
        /// <param name="Name">The provider name</param>
        /// <param name="Id">The provider Id (NIF or CIF)</param>
        /// <param name="Email">The provider email</param>
        /// <param name="Phone">The provider phone</param>
        /// <param name="Address">The provider address</param>
        /// <param name="Country">The provider country</param>
        /// <returns>The provider object</returns>
        public static Provider Create(string Name, string Id, string Email, string Phone, Address Address, Country Country)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_PROVIDER (providerName, id, email, phone, address, countryIsoCode) " +
                            "VALUES (@Name, @Id, @Email, @Phone, @Address, @CountryIsoCode)";
                        TempCmd.Parameters.AddWithValue("@Name", Name);
                        TempCmd.Parameters.AddWithValue("@Id", Id);
                        TempCmd.Parameters.AddWithValue("@Email", Email);
                        TempCmd.Parameters.AddWithValue("@Phone", Phone);
                        TempCmd.Parameters.AddWithValue("@Address", Address.Serialize());
                        TempCmd.Parameters.AddWithValue("@CountryIsoCode", Country.IsoCode);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Creat PROVIDER " + Name + ", ID: " + Id);
                            Provider NewProvider = Load(Name);
                            return NewProvider;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error al crear PROVIDER " + Name);
                            return null;
                        }

                    }

                }

            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al crear PROVIDER " + Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Loads a provider from database
        /// </summary>
        /// <param name="Name">The provider name</param>
        /// <returns>The provider object</returns>
        public static Provider Load(string Name)
        {
            try
            {
                Provider ProviderLoaded = FindByName(Name);
                if (ProviderLoaded == null)
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
                            TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PROVIDER WHERE providerName = @Name AND isDeleted = 0";
                            TempCmd.Parameters.AddWithValue("@Name", Name);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {

                                    // New provider
                                    Provider NewProvider = new Provider();

                                    NewProvider.Name = TempReader.GetString("providerName");
                                    NewProvider.Id = TempReader.GetString("id");
                                    NewProvider.Email = TempReader.GetString("email");
                                    NewProvider.Phone = TempReader.GetString("phone");
                                    NewProvider.Address = Address.Deserialize(TempReader.GetString("address"));
                                    NewProvider.Country = Country.FindByCode(TempReader.GetString("countryIsoCode"));
                                    NewProvider.CreatedAt = TempReader.GetDateTime("createdAt");
                                    NewProvider.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                    return NewProvider;
                                }
                                else
                                {
                                    Logs.Debug("[SadegelCore] Error al carregar PROVIDER " + Name);
                                    return null;
                                }

                            }

                        }

                    }
                }
                else
                {
                    return ProviderLoaded;
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar PROVIDER " + Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// Loads all providers from database
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public static bool LoadAll()
        {
            try
            {
                // Clear provider pool
                Globals.ProviderPool.Clear();

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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PROVIDER WHERE isDeleted = 0";

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {

                                // New provider
                                Provider NewProvider = new Provider();

                                NewProvider.Name = TempReader.GetString("providerName");
                                NewProvider.Id = TempReader.GetString("id");
                                NewProvider.Email = TempReader.GetString("email");
                                NewProvider.Phone = TempReader.GetString("phone");
                                NewProvider.Address = Address.Deserialize(TempReader.GetString("address"));
                                NewProvider.Country = Country.FindByCode(TempReader.GetString("countryIsoCode"));
                                NewProvider.CreatedAt = TempReader.GetDateTime("createdAt");
                                NewProvider.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                // Add new provider to the global pool
                                Globals.ProviderPool.Add(NewProvider);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar PROVIDERs");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Updates the provider
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_PROVIDER SET email = @Email, phone = @Phone, address = @Address, countryIsoCode = @CountryIsoCode WHERE providerName = @Name";
                        TempCmd.Parameters.AddWithValue("@Email", this.Email);
                        TempCmd.Parameters.AddWithValue("@Phone", this.Phone);
                        TempCmd.Parameters.AddWithValue("@Address", this.Address.Serialize());
                        TempCmd.Parameters.AddWithValue("@CountryIsoCode", this.Country.IsoCode);

                        TempCmd.Parameters.AddWithValue("@Name", this.Name);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Actualitzat PROVIDER " + this.Name);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'actualitzar PROVIDER " + this.Name);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'actualitzar PROVIDER " + this.Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Deletes the provider
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_PROVIDER SET isDeleted = 1 WHERE providerName = @Name";
                        TempCmd.Parameters.AddWithValue("@Name", this.Name);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Globals.ProviderPool.Remove(this);
                            Logs.Debug("[SadegelCore] Eliminat PROVIDER " + this.Name);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar PROVIDER " + this.Name);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar PROVIDER " + this.Name);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Returns a provider from part of its name
        /// </summary>
        /// <param name="Name">The provider name or part of it</param>
        /// <returns>The provider object</returns>
        public static Provider FindByNamePart(string Name)
        {
            return Globals.ProviderPool.Find(x => x.Name.Contains(Name));
        }

        /// <summary>
        /// Returns a provider from its name
        /// </summary>
        /// <param name="Name">The provider name</param>
        /// <returns>The provider object</returns>
        public static Provider FindByName(string Name)
        {
            return Globals.ProviderPool.Find(x => x.Name == Name);
        }
    }
}
