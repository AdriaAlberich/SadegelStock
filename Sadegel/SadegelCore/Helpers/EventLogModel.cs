/**
 *  Sadegel Core (SadegelStock) - EventLogModel.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SadegelCore
{
    /// <summary>
    /// EventLogModel class
    /// </summary>
    public class EventLogModel
    {
        public string Missatge { get; set; }
        public string Origen { get; set; }
        public string Tipus { get; set; }
        public string PC { get; set; }
        public string Usuari { get; set; }
        public string Establiment { get; set; }
        public string Producte { get; set; }
        public string Quantitat { get; set; }
        public DateTime Data { get; set; }
    }
}
