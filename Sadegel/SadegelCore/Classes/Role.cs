/**
 *  Sadegel Core (SadegelStock) - Role.cs
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
    /// Role class
    /// </summary>
    public class Role
    {
        public string RoleName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Creates a new role
        /// </summary>
        /// <param name="RoleName">The role name</param>
        /// <returns>The role object</returns>
        public static Role Create(string RoleName)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_ROLE (roleName) " +
                            "VALUES (@RoleName)";
                        TempCmd.Parameters.AddWithValue("@RoleName", RoleName);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Creat ROLE " + RoleName);
                            Role NewRole = Load(RoleName);
                            return NewRole;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error al crear ROLE " + RoleName);
                            return null;
                        }

                    }

                }

            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al crear ROLE " + RoleName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Loads a role from database
        /// </summary>
        /// <param name="RoleName">The role name</param>
        /// <returns>The role object</returns>
        public static Role Load(string RoleName)
        {
            try
            {
                Role RoleLoaded = FindByName(RoleName);
                if (RoleLoaded == null)
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
                            TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_ROLE WHERE roleName = @RoleName AND isDeleted = 0";
                            TempCmd.Parameters.AddWithValue("@RoleName", RoleName);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {

                                    // New role
                                    Role NewRole = new Role();

                                    NewRole.RoleName = TempReader.GetString("roleName");
                                    NewRole.IsAdmin = TempReader.GetBoolean("isAdmin");
                                    NewRole.CreatedAt = TempReader.GetDateTime("createdAt");
                                    NewRole.UpdatedAt = TempReader.GetDateTime("updatedAt");
                                   
                                    return NewRole;
                                }
                                else
                                {
                                    Logs.Debug("[SadegelCore] Error al carregar ROLE " + RoleName);
                                    return null;
                                }

                            }

                        }

                    }
                }
                else
                {
                    return RoleLoaded;
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar ROLE " + RoleName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// Loads all roles
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public static bool LoadAll()
        {
            try
            {
                // Clear role pool
                Globals.RolePool.Clear();

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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_ROLE WHERE isDeleted = 0";

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {

                                // New role
                                Role NewRole = new Role();

                                NewRole.RoleName = TempReader.GetString("roleName");
                                NewRole.IsAdmin = TempReader.GetBoolean("isAdmin");
                                NewRole.CreatedAt = TempReader.GetDateTime("createdAt");
                                NewRole.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                // Add new role to the global pool
                                Globals.RolePool.Add(NewRole);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar ROLEs");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Updates the role
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_ROLE SET isAdmin = @IsAdmin WHERE roleName = @RoleName";
                        TempCmd.Parameters.AddWithValue("@IsAdmin", this.IsAdmin);
                        TempCmd.Parameters.AddWithValue("@RoleName", this.RoleName);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Actualitzat ROLE " + this.RoleName);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'actualitzar ROLE " + this.RoleName);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'actualitzar ROLE " + this.RoleName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Deletes the role
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_ROLE SET isDeleted = 1 WHERE roleName = @RoleName";
                        TempCmd.Parameters.AddWithValue("@RoleName", this.RoleName);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Globals.RolePool.Remove(this);
                            Logs.Debug("[SadegelCore] Eliminat ROLE " + this.RoleName);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar ROLE " + this.RoleName);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar ROLE " + this.RoleName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Finds a role by part of its name
        /// </summary>
        /// <param name="Name">The role name</param>
        /// <returns>The role object</returns>
        public static Role FindByNamePart(string Name)
        {
            return Globals.RolePool.Find(x => x.RoleName.Contains(Name));
        }

        /// <summary>
        /// Finds a role by its name
        /// </summary>
        /// <param name="Name">The role name</param>
        /// <returns>The role object</returns>
        public static Role FindByName(string Name)
        {
            return Globals.RolePool.Find(x => x.RoleName == Name);
        }
    }
}
