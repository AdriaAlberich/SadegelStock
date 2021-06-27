/**
 *  Sadegel Core (SadegelStock) - Product.cs
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
    /// Product class
    /// </summary>
    public class Product
    {

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Weight { get; set; }
        public string BaseUnit { get; set; }
        public ProductCategory Category { get; set; }
        public bool isIcecream { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<string> Identifiers { get; set; }
        public List<ProductProvider> ProductProviders { get; set; }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="Name">The product name</param>
        /// <param name="Type">The product type</param>
        /// <param name="Weight">The product weight</param>
        /// <param name="BaseUnit">The product base unit</param>
        /// <param name="Category">The product category</param>
        /// <param name="MainIdentifier">The product main identifier</param>
        /// <param name="ProductProvider">The product provider object</param>
        /// <returns>The product object</returns>
        public static Product Create(string Name, string Type, float Weight, string BaseUnit, ProductCategory Category, bool IsIcecream, string MainIdentifier)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_PRODUCT (productName, type, weight, baseunit, categoryName, isIcecream) " +
                            "VALUES (@Name, @Type, @Weight, @BaseUnit, @CategoryName, @IsIcecream)";
                        TempCmd.Parameters.AddWithValue("@Name", Name);
                        TempCmd.Parameters.AddWithValue("@Type", Type);
                        TempCmd.Parameters.AddWithValue("@Weight", Weight);
                        TempCmd.Parameters.AddWithValue("@BaseUnit", BaseUnit);
                        TempCmd.Parameters.AddWithValue("@CategoryName", Category.Name);
                        TempCmd.Parameters.AddWithValue("@IsIcecream", IsIcecream);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            uint NewProductId = (uint)TempCmd.LastInsertedId;
                            Logs.Debug("[SadegelCore] Creat PRODUCT " + Name + ", TYPE: " + Type + ", CATEGORY: " + Category.Name);

                            TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_PRODUCT_IDENTIFIER (productId, identifier) VALUES (@Id, @MainIdentifier)";
                            TempCmd.Parameters.AddWithValue("@Id", NewProductId);
                            TempCmd.Parameters.AddWithValue("@MainIdentifier", MainIdentifier);
                            if (TempCmd.ExecuteNonQuery() > 0)
                            {

                                // Try to load the new product
                                Product NewProduct = Load(NewProductId);

                                return NewProduct;
                            }
                            else
                            {
                                Logs.Debug("[SadegelCore] Error al insertar PRODUCT IDENTIFIER " + NewProductId + " " + MainIdentifier);
                                return null;
                            }
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error al crear PRODUCT " + Name + " " + Type);
                            return null;
                        }

                    }

                }

            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al crear PRODUCT " + Name + " " + Type);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Loads a product from database
        /// </summary>
        /// <param name="Id">The product id</param>
        /// <returns>The product object</returns>
        public static Product Load(uint Id)
        {
            try
            {
                Product ProductLoaded = FindById(Id);
                if (ProductLoaded == null)
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
                            TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PRODUCT WHERE id = @Id AND isDeleted = 0";
                            TempCmd.Parameters.AddWithValue("@Id", Id);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                if (TempReader.Read())
                                {

                                    // New product
                                    Product NewProduct = new Product();

                                    NewProduct.Id = TempReader.GetUInt32("id");
                                    NewProduct.Name = TempReader.GetString("productName");
                                    NewProduct.Type = TempReader.GetString("type");
                                    NewProduct.Weight = TempReader.GetFloat("weight");
                                    NewProduct.BaseUnit = TempReader.GetString("baseunit");
                                    NewProduct.Category = ProductCategory.FindByName(TempReader.GetString("categoryName"));
                                    NewProduct.isIcecream = TempReader.GetBoolean("IsIcecream");
                                    NewProduct.CreatedAt = TempReader.GetDateTime("createdAt");
                                    NewProduct.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                    NewProduct.Identifiers = GetIdentifiersFromProductId(NewProduct.Id);

                                    return NewProduct;
                                }
                                else
                                {
                                    Logs.Debug("[SadegelCore] Error al carregar PRODUCT " + Id);
                                    return null;
                                }

                            }

                        }

                    }
                }
                else
                {
                    return ProductLoaded;
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar PRODUCT " + Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// Loads all available products from database
        /// </summary>
        /// <returns>true is success, false otherwise</returns>
        public static bool LoadAll()
        {
            try
            {
                // Clear product pool
                Globals.ProductPool.Clear();

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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PRODUCT WHERE isDeleted = 0";

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {

                                // New product
                                Product NewProduct = new Product();

                                NewProduct.Id = TempReader.GetUInt32("id");
                                NewProduct.Name = TempReader.GetString("productName");
                                NewProduct.Type = TempReader.GetString("type");
                                NewProduct.Weight = TempReader.GetFloat("weight");
                                NewProduct.BaseUnit = TempReader.GetString("baseunit");
                                NewProduct.Category = ProductCategory.FindByName(TempReader.GetString("categoryName"));
                                NewProduct.isIcecream = TempReader.GetBoolean("IsIcecream");
                                NewProduct.CreatedAt = TempReader.GetDateTime("createdAt");
                                NewProduct.UpdatedAt = TempReader.GetDateTime("updatedAt");

                                NewProduct.Identifiers = GetIdentifiersFromProductId(NewProduct.Id);

                                // Add new product to the global pool
                                Globals.ProductPool.Add(NewProduct);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar PRODUCTs");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Updates the product
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_PRODUCT SET productName = @Name, type = @Type, weight = @Weight, baseunit = @BaseUnit, categoryName = @CategoryName, isIcecream = @IsIcecream WHERE id = @Id";
                        TempCmd.Parameters.AddWithValue("@Name", this.Name);
                        TempCmd.Parameters.AddWithValue("@Type", this.Type);
                        TempCmd.Parameters.AddWithValue("@Weight", this.Weight);
                        TempCmd.Parameters.AddWithValue("@BaseUnit", this.BaseUnit);
                        TempCmd.Parameters.AddWithValue("@CategoryName", this.Category.Name);
                        TempCmd.Parameters.AddWithValue("@IsIcecream", this.isIcecream);

                        TempCmd.Parameters.AddWithValue("@Id", this.Id);

                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Actualitzat PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'actualitzar PRODUCT " + this.Id);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció a l\'actualitzar PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Deletes the product
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_PRODUCT SET isDeleted = 1 WHERE id = @Id";
                        TempCmd.Parameters.AddWithValue("@Id", this.Id);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Globals.ProductPool.Remove(this);
                            Logs.Debug("[SadegelCore] Eliminat PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar PRODUCT " + this.Id);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Returns a product from its id (already loaded)
        /// </summary>
        /// <param name="Id">The product id</param>
        /// <returns>The product object</returns>
        public static Product FindById(uint Id)
        {
            return Globals.ProductPool.Find(x => x.Id == Id);
        }

        /// <summary>
        /// Returns a product from part of its name
        /// </summary>
        /// <param name="Name">The product name or part of it</param>
        /// <returns>The product object</returns>
        public static Product FindByNamePart(string Name)
        {
            return Globals.ProductPool.Find(x => x.Name.Contains(Name));
        }

        /// <summary>
        /// Returns a product from its name
        /// </summary>
        /// <param name="Name">The product name</param>
        /// <returns>The product object</returns>
        public static Product FindByName(string Name)
        {
            return Globals.ProductPool.Find(x => x.Name == Name);
        }

        /// <summary>
        /// Adds a unique identifier to the product
        /// </summary>
        /// <param name="Identifier">The identifier as string</param>
        /// <returns>true if success, false otherwise</returns>
        public bool AddIdentifier(string Identifier)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_PRODUCT_IDENTIFIER VALUES (@Id, @Identifier)";
                        TempCmd.Parameters.AddWithValue("@Id", Id);
                        TempCmd.Parameters.AddWithValue("@Identifier", Identifier);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Afegir identificador " + Identifier + " per a PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'afegir identificador " + Identifier + " per a PRODUCT " + this.Id + ". Probablement duplicat.");
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Error a l\'afegir identificador " + Identifier + " per a PRODUCT " + this.Id + ". Probablement duplicat.");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Removes a identifier from the product
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public bool RemoveIdentifier(string Identifier)
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
                        TempCmd.CommandText = "DELETE FROM SADEGEL_STOCK_PRODUCT_IDENTIFIER WHERE identifier IS @Identifier";
                        TempCmd.Parameters.AddWithValue("@Id", this.Id);
                        TempCmd.Parameters.AddWithValue("@Identifier", Identifier);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Eliminat identificador " + Identifier + " per a PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l'eliminar identificador " + Identifier + " per a PRODUCT " + this.Id);
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Error a l'eliminar identificador " + Identifier + " per a PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Returns a list of product identifiers
        /// </summary>
        /// <param name="Id">The product id</param>
        /// <returns>List of strings, null if error, empty if no identifiers (anomaly situation)</returns>
        public static List<string> GetIdentifiersFromProductId(uint Id)
        {
            try
            {
                // Define a new list
                List<string> Identifiers = new List<string>();

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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PRODUCT_IDENTIFIER WHERE productId = @Id";
                        TempCmd.Parameters.AddWithValue("@Id", Id);

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {
                                string Identifier = TempReader.GetString("identifier");

                                // Add new identifier to the list
                                Identifiers.Add(Identifier);
                            }
                        }
                    }
                }

                return Identifiers;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar PRODUCT IDENTIFIER");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Returns a list of product providers
        /// </summary>
        /// <param name="Id">The product id</param>
        /// <returns>List of product providers, null if error, empty if no providers (anomaly situation)</returns>
        public static List<ProductProvider> GetProvidersFromProductId(uint Id)
        {
            try
            {
                Product Product = FindById(Id);

                if(Product != null)
                {
                    // Define a new list
                    List<ProductProvider> ProductProviders = new List<ProductProvider>();

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
                            TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PRODUCT_PROVIDER WHERE productId = @Id";
                            TempCmd.Parameters.AddWithValue("@Id", Id);

                            // Reader
                            using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                            {
                                while (TempReader.Read())
                                {
                                    Provider Provider = Provider.FindByName(TempReader.GetString("providerName"));
                                    float Price = TempReader.GetFloat("price");
                                    string Currency = TempReader.GetString("currency");

                                    ProductProvider NewProductProvider = new ProductProvider();
                                    NewProductProvider.Product = Product;
                                    NewProductProvider.Provider = Provider;
                                    NewProductProvider.Price = Price;
                                    NewProductProvider.Currency = Currency;

                                    // Add new product provider to the list
                                    ProductProviders.Add(NewProductProvider);
                                }
                            }
                        }
                    }
                    return ProductProviders;
                }

                Logs.Debug("[SadegelCore] Error al carregar PRODUCT PROVIDER, PRODUCT(Id) no es valid.");
                return null;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al carregar PRODUCT PROVIDER");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Returns a list of ingredients and quantities to produce one unit of the product
        /// </summary>
        /// <param name="Id">The product id</param>
        /// <returns>List of product providers, null if error, empty if no providers (anomaly situation)</returns>
        public List<ProductAmount> GetIngredients()
        {
            try
            {
                // Define a new list
                List<ProductAmount> Ingredients = new List<ProductAmount>();

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
                        TempCmd.CommandText = "SELECT * FROM SADEGEL_STOCK_PRODUCT_INGREDIENT WHERE manufacturedProductId = @ManufacturedProductId";
                        TempCmd.Parameters.AddWithValue("@ManufacturedProductId", Id);

                        // Reader
                        using (MySqlDataReader TempReader = TempCmd.ExecuteReader())
                        {
                            while (TempReader.Read())
                            {
                                Product RawIngredient = FindById(TempReader.GetUInt32("ingredientProductId"));
                                float RawQuantity = TempReader.GetFloat("ingredientQuantity");
                                bool RawUnit = TempReader.GetBoolean("unit");

                                ProductAmount NewIngredient = new ProductAmount();
                                NewIngredient.Product = RawIngredient;
                                NewIngredient.Amount = RawQuantity;

                                // Add new product ingredient to the list
                                Ingredients.Add(NewIngredient);
                            }
                        }
                    }
                }

                return Ingredients;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al calcular ingredients per a PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Add an ingredient quantity for a manufactured product
        /// </summary>
        /// <param name="Ingredient">The ingredient</param>
        /// <param name="Quantity">The quantity</param>
        /// <returns>true if success, false otherwise</returns>
        public bool AddIngredient(Product Ingredient, float Quantity, bool Unit = true)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_PRODUCT_INGREDIENT VALUES (@IngredientProductId, @ManufacturedProductId, @IngredientQuantity, @unit)";
                        TempCmd.Parameters.AddWithValue("@ManufacturedProductId", Id);
                        TempCmd.Parameters.AddWithValue("@IngredientProductId", Ingredient.Id);
                        TempCmd.Parameters.AddWithValue("@IngredientQuantity", Quantity);
                        TempCmd.Parameters.AddWithValue("@Unit", Unit);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Afegir ingredient " + Ingredient.Id + " per a PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'afegir ingredient " + Ingredient.Id + " per a PRODUCT " + this.Id);
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al afegir ingredient per a PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Update the ingredient quantity of a product
        /// </summary>
        /// <param name="Ingredient">The ingredient</param>
        /// <param name="NewQuantity">The new ingredient quantity</param>
        /// <returns>true if success, false otherwise</returns>
        public bool UpdateIngredientQuantity(Product Ingredient, float NewQuantity, bool NewUnit)
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
                        TempCmd.CommandText = "UPDATE SADEGEL_STOCK_PRODUCT_INGREDIENT SET ingredientQuantity = @NewQuantity, unit = @NewUnit WHERE ingredientProductId = @IngredientProductId AND manufacturedProductId = @ManufacturedProductId";
                        TempCmd.Parameters.AddWithValue("@ManufacturedProductId", this.Id);
                        TempCmd.Parameters.AddWithValue("@IngredientProductId", Ingredient.Id);
                        TempCmd.Parameters.AddWithValue("@NewQuantity", NewQuantity);
                        TempCmd.Parameters.AddWithValue("@NewUnit", NewUnit);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Actualitzat ingredient de PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'actualitzar ingredient de PRODUCT " + this.Id);
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al actualitzar ingredient de PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Removes a product ingredient from database
        /// </summary>
        /// <param name="Ingredient">The ingredient</param>
        /// <returns>true if success, false otherwise</returns>
        public bool RemoveIngredient(Product Ingredient)
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
                        TempCmd.CommandText = "DELETE FROM SADEGEL_STOCK_PRODUCT_INGREDIENT WHERE ingredientProductId = @IngredientProductId AND manufacturedProductId = @ManufacturedProductId";
                        TempCmd.Parameters.AddWithValue("@ManufacturedProductId", this.Id);
                        TempCmd.Parameters.AddWithValue("@IngredientProductId", Ingredient.Id);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Eliminat ingredient de PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar ingredient de PRODUCT " + this.Id);
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar ingredient de PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// Add a provider for the product
        /// </summary>
        /// <param name="Provider">The provider</param>
        /// <param name="Price">The price</param>
        /// <param name="Currency">The currency</param>
        /// <returns>true if success, false otherwise</returns>
        public bool AddProvider(Provider Provider, float Price, string Currency)
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
                        TempCmd.CommandText = "INSERT INTO SADEGEL_STOCK_PRODUCT_PROVIDER VALUES (@Id, @ProviderName, @Price, @Currency)";
                        TempCmd.Parameters.AddWithValue("@Id", Id);
                        TempCmd.Parameters.AddWithValue("@ProviderName", Provider.Name);
                        TempCmd.Parameters.AddWithValue("@Price", Price);
                        TempCmd.Parameters.AddWithValue("@Currency", Currency);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Afegir PROVIDER " + Provider.Name + " per a PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'afegir PROVIDER " + Provider.Name + " per a PRODUCT " + this.Id);
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al afegir PROVIDER per a PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Removes a provider from product
        /// </summary>
        /// <param name="Provider">The provider</param>
        /// <returns>true if success, false otherwise</returns>
        public bool RemoveProvider(Provider Provider)
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
                        TempCmd.CommandText = "DELETE FROM SADEGEL_STOCK_PRODUCT_PROVIDER WHERE productId = @Id AND providerName = @ProviderName";
                        TempCmd.Parameters.AddWithValue("@Id", Id);
                        TempCmd.Parameters.AddWithValue("@ProviderName", Provider.Name);

                        // Check result
                        if (TempCmd.ExecuteNonQuery() > 0)
                        {
                            Logs.Debug("[SadegelCore] Eliminat PROVIDER de PRODUCT " + this.Id);
                            return true;
                        }
                        else
                        {
                            Logs.Debug("[SadegelCore] Error a l\'eliminar PROVIDER de PRODUCT " + this.Id);
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logs.Debug("[SadegelCore] Excepció al eliminar PROVIDER de PRODUCT " + this.Id);
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                return false;
            }

        }
    }
}
