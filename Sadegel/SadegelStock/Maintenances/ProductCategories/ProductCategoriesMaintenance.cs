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
    public partial class ProductCategoriesMaintenance : SfForm
    {
        private class CategoryModel
        {
            public string Id { get; set; }
            public string Nom { get; set; }
            public DateTime Creat { get; set; }
            public DateTime Actualitzat { get; set; }
        }

        public ProductCategoriesMaintenance()
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
            this.Text = "Manteniment Categories de productes";

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if(ProductCategory.LoadAll())
            {
                List<CategoryModel> GridCategoryData = new List<CategoryModel>();
                foreach(ProductCategory Category in Globals.ProductCategoryPool)
                {
                    CategoryModel NewProductCategoryModel = new CategoryModel();
                    NewProductCategoryModel.Id = Category.Id.ToString();
                    NewProductCategoryModel.Nom = Category.Name;
                    NewProductCategoryModel.Creat = Category.CreatedAt;
                    NewProductCategoryModel.Actualitzat = Category.UpdatedAt;

                    GridCategoryData.Add(NewProductCategoryModel);
                }

                sfDataGridCategories.DataSource = GridCategoryData;
                sfDataGridCategories.Refresh();
            }
        }

        private void sfButtonCreate_Click(object sender, EventArgs e)
        {
            SfForm CreateCategoriesForm = new TextInput("Nom de la categoria", "");
            CreateCategoriesForm.ShowDialog();
            string NewCategory = Program.InputResponse;
            if(NewCategory != string.Empty)
            {
                if (ProductCategory.Create(NewCategory) != null)
                {
                    Logs.EventLog("Creada nova categoria " + NewCategory, EventLogOrigin.SadegelStock, EventLogType.ProductCategoryMaintenance);
                    UpdateGrid();
                }
            }
        }

        private void sfButtonEdit_Click(object sender, EventArgs e)
        {
            CategoryModel SelectedRow = (CategoryModel)sfDataGridCategories.SelectedItem;
            if (SelectedRow != null)
            {
                ProductCategory SelectedCategory = ProductCategory.FindByName(SelectedRow.Nom);
                if(SelectedCategory != null)
                {
                    SfForm CreateCategoryForm = new TextInput("Nom de la categoria", SelectedCategory.Name);
                    CreateCategoryForm.ShowDialog();
                    string NewCategoryName = Program.InputResponse;
                    if (NewCategoryName != string.Empty)
                    {
                        SelectedCategory.Name = NewCategoryName;
                        if (SelectedCategory.Update())
                        {
                            Logs.EventLog("Editada categoria " + NewCategoryName, EventLogOrigin.SadegelStock, EventLogType.ProductCategoryMaintenance);
                            UpdateGrid();
                        }
                    }
                }
            }
        }

        private void sfButtonDelete_Click(object sender, EventArgs e)
        {
            CategoryModel SelectedRow = (CategoryModel)sfDataGridCategories.SelectedItem;
            if (SelectedRow != null)
            {
                ProductCategory SelectedCategory = ProductCategory.FindByName(SelectedRow.Nom);
                if (SelectedCategory != null)
                {
                    DialogResult Response = MessageBox.Show("Estas segur que vols esborrar la categoria " + SelectedCategory.Name + "?", "Categories", MessageBoxButtons.YesNo);
                    if(Response == DialogResult.Yes)
                    {
                        if(SelectedCategory.Delete())
                        {
                            MessageBox.Show("Eliminada categoria " + SelectedCategory.Name, "Categories", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logs.EventLog("Eliminada categoria " + SelectedCategory.Name, EventLogOrigin.SadegelStock, EventLogType.ProductCategoryMaintenance);
                            UpdateGrid();
                        }
                        else
                        {
                            MessageBox.Show("Error a l'eliminar categoria " + SelectedCategory.Name, "Categories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void sfButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTable = Util.ToDataTable((List<CategoryModel>)sfDataGridCategories.DataSource);
                Excel.ExportDataGrid(DataTable, "Categories", "Exportar Categories a Excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'exportar Categories", "Categories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logs.Debug(ex.Message);
                Logs.Debug(ex.StackTrace);
            }
        }

        private void sfDataGridCategories_Click(object sender, EventArgs e)
        {

        }
    }
}
