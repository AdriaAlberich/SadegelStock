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
    public partial class ShopMaintenance : SfForm
    {
        private class ShopModel
        {
            public uint Id { get; set; }
            public string Nom { get; set; }
            public string Tipus { get; set; }
            public string Tpv { get; set; }
            public string Pais { get; set; }
            public string Adreça { get; set; }
            public DateTime Creat { get; set; }
            public DateTime Actualitzat { get; set; }
        }

        public ShopMaintenance()
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
            this.Text = "Manteniment Establiments";

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if(Shop.LoadAll())
            {
                List<ShopModel> GridShopData = new List<ShopModel>();
                foreach(Shop Shop in Globals.ShopPool)
                {
                    ShopModel NewShopModel = new ShopModel();
                    NewShopModel.Id = Shop.Id;
                    NewShopModel.Nom = Shop.Name;
                    string ShopTypeStr;
                    switch(Shop.Type)
                    {
                        case ShopType.Owned: ShopTypeStr = "Propi"; break;
                        case ShopType.Franchise: ShopTypeStr = "Franquícia"; break;
                        case ShopType.International: ShopTypeStr = "Internacional"; break;
                        default: ShopTypeStr = "None"; break;
                    }
                    NewShopModel.Tipus = ShopTypeStr;
                    NewShopModel.Pais = Shop.Country.Name + " (" + Shop.Country.IsoCode + ")";
                    NewShopModel.Tpv = Shop.Tpv;
                    NewShopModel.Adreça = Shop.Address.Street + " " + Shop.Address.Number + " " + Shop.Address.Floor + " " + Shop.Address.Door + " " + Shop.Address.City + " (" + Shop.Address.ZipCode + ")";
                    NewShopModel.Creat = Shop.CreatedAt;
                    NewShopModel.Actualitzat = Shop.UpdatedAt;

                    GridShopData.Add(NewShopModel);
                }

                sfDataGridShops.DataSource = GridShopData;
                sfDataGridShops.Refresh();
            }
        }

        private void sfButtonCreate_Click(object sender, EventArgs e)
        {
            SfForm CreateShopForm = new ShopInput(false, null);
            CreateShopForm.ShowDialog();
            UpdateGrid();
        }

        private void sfButtonEdit_Click(object sender, EventArgs e)
        {
            ShopModel SelectedRow = (ShopModel)sfDataGridShops.SelectedItem;
            if (SelectedRow != null)
            {
                Shop SelectedShop = Shop.FindById(SelectedRow.Id);
                if(SelectedShop != null)
                {
                    SfForm CreateShopForm = new ShopInput(true, SelectedShop);
                    CreateShopForm.ShowDialog();
                    UpdateGrid();
                }
            }
        }

        private void sfButtonDelete_Click(object sender, EventArgs e)
        {
            ShopModel SelectedRow = (ShopModel)sfDataGridShops.SelectedItem;
            if (SelectedRow != null)
            {
                Shop SelectedShop = Shop.FindById(SelectedRow.Id);
                if (SelectedShop != null)
                {
                    DialogResult Response = MessageBox.Show("Estas segur que vols esborrar l'establiment " + SelectedShop.Name + "?", "Establiments", MessageBoxButtons.YesNo);
                    if(Response == DialogResult.Yes)
                    {
                        if(SelectedShop.Delete())
                        {
                            MessageBox.Show("Eliminat establiment " + SelectedShop.Name, "Establiments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logs.EventLog("Eliminat establiment " + SelectedShop.Name, "stock");
                            UpdateGrid();
                        }
                        else
                        {
                            MessageBox.Show("Error a l'eliminar establiment " + SelectedShop.Name, "Establiments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void sfButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTable = Util.ToDataTable((List<ShopModel>)sfDataGridShops.DataSource);
                Excel.ExportDataGrid(DataTable, "Establiments", "Exportar Establiments a Excel");
                MessageBox.Show("Establiments exportats correctament", "Establiments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'exportar Establiments", "Establiments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logs.Debug(ex.Message);
                Logs.Debug(ex.StackTrace);
            }
        }

        private void sfDataGridShops_Click(object sender, EventArgs e)
        {

        }
    }
}
