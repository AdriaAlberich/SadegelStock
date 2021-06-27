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
    public partial class ProductMaintenance : SfForm
    {
        private class ProductModel
        {
            public uint Id { get; set; }
            public string Nom { get; set; }
            public string Tipus { get; set; }
            public string Pes { get; set; }
            public string Categoria { get; set; }
            public DateTime Creat { get; set; }
            public DateTime Actualitzat { get; set; }
        }

        public ProductMaintenance()
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
            this.Text = "Manteniment Productes";

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if(Product.LoadAll())
            {
                List<ProductModel> GridProductData = new List<ProductModel>();
                foreach(Product Product in Globals.ProductPool)
                {
                    ProductModel NewProductModel = new ProductModel();
                    NewProductModel.Id = Product.Id;
                    NewProductModel.Nom = Product.Name;
                    string ProductTypeStr;
                    switch(Product.Type)
                    {
                        case ProductType.Raw: ProductTypeStr = "Materia primera"; break;
                        case ProductType.Manufactured: ProductTypeStr = "Elaborat"; break;
                        case ProductType.Consumable: ProductTypeStr = "Consumible"; break;
                        default: ProductTypeStr = "None"; break;
                    }
                    NewProductModel.Tipus = ProductTypeStr;
                    NewProductModel.Categoria = Product.Category.Name;
                    NewProductModel.Pes = Product.Weight.ToString() + Product.BaseUnit + " / u";
                    NewProductModel.Creat = Product.CreatedAt;
                    NewProductModel.Actualitzat = Product.UpdatedAt;

                    GridProductData.Add(NewProductModel);
                }

                sfDataGridProducts.DataSource = GridProductData;
                sfDataGridProducts.Refresh();
            }
        }

        private void sfButtonCreate_Click(object sender, EventArgs e)
        {
            SfForm CreateProductForm = new ProductInput(false, null);
            CreateProductForm.ShowDialog();
            UpdateGrid();
        }

        private void sfButtonEdit_Click(object sender, EventArgs e)
        {
            ProductModel SelectedRow = (ProductModel)sfDataGridProducts.SelectedItem;
            if (SelectedRow != null)
            {
                Product SelectedProduct = Product.FindById(SelectedRow.Id);
                if(SelectedProduct != null)
                {
                    SfForm CreateProductForm = new ProductInput(true, SelectedProduct);
                    CreateProductForm.ShowDialog();
                    UpdateGrid();
                }
            }
        }

        private void sfButtonDelete_Click(object sender, EventArgs e)
        {
            ProductModel SelectedRow = (ProductModel)sfDataGridProducts.SelectedItem;
            if (SelectedRow != null)
            {
                Product SelectedProduct = Product.FindById(SelectedRow.Id);
                if (SelectedProduct != null)
                {
                    DialogResult Response = MessageBox.Show("Estas segur que vols esborrar el producte " + SelectedProduct.Name + "?", "Productes", MessageBoxButtons.YesNo);
                    if(Response == DialogResult.Yes)
                    {
                        if(SelectedProduct.Delete())
                        {
                            MessageBox.Show("Eliminat producte " + SelectedProduct.Name, "Productes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logs.EventLog("Eliminat producte " + SelectedProduct.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                            UpdateGrid();
                        }
                        else
                        {
                            MessageBox.Show("Error a l'eliminar producte " + SelectedProduct.Name, "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void sfButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTable = Util.ToDataTable((List<ProductModel>)sfDataGridProducts.DataSource);
                Excel.ExportDataGrid(DataTable, "Productes", "Exportar Productes a Excel");
                MessageBox.Show("Productes exportats correctament", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'exportar Productes", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logs.Debug(ex.Message);
                Logs.Debug(ex.StackTrace);
            }
        }

        private void sfDataGridProducts_Click(object sender, EventArgs e)
        {

        }
    }
}
