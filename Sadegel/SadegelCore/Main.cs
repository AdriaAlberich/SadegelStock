/**
 *  Sadegel Core (SadegelStock) - Main.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SadegelCore
{
    /// <summary>
    /// Main class, contains core initialization
    /// </summary>
    public class Main
    {
        public static bool Initialize()
        {
            Logs.Initialize();
            GlobalSettings.Initialize();
            return true;
        }
    }
}