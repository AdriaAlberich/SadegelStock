/**
 *  Sadegel Bot (SadegelStock) - Exchange.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Exchange.WebServices.Autodiscover;
using SadegelCore;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace SadegelBot
{
    public class Exchange
    {
        /// <summary>
        /// Public instance of the Exchange Server service
        /// </summary>
        public static ExchangeService ExchangeInstance;

        /// <summary>
        /// If Exchange connection is active or not
        /// </summary>
        public static bool ExchangeConnected = false;

        /// <summary>
        /// Tries to connect to the Exchange Mail server
        /// </summary>
        public static bool ConnectToExchangeServer()
        {
            try
            {
                ExchangeInstance = new ExchangeService(ExchangeVersion.Exchange2016);
                ExchangeInstance.Credentials = new WebCredentials("sadegeltest@sadegeltest.eu", "Cavall3r2019");
                //ExchangeInstance.AutodiscoverUrl("sadegel@sadegeltest.eu", new AutodiscoverRedirectionUrlValidationCallback((url) => true));
                ExchangeInstance.Url = new Uri("https://ex3.mail.ovh.net/ews/Exchange.asmx");
                Logs.Debug("Connectat al servidor de Exchange de manera satisfactòria");
                ExchangeConnected = true;

                // TEMPORARY WORKAROUND FOR INVALID CERTIFICATES

                // Trust all certificates
                ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);

                return true;
            }
            catch (Exception e)
            {
                Logs.Debug("Error al connectar al servidor de Exchange amb les credencials donades");
                Logs.Debug(e.Message);
                ExchangeConnected = false;
                return false;
            }
        }

        public static void ProcessNewEmails()
        {
            try
            {
                SearchFilter SearchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
                FindItemsResults<Item> FindResults = ExchangeInstance.FindItems(WellKnownFolderName.Inbox, SearchFilter, new ItemView(128));
                if (FindResults.TotalCount > 0)
                {
                    ServiceResponseCollection<GetItemResponse> Items = ExchangeInstance.BindToItems(FindResults.Select(Item => Item.Id), new PropertySet(BasePropertySet.FirstClassProperties, EmailMessageSchema.From, EmailMessageSchema.ToRecipients, EmailMessageSchema.IsRead));
                    Logs.Debug("Trobats: " + Items.Count + " correus sense llegir.");
                    foreach (GetItemResponse Item in Items)
                    {
                        ProcessEmail(Item);
                    }
                }
                else
                {
                    Logs.Debug("No hi ha emails nous.");
                }
            }
            catch (Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
            }
        }

        public static void ProcessEmail(GetItemResponse Email)
        {
            // Modificació massiva d'estoc
            if (Email.Item.Subject.Contains("Modificacion") && Email.Item.Subject.Contains("Stock") && !Email.Item.Subject.Contains("SADEGELBOT"))
            {
                Shop Shop = null;
                Logs.Debug("PROCESSANT NOU EMAIL: " + Email.Item.Subject);
                if (Email.Item.HasAttachments)
                {
                    Logs.Debug("Llegint fitxers adjunts");
                    foreach (Attachment Attachment in Email.Item.Attachments)
                    {
                        if (Attachment is FileAttachment)
                        {
                            FileAttachment FileAttachment = Attachment as FileAttachment;
                            if (FileAttachment.Name.Contains(".xlsx"))
                            {
                                Logs.Debug("Revisant adjunt: " + FileAttachment.Name);
                                string ShopName = FileAttachment.Name.Replace(".xlsx", "");

                                Shop = Shop.FindByName(ShopName);

                                if(Shop != null)
                                {
                                    string TempPath = Path.GetTempPath() + FileAttachment.Name;
                                    FileAttachment.Load(TempPath);
                                    Logs.Debug("Descarregat adjunt: " + TempPath);
                                    break;
                                }
                            }
                        }
                    }

                    if(Shop != null)
                    {
                        ReadAlgorithms.Execute(ReadAlgorithms.Type.StockModification, Shop);
                        //Email.Item.Subject = Email.Item.Subject + " [SADEGELBOT]";
                        //Email.Item.Update(ConflictResolutionMode.AutoResolve);
                    }
                    else
                    {
                        Logs.Debug("No s'ha trobat cap adjunt de modificació massiu o no està ben formatejat.");
                    }
                }
                else
                {
                    Logs.Debug("No s'han trobat adjunts.");
                }
            }

            // TPV Espanya
            if (Email.Item.Subject.Contains("Cierre de la caja") && !Email.Item.Subject.Contains("SADEGELBOT"))
            {
                Logs.Debug("PROCESSANT NOU EMAIL: " + Email.Item.Subject);
                string ShopName = ((EmailAddress)Email.Item[EmailMessageSchema.From]).Name;
                Logs.Debug("Nom establiment: " + ShopName);
                Shop Shop = Shop.FindByName(ShopName);
                if (Shop != null)
                {
                    Logs.Debug("TROBAT ESTABLIMENT: " + ShopName);
                    if (Email.Item.HasAttachments)
                    {
                        Logs.Debug("Llegint fitxers adjunts");
                        bool HasCierresDeCaja = false;
                        bool HasCierresDeCajaAmpliado = false;
                        bool Valid = false;
                        foreach (Attachment Attachment in Email.Item.Attachments)
                        {
                            bool Download = false;
                            if (Attachment is FileAttachment)
                            {
                                FileAttachment FileAttachment = Attachment as FileAttachment;
                                if (FileAttachment.Name.Contains(".pdf"))
                                {
                                    if (FileAttachment.Name.Contains("Cierres de caja ampliado.pdf"))
                                    {
                                        HasCierresDeCajaAmpliado = true;
                                        Download = true;
                                    }

                                    if (FileAttachment.Name.Contains("Cierres de caja.pdf"))
                                    {
                                        HasCierresDeCaja = true;
                                        Download = true;
                                    }

                                    if (Download)
                                    {
                                        string TempPath = Path.GetTempPath() + FileAttachment.Name;
                                        FileAttachment.Load(TempPath);
                                        Logs.Debug("Descarregat adjunt: " + TempPath);
                                        Valid = true;
                                    }
                                }
                            }
                        }

                        if (Valid)
                        {
                            ReadAlgorithms.Execute(ReadAlgorithms.Type.Spain, Shop, HasCierresDeCaja, HasCierresDeCajaAmpliado);
                            //Email.Item.Subject = Email.Item.Subject + " [SADEGELBOT]";
                            //Email.Item.Update(ConflictResolutionMode.AutoResolve);
                        }
                        else
                        {
                            Logs.Debug("No s'ha trobat cap adjunt de tancament de caixa vàlid.");
                        }
                    }
                    else
                    {
                        Logs.Debug("No s'han trobat adjunts.");
                    }
                }
                else
                {
                    Logs.Debug("Establiment " + ShopName + " no existeix.");
                }
            }
        }
    }
}
