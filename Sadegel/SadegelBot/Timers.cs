/**
 *  Sadegel Bot (SadegelStock) - Timers.cs
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
    public class Timers
    {
        private static Timer MinuteTimer;

        public static void Initialize()
        {
            MinuteTimer = new Timer(OnMinute, null, 60000, 60000);
        }

        private static void OnMinute(object none)
        {
            try
            {
                // Reload entities
                Country.LoadAll();
                ProductCategory.LoadAll();
                Provider.LoadAll();
                Product.LoadAll();
                Shop.LoadAll();
            }
            catch(Exception e)
            {
                Logs.Debug("OnMinute TIMER ERROR!!");
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
            }
        }
    }
}
