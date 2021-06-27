/**
 *  Sadegel Bot (SadegelStock) - ReadAlgorithms.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SadegelCore;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace SadegelBot
{
    public class ReadAlgorithms
    {
        public enum Type
        {
            StockModification,
            Spain
        }

        public static void Execute(Type Type, Shop Shop, params object[] Args)
        {
            switch(Type)
            {
                case Type.StockModification:
                    {
                        StockModificationAlgorithm(Shop);
                        break;
                    }
                case Type.Spain:
                    {
                        SpainAlgorithm(Shop, bool.Parse(Args[0].ToString()), bool.Parse(Args[1].ToString()));
                        break;
                    }
            }
        }

        public static void StockModificationAlgorithm(Shop Shop)
        {
            try
            {
                Logs.Debug("PROCESSANT MODIFICACIONS MASSIVES DE STOCK");
                
                int ResultCode = Shop.Inventory.ProcessMassiveStockModification(Path.GetTempPath() + Shop.Name + ".xlsx");
                switch (ResultCode)
                {
                    case -1:
                        {
                            Logs.Debug("Error al realitzar la importació, revisa que el fitxer no tingui errors. No s'ha realitzat cap modificació.");
                            break;
                        }
                    case 0:
                        {
                            Logs.Debug("No s'ha realitzat cap modificació.");
                            break;
                        }
                    default:
                        {
                            Logs.Debug("El fitxer " + Shop.Name + ".xlsx s'ha importat correctament i s'han modificat " + ResultCode + " productes.");
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
            }
        }

        public static void SpainAlgorithm(Shop Shop, bool HasCierresDeCaja, bool HasCierresDeCajaAmpliado)
        {
            try
            {
                Logs.Debug("PROCESSANT TANCAMENTS DE CAIXA TIPUS ESPANYA");
                PdfLoadedDocument Document;
                if (HasCierresDeCaja)
                {
                    if (HasCierresDeCajaAmpliado)
                    {
                        Document = new PdfLoadedDocument(Path.GetTempPath() + "Cierres de caja ampliado.pdf");
                    }
                    else
                    {
                        Document = new PdfLoadedDocument(Path.GetTempPath() + "Cierres de caja.pdf");
                    }

                    Logs.Debug("DETECTAT DOCUMENT");
                    string DocumentText = string.Empty;
                    foreach (PdfPageBase Page in Document.Pages)
                    {
                        string PageText = Page.ExtractText();
                        DocumentText += PageText;
                    }

                    Logs.Debug("PROCESSANT TEXT");
                    DocumentText = string.Join("", DocumentText.Split(new string[] { "VENTAS POR FAMILIA" }, StringSplitOptions.None).Skip(1));

                    string[] DocumentTextArray = DocumentText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    long MainLog = Logs.EventLog("INICI DE TANCAMENT DE CAIXA DE " + Shop.Name, EventLogOrigin.SadegelBot, EventLogType.ShopStockSummary, "SYSTEM", "SYSTEM", (int)Shop.Id);

                    for (int i = 0; i < DocumentTextArray.Length; i++)
                    {
                        foreach(ProductAmount Stock in Shop.Inventory.Content)
                        {
                            foreach(string ProductIdentifier in Stock.Product.Identifiers)
                            {
                                if(DocumentTextArray[i].Trim() == ProductIdentifier)
                                {
                                    int UnitsSold = int.Parse(DocumentTextArray[i + 1]);
                                    // If the product is composed of different products...
                                    /*
                                    List<ProductAmount> Ingredients = Stock.Product.GetIngredients();
                                    if (Ingredients.Count > 0)
                                    {
                                        foreach(ProductAmount Ingredient in Stock.Product.GetIngredients())
                                        {
                                            // Ingredient is in the stock
                                            ProductAmount IngredientStock = Shop.Inventory.Content.Find(x => x.Product == Ingredient.Product);
                                            if (IngredientStock != null)
                                            {
                                                float TotalIngredientQuantity = (Ingredient.Amount * UnitsSold);
                                                if (IngredientStock.Amount > TotalIngredientQuantity)
                                                {
                                                    IngredientStock.Amount -= TotalIngredientQuantity;
                                                    Logs.Debug("Restades " + TotalIngredientQuantity + " de " + IngredientStock.Product.Name + "(ingredient de " + Stock.Product.Name + "), queden " + IngredientStock.Amount);
                                                }
                                                else
                                                {
                                                    if (IngredientStock.Amount - TotalIngredientQuantity == 0)
                                                    {
                                                        Logs.Debug("ATENCIÓ! S'han acabat les existències del producte " + Stock.Product.Name);
                                                    }
                                                    else
                                                    {
                                                        Logs.Debug("ATENCIÓ! Es volen extreure mes unitats del producte " + Stock.Product.Name + " de les que hi ha disponibles actualment, cal comprovar manualment.");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Logs.Debug("ATENCIÓ! El producte " + Ingredient.Product.Name + " que es ingredient de " + Stock.Product.Name + " no existeix a l'stock.");
                                            }
                                        }
                                    }
                                    // The product has no ingredients, so we have to substract full units
                                    else
                                    {
                                        */
                                        if(Globals.Settings["use_of_stock"] == "Si")
                                        {
                                            if (Stock.Amount > UnitsSold)
                                            {
                                                Stock.Amount -= UnitsSold;
                                                Logs.Debug("Restades " + UnitsSold + " de " + Stock.Product.Name + "(" + ProductIdentifier + "), queden " + Stock.Amount + ". Establiment: " + Shop.Name);
                                            }
                                            else
                                            {
                                                if (Stock.Amount - UnitsSold == 0)
                                                {
                                                    Logs.Debug("ATENCIÓ! S'han acabat les existències del producte " + Stock.Product.Name);
                                                }
                                                else
                                                {
                                                    Logs.Debug("ATENCIÓ! Es volen extreure mes unitats del producte " + Stock.Product.Name + " de les que hi ha disponibles actualment, cal comprovar manualment.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Logs.Debug("Restades " + UnitsSold + " de " + Stock.Product.Name + "(" + ProductIdentifier + "). Establiment: " + Shop.Name);
                                        }

                                        Logs.EventLog("Restades " + UnitsSold + " de " + Stock.Product.Name + "(" + ProductIdentifier + "). Establiment: " + Shop.Name, EventLogOrigin.SadegelBot, EventLogType.ShopStockMovement, "SYSTEM", "SYSTEM", (int)Shop.Id, (int)Stock.Product.Id, UnitsSold * -1, MainLog);

                                    //}

                                    i++;
                                    break;
                                }
                            }

                            break;
                        }
                    }

                    Shop.Inventory.Update();

                }
            }
            catch (Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
            }
        }
    }
}
