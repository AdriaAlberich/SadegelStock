/**
 *  Sadegel Bot (SadegelStock) - Commands.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SadegelCore;

namespace SadegelBot
{
    public class Commands
    {
        public static void ProcessCommand(string Input)
        {
            if (Input.Length > 0)
            {
                string[] InputSplitted = Input.Split(' ');
                string Cmd = InputSplitted[0].ToLower();
                List<string> Args = InputSplitted.Skip(1).ToList();

                switch(Cmd)
                {
                    case "instalar":
                        {
                            Misc.SetStartup(true);
                            Console.WriteLine("SADEGEL BOT: Instal·lat correctament en aquest equip.");
                            break;
                        }
                    case "desinstalar":
                        {
                            Misc.SetStartup(false);
                            Console.WriteLine("SADEGEL BOT: Desinstal·lat correctament en aquest equip.");
                            break;
                        }
                    case "processmail":
                        {
                            Exchange.ProcessNewEmails();
                            break;
                        }
                    case "newcountry":
                        {
                            if(Args.Count == 2)
                            {
                                if (Args[0].Length > 0 && Args[1].Length > 0)
                                {
                                    Country.Create(Args[0].Replace('_', ' '), Args[1].Replace('_', ' '));
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'newcountry <iso> <nom>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'newcountry <iso> <nom>'");
                            }
                            break;
                        }
                    case "listcountries":
                        {
                            foreach(Country Country in Globals.CountryPool)
                            {
                                Console.WriteLine("|" + Country.IsoCode + "|" + Country.Name);
                            }
                            break;
                        }
                    case "deletecountry":
                        {
                            if (Args.Count == 1)
                            {
                                if (Args[0].Length > 0)
                                {
                                    Country Country = Country.FindByCode(Args[0].Replace('_', ' '));
                                    if(Country != null)
                                    {
                                        Country.Delete();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'deletecountry <iso>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'deletecountry <iso>'");
                            }
                            break;
                        }
                    case "newprodcategory":
                        {
                            if (Args.Count == 1)
                            {
                                if (Args[0].Length > 0)
                                {
                                    ProductCategory.Create(Args[0].Replace('_', ' '));
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'newprodcategory <nom>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'newprodcategory <nom>'");
                            }
                            break;
                        }
                    case "listprodcategories":
                        {
                            foreach (ProductCategory Category in Globals.ProductCategoryPool)
                            {
                                Console.WriteLine("|" + Category.Name + "|");
                            }
                            break;
                        }
                    case "deleteprodcategory":
                        {
                            if (Args.Count == 1)
                            {
                                if (Args[0].Length > 0)
                                {
                                    ProductCategory Category = ProductCategory.FindByName(Args[0]);
                                    if (Category != null)
                                    {
                                        Category.Delete();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'deleteprodcategory <iso>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'deleteprodcategory <iso>'");
                            }
                            break;
                        }
                    case "newprovider":
                        {
                            if (Args.Count == 11)
                            {
                                if (Args[0].Length > 0 && Args[1].Length > 0 && Args[2].Length > 0 && Args[3].Length > 0 && Args[4].Length > 0 && Args[5].Length > 0 && Args[6].Length > 0 && Args[7].Length > 0 && Args[8].Length > 0 && Args[9].Length > 0 && Args[10].Length > 0)
                                {
                                    Address Address = new Address(Args[4].Replace('_', ' '), Args[5].Replace('_', ' '), Args[6].Replace('_', ' '), Args[7].Replace('_', ' '), Args[8].Replace('_', ' '), Args[9].Replace('_', ' '));
                                    Country Country = Country.FindByCode(Args[10]);
                                    if(Country != null)
                                    {
                                        Provider.Create(Args[0].Replace('_', ' '), Args[1].Replace('_', ' '), Args[2].Replace('_', ' '), Args[3].Replace('_', ' '), Address, Country);
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Country no existeix.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'newprovider <nom> <cif> <email> <telf> <carrer> <numero> <pis> <porta> <codipostal> <ciutat> <codipais>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'newprovider <nom> <cif> <email> <telf> <carrer> <numero> <pis> <porta> <codipostal> <ciutat> <codipais>'");
                            }
                            break;
                        }
                    case "listproviders":
                        {
                            foreach (Provider Provider in Globals.ProviderPool)
                            {
                                Console.WriteLine("|" + Provider.Name + "|" + Provider.Id + "|" + Provider.Email + "|" + Provider.Phone + "|" + Provider.Address.Serialize() + "|" + Provider.Country.Name + "|");
                            }
                            break;
                        }
                    case "deleteprovider":
                        {
                            if (Args.Count == 1)
                            {
                                if (Args[0].Length > 0)
                                {
                                    Provider Provider = Provider.FindByName(Args[0].Replace('_', ' '));
                                    if (Provider != null)
                                    {
                                        Provider.Delete();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'deleteprovider <nom>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'deleteprovider <nom>'");
                            }
                            break;
                        }
                    case "newproduct":
                        {
                            if (Args.Count == 6)
                            {
                                if (Args[0].Length > 0 && Args[1].Length > 0 && Args[2].Length > 0 && Args[3].Length > 0 && Args[4].Length > 0 && Args[5].Length > 0)
                                {
                                    ProductCategory Category = ProductCategory.FindByName(Args[4]);
                                    if (Category != null)
                                    {
                                        Product.Create(Args[0].Replace('_', ' '), Args[1].Replace('_', ' '), float.Parse(Args[2]), Args[3].Replace('_', ' '), Category, Args[5].Replace('_', ' '));
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Categoria no existeix.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'newproduct <nom> <tipus> <pes> <unitat> <categoria> <identificador>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'newproduct <nom> <tipus> <pes> <unitat> <categoria> <identificador>'");
                            }
                            break;
                        }
                    case "listproducts":
                        {
                            foreach (Product Product in Globals.ProductPool)
                            {
                                Console.WriteLine("|" + Product.Id + "|" + Product.Name + "|" + Product.Type + "|" + Product.Weight + "|" + Product.BaseUnit + "|" + Product.Category.Name + "|");
                            }
                            break;
                        }
                    case "deleteproduct":
                        {
                            if (Args.Count == 1)
                            {
                                if (Args[0].Length > 0)
                                {
                                    Product Product = Product.FindById(uint.Parse(Args[0]));
                                    if (Product != null)
                                    {
                                        Product.Delete();
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Producte no trobat");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'deleteproduct <id>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'deleteproduct <id>'");
                            }
                            break;
                        }
                    case "addproductingredient":
                        {
                            if (Args.Count == 3)
                            {
                                if (Args[0].Length > 0 && Args[1].Length > 0 && Args[2].Length > 0)
                                {
                                    Product Product = Product.FindById(uint.Parse(Args[0]));
                                    Product Ingredient = Product.FindById(uint.Parse(Args[1]));
                                    float Amount = float.Parse(Args[2]);
                                    if (Product != null && Ingredient != null)
                                    {
                                        Product.AddIngredient(Ingredient, Amount);
                                        Console.WriteLine("SADEGEL BOT: Afegit ingredient " + Ingredient.Name + "(" + Amount + ") al producte " + Product.Name);
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Producte o ingredient no existeix.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'addproductingredient <producte> <ingredient> <quantitat_ingredient>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'addproductingredient <producte> <ingredient> <quantitat_ingredient>'");
                            }
                            break;
                        }
                    case "removeproductingredient":
                        {
                            if (Args.Count == 2)
                            {
                                if (Args[0].Length > 0 && Args[1].Length > 0)
                                {
                                    Product Product = Product.FindById(uint.Parse(Args[0]));
                                    Product Ingredient = Product.FindById(uint.Parse(Args[1]));
                                    if (Product != null && Ingredient != null)
                                    {
                                        Product.RemoveIngredient(Ingredient);
                                        Console.WriteLine("SADEGEL BOT: Retirat ingredient " + Ingredient.Name + " al producte " + Product.Name);
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Producte o ingredient no existeix.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'removeproductingredient <producte> <ingredient>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'removeproductingredient <producte> <ingredient>'");
                            }
                            break;
                        }
                    case "listproductingredients":
                        {
                            if (Args.Count == 1)
                            {
                                if (Args[0].Length > 0)
                                {
                                    Product Product = Product.FindById(uint.Parse(Args[0]));
                                    if (Product != null)
                                    {
                                        foreach(ProductAmount Ingredient in Product.GetIngredients())
                                        {
                                            Console.WriteLine("|" + Ingredient.Product.Id + "|" + Ingredient.Product.Name + "|" + Ingredient.Amount + "|");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Producte no trobat");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'listproductingredients <id>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'listproductingredients <id>'");
                            }
                            break;
                        }
                    case "newshop":
                        {
                            if (Args.Count == 10)
                            {
                                if (Args[0].Length > 0 && Args[1].Length > 0 && Args[2].Length > 0 && Args[3].Length > 0 && Args[4].Length > 0 && Args[5].Length > 0 && Args[6].Length > 0 && Args[7].Length > 0 && Args[8].Length > 0 && Args[9].Length > 0)
                                {
                                    Address Address = new Address(Args[4].Replace('_', ' '), Args[5].Replace('_', ' '), Args[6].Replace('_', ' '), Args[7], Args[8].Replace('_', ' '), Args[9].Replace('_', ' '));
                                    Country Country = Country.FindByCode(Args[3].Replace('_', ' '));
                                    if (Country != null)
                                    {
                                        Shop.Create(Args[0].Replace('_', ' '), Args[1].Replace('_', ' '), Address, Args[2].Replace('_', ' '), Country);
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Country no existeix.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'newshop <nom> <tipus> <tpv> <codipais> <carrer> <numero> <pis> <porta> <codipostal> <ciutat>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'newshop <nom> <tipus> <tpv> <codipais> <carrer> <numero> <pis> <porta> <codipostal> <ciutat>'");
                            }
                            break;
                        }
                    case "listshops":
                        {
                            foreach (Shop Shop in Globals.ShopPool)
                            {
                                Console.WriteLine("|" + Shop.Id + "|" + Shop.Name + "|" + Shop.Type + "|" + Shop.Tpv + "|" + Shop.Country.Name + "|");
                            }
                            break;
                        }
                    case "deleteshop":
                        {
                            if (Args.Count == 1)
                            {
                                if (Args[0].Length > 0)
                                {
                                    Shop Shop = Shop.FindByName(Args[0].Replace('_', ' '));
                                    if (Shop != null)
                                    {
                                        Shop.Delete();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'deleteshop <nom>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'deleteshop <nom>'");
                            }
                            break;
                        }
                    case "addshopstock":
                        {
                            if (Args.Count == 3)
                            {
                                if (Args[0].Length > 0 && Args[1].Length > 0 && Args[2].Length > 0)
                                {
                                    Shop Shop = Shop.FindById(uint.Parse(Args[0]));
                                    if (Shop != null)
                                    {
                                        Product Product = Product.FindById(uint.Parse(Args[1]));
                                        if(Product != null)
                                        {
                                            float Amount = float.Parse(Args[2]);
                                            if(Amount > 0f)
                                            {
                                                ProductAmount ProductAmount = Shop.Inventory.Content.Find(x => x.Product.Id == Product.Id);
                                                if (ProductAmount != null)
                                                {
                                                    ProductAmount.Amount += Amount;
                                                }
                                                else
                                                {
                                                    ProductAmount = new ProductAmount();
                                                    ProductAmount.Amount = Amount;
                                                    ProductAmount.Product = Product;
                                                    Shop.Inventory.Content.Add(ProductAmount);
                                                    Shop.Inventory.Update();
                                                }

                                                Console.WriteLine("SADEGEL BOT: Afegit " + Amount + " del producte " + Product.Name);
                                            }
                                            else
                                            {
                                                Console.WriteLine("SADEGEL BOT: Quantitat ha de ser un nombre positiu diferent de zero");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("SADEGEL BOT: Producte no existeix");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Establiment no existeix");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'addshopstock <codi_establiment> <codi_producte> <quantitat>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'addshopstock <codi_establiment> <codi_producte> <quantitat>'");
                            }
                            break;
                        }
                    case "removeshopstock":
                        {
                            if (Args.Count == 3)
                            {
                                if (Args[0].Length > 0 && Args[1].Length > 0 && Args[2].Length > 0)
                                {
                                    Shop Shop = Shop.FindById(uint.Parse(Args[0]));
                                    if (Shop != null)
                                    {
                                        Product Product = Product.FindById(uint.Parse(Args[1]));
                                        if (Product != null)
                                        {
                                            float Amount = float.Parse(Args[2]);
                                            if (Amount > 0f)
                                            {
                                                ProductAmount ProductAmount = Shop.Inventory.Content.Find(x => x.Product.Id == Product.Id);
                                                if (ProductAmount != null)
                                                {
                                                    if(ProductAmount.Amount - Amount >= 0f)
                                                    {
                                                        ProductAmount.Amount -= Amount;
                                                        Shop.Inventory.Update();
                                                        Console.WriteLine("SADEGEL BOT: Restat " + Amount + " del producte " + Product.Name);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("SADEGEL BOT: No es pot extreure mes producte del que hi ha en stock: " + ProductAmount.Amount);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("SADEGEL BOT: El producte ja no es en stock, per tant no te sentit retirar-ne");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("SADEGEL BOT: Quantitat ha de ser un nombre positiu diferent de zero");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("SADEGEL BOT: Producte no existeix");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("SADEGEL BOT: Establiment no existeix");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Es 'removeshopstock <codi_establiment> <codi_producte> <quantitat>'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SADEGEL BOT: Es 'removeshopstock <codi_establiment> <codi_producte> <quantitat>'");
                            }
                            break;
                        }
                    case "listshopstock":
                        {
                            if (Args.Count == 1)
                            {
                                if (Args[0].Length > 0)
                                {
                                    Shop Shop = Shop.FindById(uint.Parse(Args[0]));
                                    if (Shop != null)
                                    {
                                        foreach (ProductAmount ProductAmount in Shop.Inventory.Content)
                                        {
                                            Console.WriteLine("|" + ProductAmount.Product.Id + "|" + ProductAmount.Product.Name + "|" + ProductAmount.Amount + (ProductAmount.Product.Type == ProductType.Consumable ? (" u de " + ProductAmount.Product.Weight + ProductAmount.Product.BaseUnit) : (" " + ProductAmount.Product.BaseUnit)) + "|");
                                        }
                                    }
                                }
                            }
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("SADEGEL BOT: Comandes disponibles: instalar, desinstalar, processmail, newcountry, listcountries, deletecountry");
                            Console.WriteLine("SADEGEL BOT: newprodcategory, listprodcategories, deleteprodcategory, newprovider, listproviders, deleteprovider");
                            Console.WriteLine("SADEGEL BOT: newproduct, listproducts, deleteproduct, newshop, listshops, deleteshop, addshopstock, removeshopstock");
                            Console.WriteLine("SADEGEL BOT: listshopstock, addproductingredient, removeproductingredient, listproductingredients");
                            break;
                        }
                }
            }
        }
    }
}
