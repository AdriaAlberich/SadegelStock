/**
 *  Sadegel Bot (SadegelStock) - Program.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using SadegelCore;

namespace SadegelBot
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Error = false;
            Console.Title = "[SADEGEL BOT] Inicialitzant-se...";
            Console.WriteLine("SADEGEL BOT: Inicialitzant-se...");

            if (Util.CheckDBConnection())
            {
                Console.WriteLine("SADEGEL BOT: Connectat amb la base de dades.");
                SadegelCore.Main.Initialize();
                Console.WriteLine("SADEGEL BOT: Inicialitzats registres i configuració global.");
                if (Country.LoadAll())
                {
                    Console.WriteLine("SADEGEL BOT: Carregats països.");
                    if(ProductCategory.LoadAll())
                    {
                        Console.WriteLine("SADEGEL BOT: Carregades categories de productes.");
                        if (Product.LoadAll())
                        {
                            Console.WriteLine("SADEGEL BOT: Carregats productes.");
                            if(Shop.LoadAll())
                            {
                                Console.WriteLine("SADEGEL BOT: Carregats establiments.");
                                if(Exchange.ConnectToExchangeServer())
                                {
                                    Console.WriteLine("SADEGEL BOT: Connectat al servidor Exchange.");
                                    Console.WriteLine("SADEGEL BOT: Iniciant processos de lectura.");
                                    Timers.Initialize();
                                }
                                else
                                {
                                    Console.WriteLine("SADEGEL BOT: Error al connectar al servidor Exchange.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("SADEGEL BOT: Error al carregar productes.");
                            Error = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("SADEGEL BOT: Error al carregar categories de productes.");
                        Error = true;
                    }
                }
                else
                {
                    Console.WriteLine("SADEGEL BOT: Error al carregar països.");
                    Error = true;
                }
            }
            else
            {
                Console.WriteLine("SADEGEL BOT: No es pot connectar amb la base de dades.");
                Error = true;
            }

            if (!Error)
            {
                Console.WriteLine("SADEGEL BOT: Inicialitzat amb èxit.");
                Console.Title = "[SADEGEL BOT] Versió: " + Misc.GetVersion() + " | Connexió Exchange: " + (Exchange.ExchangeConnected ? "activa" : "no activa");
                while(true)
                {
                    Console.WriteLine("SADEGEL BOT: Escriu una comanda:");
                    Commands.ProcessCommand(Console.ReadLine());
                }
            }
            else
            {
                Console.WriteLine("SADEGEL BOT: Inicialitzat amb errors. Prem qualsevol tecla per sortir.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
