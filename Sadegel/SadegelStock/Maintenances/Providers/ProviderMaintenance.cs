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
    public partial class ProviderMaintenance : SfForm
    {
        private class ProviderModel
        {
            public string Nom { get; set; }
            public string CIF { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public string Adreça { get; set; }
            public string Pais { get; set; }
            public DateTime Creat { get; set; }
            public DateTime Actualitzat { get; set; }
        }

        public ProviderMaintenance()
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
            this.Text = "Manteniment Proveïdors";

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if(Provider.LoadAll())
            {
                List<ProviderModel> GridProviderData = new List<ProviderModel>();
                foreach(Provider Provider in Globals.ProviderPool)
                {
                    ProviderModel NewProviderModel = new ProviderModel();
                    NewProviderModel.Nom = Provider.Name;
                    NewProviderModel.CIF = Provider.Id;
                    NewProviderModel.Email = Provider.Email;
                    NewProviderModel.Telefon = Provider.Phone;
                    NewProviderModel.Adreça = Provider.Address.Street + " " + Provider.Address.Number + " " + Provider.Address.Floor + " " + Provider.Address.Door + " " + Provider.Address.City + " (" + Provider.Address.ZipCode + ")";
                    NewProviderModel.Pais = Provider.Country.Name;
                    NewProviderModel.Creat = Provider.CreatedAt;
                    NewProviderModel.Actualitzat = Provider.UpdatedAt;

                    GridProviderData.Add(NewProviderModel);
                }

                sfDataGridProviders.DataSource = GridProviderData;
                sfDataGridProviders.Refresh();
            }
        }

        private void sfButtonCreate_Click(object sender, EventArgs e)
        {
            SfForm CreateProviderForm = new ProviderInput(false, null);
            CreateProviderForm.ShowDialog();
            UpdateGrid();
        }

        private void sfButtonEdit_Click(object sender, EventArgs e)
        {
            ProviderModel SelectedRow = (ProviderModel)sfDataGridProviders.SelectedItem;
            if (SelectedRow != null)
            {
                Provider SelectedProvider = Provider.FindByName(SelectedRow.Nom);
                if(SelectedProvider != null)
                {
                    SfForm CreateProviderForm = new ProviderInput(true, SelectedProvider);
                    CreateProviderForm.ShowDialog();
                    UpdateGrid();
                }
            }
        }

        private void sfButtonDelete_Click(object sender, EventArgs e)
        {
            ProviderModel SelectedRow = (ProviderModel)sfDataGridProviders.SelectedItem;
            if (SelectedRow != null)
            {
                Provider SelectedProvider = Provider.FindByName(SelectedRow.Nom);
                if (SelectedProvider != null)
                {
                    DialogResult Response = MessageBox.Show("Estas segur que vols esborrar el proveïdor " + SelectedProvider.Name + "?", "Proveïdors", MessageBoxButtons.YesNo);
                    if(Response == DialogResult.Yes)
                    {
                        if(SelectedProvider.Delete())
                        {
                            MessageBox.Show("Eliminat proveïdor " + SelectedProvider.Name, "Proveïdors", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logs.EventLog("Eliminat proveïdor " + SelectedProvider.Name, EventLogOrigin.SadegelStock, EventLogType.ProviderMaintenance);
                            UpdateGrid();
                        }
                        else
                        {
                            MessageBox.Show("Error a l'eliminar proveïdor " + SelectedProvider.Name, "Proveïdors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void sfButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTable = Util.ToDataTable((List<ProviderModel>)sfDataGridProviders.DataSource);
                Excel.ExportDataGrid(DataTable, "Proveïdors", "Exportar Proveïdors a Excel");
                MessageBox.Show("Proveïdors exportats correctament", "Proveïdors", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'exportar Proveïdors", "Proveïdors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logs.Debug(ex.Message);
                Logs.Debug(ex.StackTrace);
            }
        }

        private void sfDataGridProducts_Click(object sender, EventArgs e)
        {

        }
    }
}
