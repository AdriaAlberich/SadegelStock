/**
 *  Sadegel Core (SadegelStock) - User.cs
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
    /// User class
    /// </summary>
    public class User
    {
        public string UserName { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Position { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Name"></param>
        /// <param name="Surname"></param>
        /// <param name="Position"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public static User Create(string UserName, string Name = null, string Surname = null, string Position = null, Role Role = null, string Password = null)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_USER (userName, realName, surname, position, roleName, password) " +
                            "VALUES (@UserName, @Name, @Surname, @Position, @RoleName, @Password)";
                        TempCmd.Parameters.AddWithValue("@UserName", UserName);
                        TempCmd.Parameters.AddWithValue("@Name", Name);
                        TempCmd.Parameters.AddWithValue("@Surname", Surname);
                        TempCmd.Parameters.AddWithValue("@Position", Position);
                        TempCmd.Parameters.AddWithValue("@RoleName", Role == null ? null : Role.RoleName);
                        TempCmd.Parameters.AddWithValue("@Password", Password == null ? null : Util.ComputeSha256Hash(Password));

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Creat USER " + UserName);
                            User NewUser = Load(UserName);
                            return NewUser;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error al crear USER " + UserName);
                            return null;
                        }

                    }

                }

            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al crear USER " + UserName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Loads a user from database
        /// </summary>
        /// <param name="UserName">The username</param>
        /// <returns>The user object</returns>
        public static User Load(string UserName)
        {
            try
            {
                User UserLoaded = FindByName(UserName);
                if (UserLoaded == null)
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
                            TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_USER WHERE userName = @UserName AND isDeleted = 0";
                            TempCmd.Parameters.AddWithValue("@UserName", UserName);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {

                                    // New user
                                    User NewUser = new User();

                                    NewUser.UserName = TempReader.GetString("userName");
                                    NewUser.Name = TempReader.GetString("realName");
                                    NewUser.Surname = TempReader.GetString("surname");
                                    NewUser.Position = TempReader.GetString("position");
                                    NewUser.Role = Role.FindByName(TempReader.GetString("roleName"));
                                    NewUser.CreatedAt = TempReader.GetDateTime("createdAt");
                                    NewUser.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                    return NewUser;
                                }
                                else
                                {
                                    Logs.Debug("[SadegelCore] Error al carregar USER " + UserName);
                                    return null;
                                }

                            }

                        }

                    }
                }
                else
                {
                    return UserLoaded;
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar USER " + UserName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// Loads al users
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public static bool LoadAll()
        {
            try
            {
                // Clear user pool
                Globals.UserPool.Clear();

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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_USER WHERE isDeleted = 0";

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {

                                // New user
                                User NewUser = new User();

                                NewUser.UserName = TempReader.GetString("userName");
                                NewUser.Name = TempReader.GetString("realName");
                                NewUser.Surname = TempReader.GetString("surname");
                                NewUser.Position = TempReader.GetString("position");
                                NewUser.Role = Role.FindByName(TempReader.GetString("roleName"));
                                NewUser.CreatedAt = TempReader.GetDateTime("createdAt");
                                NewUser.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                // Add new user to the global pool
                                Globals.UserPool.Add(NewUser);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar USERs");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Updates the user
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_USER SET realName = @Name, surname = @Surname, position = @Position, roleName = @RoleName WHERE userName = @UserName";
                        TempCmd.Parameters.AddWithValue("@Name", this.Name);
                        TempCmd.Parameters.AddWithValue("@Surname", this.Surname);
                        TempCmd.Parameters.AddWithValue("@Position", this.Position);
                        TempCmd.Parameters.AddWithValue("@RoleName", this.Role.RoleName);

                        TempCmd.Parameters.AddWithValue("@UserName", this.UserName);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Actualitzat USER " + this.UserName);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'actualitzar USER " + this.UserName);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'actualitzar USER " + this.UserName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Deletes a user
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_USER SET isDeleted = 1 WHERE userName = @UserName";
                        TempCmd.Parameters.AddWithValue("@UserName", this.UserName);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Globals.UserPool.Remove(this);
                            Logs.Debug("[SadegelCore] Eliminat USER " + this.UserName);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar USER " + this.UserName);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar USER " + this.UserName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Tries to make login with the given password
        /// </summary>
        /// <param name="Password">The raw password</param>
        /// <returns>1 if success, 0 if fail, -1 if user does not exist, -2 if exception</returns>
        public int MakeLogin(string Password)
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
                        TempCmd.CommandText = "SELECT password FROM SADEGEL_STOCK_USER WHERE userName = @UserName";
                        TempCmd.Parameters.AddWithValue("@UserName", this.UserName);

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            if (TempReader.Read())
                            {

                                string Hash = TempReader.GetString("password");

                                if (Util.ComparePassword(Hash, Password))
                                {
                                    return 1;
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                Logs.Debug("[SadegelCore] Error al fer login amb USER " + this.UserName + ". Usuari no trobat. (esborrat?)");
                                return -1;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al fer login amb USER " + this.UserName);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return -2;
            }
        }

        /// <summary>
        /// Finds a user by part of its name (username)
        /// </summary>
        /// <param name="Name">Part of the username</param>
        /// <returns>The user object</returns>
        public static User FindByNamePart(string Name)
        {
            return Globals.UserPool.Find(x => x.UserName.Contains(Name));
        }

        /// <summary>
        /// Finds a user by its name (username)
        /// </summary>
        /// <param name="Name">the username</param>
        /// <returns>The user object</returns>
        public static User FindByName(string Name)
        {
            return Globals.UserPool.Find(x => x.UserName == Name);
        }
    }
}
