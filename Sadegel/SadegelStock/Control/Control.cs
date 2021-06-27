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
using System.Linq;

namespace SadegelStock
{
    public partial class Control : SfForm
    {
        List<EventLogModel> ControlLogs;

        public Control()
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
            
            this.Text = "Seguiment";

            cmbOrigin.Items.Add("");
            cmbOrigin.Items.Add(EventLogOrigin.Text[EventLogOrigin.SadegelCore]);
            cmbOrigin.Items.Add(EventLogOrigin.Text[EventLogOrigin.SadegelBot]);
            cmbOrigin.Items.Add(EventLogOrigin.Text[EventLogOrigin.SadegelStock]);

            
            cmbType.Items.Add("");
            cmbType.Items.Add(EventLogType.Text[EventLogType.ShopStockSummary]);
            cmbType.Items.Add(EventLogType.Text[EventLogType.ShopStockMovement]);
            cmbType.Items.Add(EventLogType.Text[EventLogType.ShopStockProductionSummary]);
            cmbType.Items.Add(EventLogType.Text[EventLogType.ShopMaintenance]);
            cmbType.Items.Add(EventLogType.Text[EventLogType.ProductMaintenance]);
            cmbType.Items.Add(EventLogType.Text[EventLogType.ProductCategoryMaintenance]);
            cmbType.Items.Add(EventLogType.Text[EventLogType.ProviderMaintenance]);
            cmbType.Items.Add(EventLogType.Text[EventLogType.CountryMaintenance]);

            cmbShop.Items.Add("");
            foreach (Shop Shop in Globals.ShopPool)
            {
                cmbShop.Items.Add(Shop.Name);
            }

            cmbProduct.Items.Add("");
            foreach (Product Product in Globals.ProductPool)
            {
                cmbProduct.Items.Add(Product.Name);
            }

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            uint ShopId = 0;
            if (cmbShop.SelectedValue != null)
                ShopId = Shop.FindByName(cmbShop.Text).Id;

            uint ProductId = 0;
            if (cmbProduct.SelectedValue != null)
                ProductId = Product.FindByName(cmbProduct.Text).Id;

            ControlLogs = Logs.GetEventLog(65535, EventLogOrigin.Text.FirstOrDefault(x => x.Value == cmbOrigin.Text).Key == null ? "" : EventLogOrigin.Text.FirstOrDefault(x => x.Value == cmbOrigin.Text).Key, EventLogType.Text.FirstOrDefault(x => x.Value == cmbType.Text).Key == null ? "" : EventLogType.Text.FirstOrDefault(x => x.Value == cmbType.Text).Key, ShopId, ProductId, -1, dateInitial.Value, dateFinal.Value);
            List<EventLogModel> ControlLogsVisual = new List<EventLogModel>();
            foreach(EventLogModel ControlLog in ControlLogs)
            {
                EventLogModel NewControlLog = new EventLogModel();
                NewControlLog.Missatge = ControlLog.Missatge;
                NewControlLog.Origen = EventLogOrigin.Text[ControlLog.Origen];
                NewControlLog.Tipus = EventLogType.Text[ControlLog.Tipus];
                NewControlLog.PC = ControlLog.PC == "SYSTEM" ? "Sistema" : ControlLog.PC;
                NewControlLog.Usuari = ControlLog.Usuari == "SYSTEM" ? "Sistema" : ControlLog.Usuari;
                NewControlLog.Establiment = ControlLog.Establiment;
                NewControlLog.Producte = ControlLog.Producte;
                NewControlLog.Quantitat = ControlLog.Quantitat;
                NewControlLog.Data = ControlLog.Data;
                ControlLogsVisual.Add(NewControlLog);
            }

            sfDataGridControl.DataSource = ControlLogsVisual;
            sfDataGridControl.Refresh();

            lblTotalLogs.Text = "Mostrant " + (sfDataGridControl.RowCount-1) + " registres.";
        }

        private void sfButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTable = Util.ToDataTable((List<EventLogModel>)sfDataGridControl.DataSource);
                Excel.ExportDataGrid(DataTable, "Seguiment", "Exportar Seguiment a Excel");
                MessageBox.Show("Seguiment exportat correctament", "Seguiment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'exportar Seguiment", "Seguiment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logs.Debug(ex.Message);
                Logs.Debug(ex.StackTrace);
            }
        }

        private void cmbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void cmbShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void dateInitial_ValueChanged(object sender, Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventArgs e)
        {
            UpdateGrid();
        }

        private void dateFinal_ValueChanged(object sender, Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventArgs e)
        {
            UpdateGrid();
        }
    }
}
