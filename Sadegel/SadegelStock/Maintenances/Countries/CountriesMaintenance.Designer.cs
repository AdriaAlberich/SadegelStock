namespace SadegelStock
{
    partial class CountriesMaintenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.sfDataGridCountries = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfButtonExport = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonDelete = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonCreate = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridCountries)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGridCountries
            // 
            this.sfDataGridCountries.AccessibleName = "Table";
            this.sfDataGridCountries.AllowEditing = false;
            this.sfDataGridCountries.AllowFiltering = true;
            this.sfDataGridCountries.AllowGrouping = false;
            this.sfDataGridCountries.AllowResizingColumns = true;
            this.sfDataGridCountries.AutoGenerateColumns = false;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.AllowGrouping = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.HeaderText = "Codi";
            gridTextColumn1.MappingName = "Codi";
            gridTextColumn1.Width = 100D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.AllowGrouping = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Nom";
            gridTextColumn2.MappingName = "Nom";
            gridTextColumn2.Width = 347D;
            this.sfDataGridCountries.Columns.Add(gridTextColumn1);
            this.sfDataGridCountries.Columns.Add(gridTextColumn2);
            this.sfDataGridCountries.Location = new System.Drawing.Point(14, 5);
            this.sfDataGridCountries.Name = "sfDataGridCountries";
            this.sfDataGridCountries.Size = new System.Drawing.Size(300, 396);
            this.sfDataGridCountries.TabIndex = 0;
            this.sfDataGridCountries.Text = "sfDataGridShops";
            this.sfDataGridCountries.Click += new System.EventHandler(this.sfDataGridCountries_Click);
            // 
            // sfButtonExport
            // 
            this.sfButtonExport.AccessibleName = "Button";
            this.sfButtonExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonExport.Location = new System.Drawing.Point(218, 407);
            this.sfButtonExport.Name = "sfButtonExport";
            this.sfButtonExport.Size = new System.Drawing.Size(96, 28);
            this.sfButtonExport.TabIndex = 4;
            this.sfButtonExport.Text = "Exportar";
            this.sfButtonExport.Click += new System.EventHandler(this.sfButtonExport_Click);
            // 
            // sfButtonDelete
            // 
            this.sfButtonDelete.AccessibleName = "Button";
            this.sfButtonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonDelete.Location = new System.Drawing.Point(116, 407);
            this.sfButtonDelete.Name = "sfButtonDelete";
            this.sfButtonDelete.Size = new System.Drawing.Size(96, 28);
            this.sfButtonDelete.Style.Image = global::SadegelStock.Properties.Resources.error;
            this.sfButtonDelete.TabIndex = 3;
            this.sfButtonDelete.Text = "Eliminar";
            this.sfButtonDelete.Click += new System.EventHandler(this.sfButtonDelete_Click);
            // 
            // sfButtonCreate
            // 
            this.sfButtonCreate.AccessibleName = "Button";
            this.sfButtonCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonCreate.Location = new System.Drawing.Point(14, 407);
            this.sfButtonCreate.Name = "sfButtonCreate";
            this.sfButtonCreate.Size = new System.Drawing.Size(96, 28);
            this.sfButtonCreate.Style.Image = global::SadegelStock.Properties.Resources.success;
            this.sfButtonCreate.TabIndex = 1;
            this.sfButtonCreate.Text = "Crear";
            this.sfButtonCreate.Click += new System.EventHandler(this.sfButtonCreate_Click);
            // 
            // CountriesMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 441);
            this.Controls.Add(this.sfButtonExport);
            this.Controls.Add(this.sfButtonDelete);
            this.Controls.Add(this.sfButtonCreate);
            this.Controls.Add(this.sfDataGridCountries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountriesMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manteniment Països";
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridCountries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridCountries;
        private Syncfusion.WinForms.Controls.SfButton sfButtonCreate;
        private Syncfusion.WinForms.Controls.SfButton sfButtonDelete;
        private Syncfusion.WinForms.Controls.SfButton sfButtonExport;
    }
}