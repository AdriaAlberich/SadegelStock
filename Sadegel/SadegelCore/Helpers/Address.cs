/**
 *  Sadegel Core (SadegelStock) - Address.cs
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
    /// Address class
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The address attributes
        /// </summary>
        public string Street { get; set; }
        public string Number { get; set; }
        public string Floor { get; set; }
        public string Door { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        /// <summary>
        /// Void constructor
        /// </summary>
        public Address()
        {

        }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="Street">The address street name</param>
        /// <param name="Number">The address number</param>
        /// <param name="Floor">The address floor</param>
        /// <param name="Door">The address door</param>
        /// <param name="ZipCode">The address zipcode</param>
        /// <param name="City">The address city name</param>
        public Address(string Street, string Number, string Floor, string Door, string ZipCode, string City)
        {
            this.Street = Street;
            this.Number = Number;
            this.Floor = Floor;
            this.Door = Door;
            this.ZipCode = ZipCode;
        }

        /// <summary>
        /// Deserialize the given string
        /// </summary>
        /// <param name="JsonAddress">The address string as json</param>
        /// <returns>Address object</returns>
        public static Address Deserialize(string JsonAddress)
        {
            try
            {
                Address address = JsonConvert.DeserializeObject<Address>(JsonAddress);
                return address;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Serializes an Address object
        /// </summary>
        /// <returns>The address string as json</returns>
        public string Serialize()
        {
            try
            {
                string address = JsonConvert.SerializeObject(this);
                return address;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
