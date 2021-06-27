/**
 *  Sadegel Bot (SadegelStock) - Misc.cs
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
using Microsoft.Win32;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace SadegelBot
{
    public class Misc
    {
        /// <summary>
        /// Sets or deletes a registry key for auto startup
        /// </summary>
        /// <param name="toggle">true if set, false if delete</param>
        public static void SetStartup(bool toggle)
        {
            string CodeBase = Assembly.GetExecutingAssembly().CodeBase;
            string Name = Path.GetFileName(CodeBase);
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (toggle)
            {
                RegKey.SetValue(Name, CodeBase);
            }
            else
            {
                RegKey.DeleteValue(Name, false);
            }
        }

        public static string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo FileLoc = FileVersionInfo.GetVersionInfo(assembly.Location);
            return FileLoc.FileVersion;
        }
    }
}
