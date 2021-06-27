using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syncfusion.WinForms.Controls;
using Syncfusion.XlsIO;
using SadegelCore;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;

namespace SadegelStock
{
    public class Excel
    {
        public static void ExportDataGrid(DataTable Data, string SheetName, string DialogTitle)
        {
            using (ExcelEngine ExcelEngine = new ExcelEngine())
            {
                IApplication Application = ExcelEngine.Excel;
                Application.DefaultVersion = ExcelVersion.Excel2016;

                // Create a new workbook
                IWorkbook Workbook = Application.Workbooks.Create(1);
                IWorksheet Sheet = Workbook.Worksheets[0];

                // Import data from the data table with column header, at first row and first column, 
                // and by its column type.
                Sheet.ImportDataTable(Data, true, 1, 1, true);

                // Creating Excel table or list object and apply style to the table
                IListObject Table = Sheet.ListObjects.Create(SheetName, Sheet.UsedRange);

                Table.BuiltInTableStyle = TableBuiltInStyles.TableStyleMedium14;

                // Autofit the columns
                Sheet.UsedRange.AutofitColumns();

                string FilePath = string.Empty;

                bool Save = true;

                using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
                {
                    OpenFileDialog.Title = DialogTitle;
                    OpenFileDialog.InitialDirectory = "c:\\";
                    OpenFileDialog.Filter = "Fitxers Excel (*.xlsx)|*.xlsx";
                    OpenFileDialog.FilterIndex = 2;
                    OpenFileDialog.RestoreDirectory = true;
                    OpenFileDialog.CheckFileExists = false;

                    if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the path of specified file
                        FilePath = OpenFileDialog.FileName;

                        if (File.Exists(FilePath))
                        {
                            DialogResult Response = MessageBox.Show("El fitxer ja existeix. Segur que el vols sobreescriure?", SheetName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (Response == DialogResult.Yes)
                            {
                                Save = true;
                            }
                            else
                            {
                                Save = false;
                            }
                        }

                        if (Save)
                        {
                            // Save the file in the given path
                            Stream ExcelStream = File.Create(FilePath);
                            Workbook.SaveAs(ExcelStream);
                            ExcelStream.Dispose();
                        }
                    }
                }
            }
        }

        public static bool GenerateStockMassiveModificationTemplate(Shop Shop)
        {
            bool Result = false;
            Shop = Shop.Load(Shop.Id);
            try
            {
                using (ExcelEngine ExcelEngine = new ExcelEngine())
                {
                    IApplication Application = ExcelEngine.Excel;
                    Application.DefaultVersion = ExcelVersion.Excel2016;

                    // Create a new workbook
                    IWorkbook Workbook = Application.Workbooks.Create(1);
                    IWorksheet Sheet = Workbook.Worksheets[0];

                    Sheet.Name = "Stock";

                    int CurrentRow = 1;

                    Sheet.InsertColumn(1);
                    Sheet.InsertColumn(2);
                    Sheet.InsertRow(CurrentRow);
                    Sheet.SetText(CurrentRow, 1, "ID Prod");
                    Sheet.SetText(CurrentRow, 2, "Modif");

                    CurrentRow++;

                    foreach (ProductAmount Product in Shop.Inventory.Content)
                    {
                        Sheet.InsertRow(CurrentRow);
                        Sheet.SetText(CurrentRow, 1, Product.Product.Identifiers[0]);
                        Sheet.SetText(CurrentRow, 2, string.Empty);
                        CurrentRow++;
                    }

                    // Autofit the columns
                    Sheet.UsedRange.AutofitColumns();

                    string FilePath = string.Empty;

                    bool Save = true;

                    using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
                    {
                        OpenFileDialog.Title = "Generar Plantilla per modificació massiva";
                        OpenFileDialog.InitialDirectory = "c:\\";
                        OpenFileDialog.Filter = "Fitxers Excel (*.xlsx)|*.xlsx";
                        OpenFileDialog.FilterIndex = 2;
                        OpenFileDialog.RestoreDirectory = true;
                        OpenFileDialog.CheckFileExists = false;
                        OpenFileDialog.FileName = Shop.Name;
                        OpenFileDialog.DefaultExt = ".xlsx";

                        if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Get the path of specified file
                            FilePath = OpenFileDialog.FileName;

                            if (File.Exists(FilePath))
                            {
                                DialogResult Response = MessageBox.Show("El fitxer ja existeix. Segur que el vols sobreescriure?", "Generar Plantilla", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                                if (Response == DialogResult.Yes)
                                {
                                    Save = true;
                                }
                                else
                                {
                                    Save = false;
                                }
                            }

                            if (Save)
                            {
                                // Save the file in the given path
                                Stream ExcelStream = File.Create(FilePath);
                                Workbook.SaveAs(ExcelStream);
                                ExcelStream.Dispose();
                                Result = true;
                            }
                            else
                            {
                                Result = false;
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                Result = false;
            }

            return Result;
        }

        public static bool GenerateIceCreamReport(Shop Shop, DateTime InitialDate, DateTime FinalDate)
        {
            bool Result = false;
            Shop = Shop.Load(Shop.Id);
            try
            {
                using (ExcelEngine ExcelEngine = new ExcelEngine())
                {
                    IApplication Application = ExcelEngine.Excel;
                    Application.DefaultVersion = ExcelVersion.Excel2016;

                    // Create a new workbook (Main)
                    IWorkbook Workbook = Application.Workbooks.Create(3);
                    IWorksheet MainSheet = Workbook.Worksheets[0];

                    MainSheet.Name = "RESUM";

                    int CurrentRow = 1;

                    MainSheet.InsertColumn(1);
                    MainSheet.InsertColumn(2);
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "RESUM DE PRODUCCIÓ DEL " + InitialDate.ToShortDateString() + " AL " + FinalDate.ToShortDateString());
                    CurrentRow++;
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "QUANTITAT GELAT PRODUÏT");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "QUANTITAT GELAT VENUT");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "QUANTITAT GELAT MERMA/NO VENUT");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "COST PRODUCCIÓ GELAT VENUT");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "COST PRODUCCIÓ GELAT MERMA/NO VENUT");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "COST PRODUCCIÓ GELAT TOTAL");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "GUANYS APROXIMATS VENDA GELAT");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "GUANYS REALS VENDA GELAT");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");
                    CurrentRow++;
                    MainSheet.InsertRow(CurrentRow);
                    MainSheet.SetText(CurrentRow, 1, "PÈRDUES APROXIMADES TOTALS");
                    MainSheet.SetText(CurrentRow, 2, "PLACEHOLDER");

                    // Autofit the columns
                    MainSheet.UsedRange.AutofitColumns();

                    // Create a new sheet (Production for type)
                    IWorksheet TypeSheet = Workbook.Worksheets[1];

                    TypeSheet.Name = "PRODUCCIÓ PER TIPUS";

                    CurrentRow = 1;

                    TypeSheet.InsertColumn(1);
                    TypeSheet.InsertColumn(2);
                    TypeSheet.InsertRow(CurrentRow);
                    TypeSheet.SetText(CurrentRow, 1, "PRODUCCIÓ PER TIPUS DEL " + InitialDate.ToShortDateString() + " AL " + FinalDate.ToShortDateString());
                    CurrentRow++;
                    CurrentRow++;

                    foreach (ProductAmount Product in Shop.Inventory.Content)
                    {
                        if(Product.Product.isIcecream)
                        {
                            float productionQuantity  = Shop.GetProductProductionBetweenDates(Product.Product, InitialDate, FinalDate);
                            TypeSheet.InsertRow(CurrentRow);
                            TypeSheet.SetText(CurrentRow, 1, Product.Product.Identifiers[0]);
                            TypeSheet.SetText(CurrentRow, 2, productionQuantity.ToString());
                            CurrentRow++;
                        }
                    }

                    // Autofit the columns
                    TypeSheet.UsedRange.AutofitColumns();

                    // Create a new sheet (Sold icecream products)
                    IWorksheet SoldSheet = Workbook.Worksheets[2];

                    TypeSheet.Name = "PRODUCTES VENUTS";

                    CurrentRow = 1;

                    TypeSheet.InsertColumn(1);
                    TypeSheet.InsertColumn(2);
                    TypeSheet.InsertRow(CurrentRow);
                    TypeSheet.SetText(CurrentRow, 1, "PRODUCTES VENUTS DEL " + InitialDate.ToShortDateString() + " AL " + FinalDate.ToShortDateString());
                    CurrentRow++;
                    TypeSheet.InsertRow(CurrentRow);
                    CurrentRow++;
                    TypeSheet.InsertRow(CurrentRow);
                    TypeSheet.SetText(CurrentRow, 1, "PRODUCTE");
                    TypeSheet.SetText(CurrentRow, 2, "UNITATS VENUDES");
                    TypeSheet.SetText(CurrentRow, 3, "QUANTITAT DE GELAT PER UNITAT");
                    TypeSheet.SetText(CurrentRow, 4, "QUANTITAT DE GELAT TOTAL");

                    foreach (ProductAmount Product in Shop.Inventory.Content)
                    {
                        if (Product.Product.isIcecream)
                        {
                            float productionQuantity = Shop.GetProductProductionBetweenDates(Product.Product, InitialDate, FinalDate);
                            TypeSheet.InsertRow(CurrentRow);
                            TypeSheet.SetText(CurrentRow, 1, Product.Product.Identifiers[0]);
                            TypeSheet.SetText(CurrentRow, 2, productionQuantity.ToString());
                            CurrentRow++;
                        }
                    }

                    // Autofit the columns
                    TypeSheet.UsedRange.AutofitColumns();

                    string FilePath = string.Empty;

                    bool Save = true;

                    using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
                    {
                        OpenFileDialog.Title = "Generar Plantilla per modificació massiva";
                        OpenFileDialog.InitialDirectory = "c:\\";
                        OpenFileDialog.Filter = "Fitxers Excel (*.xlsx)|*.xlsx";
                        OpenFileDialog.FilterIndex = 2;
                        OpenFileDialog.RestoreDirectory = true;
                        OpenFileDialog.CheckFileExists = false;
                        OpenFileDialog.FileName = Shop.Name;
                        OpenFileDialog.DefaultExt = ".xlsx";

                        if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Get the path of specified file
                            FilePath = OpenFileDialog.FileName;

                            if (File.Exists(FilePath))
                            {
                                DialogResult Response = MessageBox.Show("El fitxer ja existeix. Segur que el vols sobreescriure?", "Generar Plantilla", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                                if (Response == DialogResult.Yes)
                                {
                                    Save = true;
                                }
                                else
                                {
                                    Save = false;
                                }
                            }

                            if (Save)
                            {
                                // Save the file in the given path
                                Stream ExcelStream = File.Create(FilePath);
                                Workbook.SaveAs(ExcelStream);
                                ExcelStream.Dispose();
                                Result = true;
                            }
                            else
                            {
                                Result = false;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.Debug(e.Message);
                Logs.Debug(e.StackTrace);
                Result = false;
            }

            return Result;
        }
    }
}
