using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using Syncfusion.XlsIO;
using SadegelCore;
using System.IO;

namespace SadegelStock
{
    public partial class Inventory : SfForm
    {
        Shop Shop = null;
        
        private class InventoryModel
        {
            public string NumProducte { get; set; }
            public string Producte { get; set; }
            public string Tipus { get; set; }
            public string Categoria { get; set; }
            public string PesUnitari { get; set; }
            public string Quantitat { get; set; }
        }

        public Inventory(Shop Shop)
        {
            InitializeComponent();

            this.Style.TitleBar.Height = 26;
            this.Style.TitleBar.BackColor = Color.White;
            this.Style.TitleBar.IconBackColor = Color.FromArgb(15, 161, 212);
            this.BackColor = Color.White;
            this.Style.TitleBar.ForeColor = ColorTranslator.FromHtml("#343434");
            this.Style.TitleBar.CloseButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.HelpButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.Font = this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;

            this.ShowIcon = false;
            this.Shop = Shop;
            
            this.Text = "Inventari " + Shop.Name;

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            this.Shop.Inventory = ShopInventory.Load(this.Shop.Id);
            if (this.Shop.Inventory != null)
            {
                List<InventoryModel> GridInventoryData = new List<InventoryModel>();
                foreach(ProductAmount ProductAmount in this.Shop.Inventory.Content)
                {
                    InventoryModel NewInventoryModel = new InventoryModel();
                    NewInventoryModel.NumProducte = ProductAmount.Product.Id.ToString();
                    NewInventoryModel.Producte = ProductAmount.Product.Name;
                    string ProductTypeStr;
                    switch(ProductAmount.Product.Type)
                    {
                        case ProductType.Raw: ProductTypeStr = "Materia primera"; break;
                        case ProductType.Manufactured: ProductTypeStr = "Produït"; break;
                        case ProductType.Consumable: ProductTypeStr = "Consumible"; break;
                        default: ProductTypeStr = "None"; break;
                    }
                    NewInventoryModel.Tipus = ProductTypeStr;
                    NewInventoryModel.Categoria = ProductAmount.Product.Category.Name;
                    NewInventoryModel.PesUnitari = ProductAmount.Product.Weight.ToString() + ProductAmount.Product.BaseUnit + " / u";
                    if(ProductAmount.Product.Weight == 0f)
                    {
                        NewInventoryModel.Quantitat = ProductAmount.Amount + ProductAmount.Product.BaseUnit;
                    }
                    else
                    {
                        NewInventoryModel.Quantitat = ProductAmount.Amount + " u";
                    }

                    GridInventoryData.Add(NewInventoryModel);
                }

                sfDataGridInventory.DataSource = GridInventoryData;
                sfDataGridInventory.Refresh();
            }
        }

        private void sfButtonCreate_Click(object sender, EventArgs e)
        {
            InventoryModel SelectedRow = (InventoryModel)sfDataGridInventory.SelectedItem;
            if (SelectedRow != null)
            {
                SfForm AddStockForm = new TextInput("Afegir quantitat a " + SelectedRow.Producte);
                AddStockForm.ShowDialog();
                string Response = Program.InputResponse;
                if (Response != string.Empty)
                {
                    if (Util.IsNumeric(Response))
                    {
                        float AddQuantity = float.Parse(Response);
                        ProductAmount ProductStock = Shop.Inventory.Content.Find(x => x.Product.Id == float.Parse(SelectedRow.NumProducte));
                        if (ProductStock != null)
                        {
                            ProductStock.Amount += AddQuantity;
                            Shop.Inventory.Content.Add(ProductStock);
                            if (!Shop.Inventory.Update())
                            {
                                MessageBox.Show("Error a l'afegir producte " + SelectedRow.Producte, "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error a l'afegir producte " + SelectedRow.Producte, "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            else
            {
                SfForm AddStockForm = new TextInput("Afegir NOU producte (ID o Nom)");
                AddStockForm.ShowDialog();
                string Response = Program.InputResponse;
                if (Response != string.Empty)
                {
                    Product NewProduct = null;
                    if (Util.IsNumeric(Response))
                    {
                        NewProduct = Product.FindById(uint.Parse(Response));
                    }
                    else
                    {
                        NewProduct = Product.FindByNamePart(Response);
                    }

                    if (NewProduct != null)
                    {
                        AddStockForm = new TextInput("Afegir quantitat a " + NewProduct.Name);
                        AddStockForm.ShowDialog();
                        Response = Program.InputResponse;
                        if (Response != string.Empty)
                        {
                            if (Util.IsNumeric(Response))
                            {
                                float AddQuantity = float.Parse(Response);
                                ProductAmount NewProductAmount = new ProductAmount();
                                NewProductAmount.Product = NewProduct;
                                NewProductAmount.Amount = AddQuantity;
                                Shop.Inventory.Content.Add(NewProductAmount);
                                if(!Shop.Inventory.Update())
                                {
                                    MessageBox.Show("Error a l'afegir producte " + SelectedRow.Producte, "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No s'ha trobat el producte indicat.", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            UpdateGrid();
        }

        private void sfButtonEdit_Click(object sender, EventArgs e)
        {
            InventoryModel SelectedRow = (InventoryModel)sfDataGridInventory.SelectedItem;
            if (SelectedRow != null)
            {
                SfForm EditStockForm = new TextInput("Ajustar quantitat a " + SelectedRow.Producte);
                EditStockForm.ShowDialog();
                string Response = Program.InputResponse;
                if (Response != string.Empty)
                {
                    if (Util.IsNumeric(Response))
                    {
                        float NewQuantity = float.Parse(Response);
                        ProductAmount ProductStock = Shop.Inventory.Content.Find(x => x.Product.Id == float.Parse(SelectedRow.NumProducte));
                        if (ProductStock != null)
                        {
                            ProductStock.Amount = NewQuantity;
                            Shop.Inventory.Content.Add(ProductStock);
                            if (!Shop.Inventory.Update())
                            {
                                MessageBox.Show("Error a l'ajustar producte " + SelectedRow.Producte, "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error a l'ajustar producte " + SelectedRow.Producte, "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                UpdateGrid();
            }
        }

        private void sfButtonDelete_Click(object sender, EventArgs e)
        {
            InventoryModel SelectedRow = (InventoryModel)sfDataGridInventory.SelectedItem;
            if (SelectedRow != null)
            {
                ProductAmount ProductStock = Shop.Inventory.Content.Find(x => x.Product.Id == uint.Parse(SelectedRow.NumProducte));
                if (ProductStock != null)
                {
                    DialogResult Response = MessageBox.Show("Estas segur que vols eliminar el producte " + ProductStock.Product.Name + " de l'inventari?", "Inventari", MessageBoxButtons.YesNo);
                    if (Response == DialogResult.Yes)
                    {
                        if (Shop.Inventory.Delete(ProductStock))
                        {
                            MessageBox.Show("Eliminat producte " + ProductStock.Product.Name, "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error a l'eliminar producte " + ProductStock.Product.Name, "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error a l'eliminar producte " + ProductStock.Product.Name, "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                UpdateGrid();
            }
        }

        private void sfButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTable = Util.ToDataTable((List<InventoryModel>)sfDataGridInventory.DataSource);
                Excel.ExportDataGrid(DataTable, "Inventari", "Exportar Inventari a Excel");
                MessageBox.Show("Inventari exportat correctament", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'exportar Inventari", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logs.Debug(ex.Message);
                Logs.Debug(ex.StackTrace);
            }
        }

        private void sfDataGridProducts_Click(object sender, EventArgs e)
        {

        }

        private void sfButtonTemplateGenerate_Click(object sender, EventArgs e)
        {
            if(Excel.GenerateStockMassiveModificationTemplate(Shop))
            {
                MessageBox.Show("Generada plantilla correctament", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al generar la plantilla", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sfButtonTemplateImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {
                OpenFileDialog.Title = "Selecciona el fitxer Excel";
                OpenFileDialog.InitialDirectory = "c:\\";
                OpenFileDialog.Filter = "Fitxers Excel (*.xlsx)|*.xlsx";
                OpenFileDialog.FilterIndex = 2;
                OpenFileDialog.RestoreDirectory = true;
                OpenFileDialog.CheckFileExists = false;

                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    string FilePath = OpenFileDialog.FileName;
                    bool Ok = false;
                    if (File.Exists(FilePath))
                    {
                        int ResultCode = Shop.Inventory.ProcessMassiveStockModification(FilePath);
                        switch (ResultCode)
                        {
                            case -1:
                                {
                                    MessageBox.Show("Error al realitzar la importació, revisa que el fitxer no tingui errors. No s'ha realitzat cap modificació.", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            case 0:
                                {
                                    MessageBox.Show("No s'ha realitzat cap modificació.", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("El fitxer s'ha importat correctament i s'han modificat " + ResultCode + " productes.", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Ok = true;
                                    break;
                                }
                        }

                        if (Ok)
                        {
                            UpdateGrid();
                        }
                    }
                }
            }
        }
    }
}
