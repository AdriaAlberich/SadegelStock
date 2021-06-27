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
    public partial class CountriesMaintenance : SfForm
    {
        private class CountryModel
        {
            public string Codi { get; set; }
            public string Nom { get; set; }
            public DateTime Creat { get; set; }
            public DateTime Actualitzat { get; set; }
        }

        public CountriesMaintenance()
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
            this.Text = "Manteniment Països";

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if(Country.LoadAll())
            {
                List<CountryModel> GridCountryData = new List<CountryModel>();
                foreach(Country Country in Globals.CountryPool)
                {
                    CountryModel NewCountryModel = new CountryModel();
                    NewCountryModel.Codi = Country.IsoCode;
                    NewCountryModel.Nom = Country.Name;

                    GridCountryData.Add(NewCountryModel);
                }

                sfDataGridCountries.DataSource = GridCountryData;
                sfDataGridCountries.Refresh();
            }
        }

        private void sfButtonCreate_Click(object sender, EventArgs e)
        {
            SfForm CreateCountryIsoForm = new TextInput("Codi del país (ISO)", "");
            CreateCountryIsoForm.ShowDialog();
            string IsoCode = Program.InputResponse;
            if (IsoCode != string.Empty)
            {
                SfForm CreateCountryNameForm = new TextInput("Nom del país", "");
                CreateCountryNameForm.ShowDialog();
                string Name = Program.InputResponse;
                if (Name != string.Empty)
                {
                    if(Country.Create(IsoCode, Name) == null)
                    {
                        MessageBox.Show("Error al crear país " + Name + " comprova que no estigui repetit.", "Països", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Logs.EventLog("Creat nou país " + Name, EventLogOrigin.SadegelStock, EventLogType.CountryMaintenance);
                        UpdateGrid();
                    }
                }
            }
        }

        private void sfButtonDelete_Click(object sender, EventArgs e)
        {
            CountryModel SelectedRow = (CountryModel)sfDataGridCountries.SelectedItem;
            if (SelectedRow != null)
            {
                Country SelectedCountry = Country.FindByCode(SelectedRow.Codi);
                if (SelectedCountry != null)
                {
                    DialogResult Response = MessageBox.Show("Estas segur que vols esborrar el país " + SelectedCountry.Name + "?", "Països", MessageBoxButtons.YesNo);
                    if(Response == DialogResult.Yes)
                    {
                        if(SelectedCountry.Delete())
                        {
                            MessageBox.Show("Eliminat país " + SelectedCountry.Name, "Països", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logs.EventLog("Eliminat país " + SelectedCountry.Name, EventLogOrigin.SadegelStock, EventLogType.CountryMaintenance);
                            UpdateGrid();
                        }
                        else
                        {
                            MessageBox.Show("Error a l'eliminar país " + SelectedCountry.Name + ", pot ser que estigui assignat a un establiment?", "Països", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void sfButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTable = Util.ToDataTable((List<CountryModel>)sfDataGridCountries.DataSource);
                Excel.ExportDataGrid(DataTable, "Països", "Exportar Països a Excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'exportar Països", "Països", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logs.Debug(ex.Message);
                Logs.Debug(ex.StackTrace);
            }
        }

        private void sfDataGridCountries_Click(object sender, EventArgs e)
        {

        }
    }
}
