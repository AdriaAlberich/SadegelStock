/**
 *  Sadegel Core (SadegelStock) - Util.cs
 *  
 *  Author: Adrià Alberich Jaume (alberichjaumeadria@gmail.com)
 *  Copyright(c) Sadegel S.L
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Syncfusion.XlsIO;

namespace SadegelCore
{
    /// <summary>
    /// Util class, contains util static methods
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Checks if database connection is alive
        /// </summary>
        /// <returns>True if is alive, false otherwise</returns>
        public static bool CheckDBConnection()
        {
            try
            {
                bool check = false;
                // We instantiate a new disposable connection
                using (MySqlConnection TempConnection = new MySqlConnection())
                {
                    // Try to connect to database
                    TempConnection.ConnectionString = Globals.ConnectionString;
                    TempConnection.Open();
                    // Check if connection returns ping
                    check = TempConnection.Ping();
                }

                return check;
            }
            catch(Exception e)
            {
                Logs.Debug(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Generates a SHA256 hash of the given string
        /// </summary>
        /// <param name="RawData">The string you want to hash</param>
        /// <returns>The hash</returns>
        public static string ComputeSha256Hash(string RawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(RawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares a raw password with the given hash
        /// </summary>
        /// <param name="PasswordHash">The SHA256 hash</param>
        /// <param name="PasswordString">The raw password</param>
        /// <returns>true if equals, false otherwise</returns>
        public static bool ComparePassword(string PasswordHash, string PasswordString)
        {
            return ComputeSha256Hash(PasswordString) == PasswordHash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IList<T> Data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in Data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /// <summary>
        /// Returns bool if string is a number or not
        /// </summary>
        /// <param name="input">The string to test</param>
        /// <returns>True if is numeric, false otherwise</returns>
        public static bool IsNumeric(string Input)
        {
            int Test;
            return int.TryParse(Input, out Test);
        }

        /// <summary>
        /// Reads the first two columns of an Excel document and returns a dictionary key-value
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadExcelReport(string Path)
        {
            Dictionary<string, string> Result = new Dictionary<string, string>();
            try
            {
                // Creates a new instance for ExcelEngine
                ExcelEngine ExcelEngine = new ExcelEngine();

                // Loads or open an existing workbook through Open method of IWorkbooks
                IWorkbook Workbook = ExcelEngine.Excel.Workbooks.Open(Path);

                IWorksheet Sheet = Workbook.Worksheets[0];

                IRange[] Rows = Sheet.Rows;

                for(int Idx = 1; Idx < Rows.Length; Idx++)
                {
                    string Key = Sheet.GetText(Rows[Idx].Row, 1);
                    if(Key != null)
                    {
                        string Value = Sheet.GetText(Rows[Idx].Row, 2);
                        Result.Add(Key, Value);
                    }
                    else
                    {
                        continue;
                    }
                }

                // Close the instance of IWorkbook
                Workbook.Close();

                // Dispose the instance of ExcelEngine
                ExcelEngine.Dispose();
            }
            catch(Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
            }

            return Result;
        }

    }
}
