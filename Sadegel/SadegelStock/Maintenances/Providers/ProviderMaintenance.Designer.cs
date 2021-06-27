namespace SadegelStock
{
    partial class ProviderMaintenance
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn9 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn10 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn11 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn12 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn3 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn4 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            this.sfDataGridProviders = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfButtonExport = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonDelete = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonEdit = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonCreate = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGridProviders
            // 
            this.sfDataGridProviders.AccessibleName = "Table";
            this.sfDataGridProviders.AllowEditing = false;
            this.sfDataGridProviders.AllowFiltering = true;
            this.sfDataGridProviders.AllowGrouping = false;
            this.sfDataGridProviders.AllowResizingColumns = true;
            this.sfDataGridProviders.AutoGenerateColumns = false;
            gridTextColumn7.AllowEditing = false;
            gridTextColumn7.AllowFiltering = true;
            gridTextColumn7.AllowGrouping = false;
            gridTextColumn7.AllowResizing = true;
            gridTextColumn7.HeaderText = "Nom";
            gridTextColumn7.MappingName = "Nom";
            gridTextColumn7.Width = 200D;
            gridTextColumn8.AllowEditing = false;
            gridTextColumn8.AllowFiltering = true;
            gridTextColumn8.AllowGrouping = false;
            gridTextColumn8.AllowResizing = true;
            gridTextColumn8.HeaderText = "CIF";
            gridTextColumn8.MappingName = "CIF";
            gridTextColumn8.Width = 147D;
            gridTextColumn9.AllowEditing = false;
            gridTextColumn9.AllowFiltering = true;
            gridTextColumn9.AllowGrouping = false;
            gridTextColumn9.AllowResizing = true;
            gridTextColumn9.HeaderText = "Email";
            gridTextColumn9.MappingName = "Email";
            gridTextColumn9.Width = 250D;
            gridTextColumn10.AllowEditing = false;
            gridTextColumn10.AllowFiltering = true;
            gridTextColumn10.AllowGrouping = false;
            gridTextColumn10.AllowResizing = true;
            gridTextColumn10.HeaderText = "Telefon";
            gridTextColumn10.MappingName = "Telefon";
            gridTextColumn10.Width = 150D;
            gridTextColumn11.AllowEditing = false;
            gridTextColumn11.AllowFiltering = true;
            gridTextColumn11.AllowGrouping = false;
            gridTextColumn11.AllowResizing = true;
            gridTextColumn11.HeaderText = "Adreça";
            gridTextColumn11.MappingName = "Adreça";
            gridTextColumn11.Width = 300D;
            gridTextColumn12.AllowEditing = false;
            gridTextColumn12.AllowFiltering = true;
            gridTextColumn12.AllowGrouping = false;
            gridTextColumn12.AllowResizing = true;
            gridTextColumn12.HeaderText = "Pais";
            gridTextColumn12.MappingName = "Pais";
            gridTextColumn12.Width = 150D;
            gridDateTimeColumn3.AllowEditing = false;
            gridDateTimeColumn3.AllowFiltering = true;
            gridDateTimeColumn3.AllowGrouping = false;
            gridDateTimeColumn3.AllowResizing = true;
            gridDateTimeColumn3.HeaderText = "Creat";
            gridDateTimeColumn3.MappingName = "Creat";
            gridDateTimeColumn3.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn3.Width = 150D;
            gridDateTimeColumn4.AllowEditing = false;
            gridDateTimeColumn4.AllowFiltering = true;
            gridDateTimeColumn4.AllowGrouping = false;
            gridDateTimeColumn4.AllowResizing = true;
            gridDateTimeColumn4.HeaderText = "Actualitzat";
            gridDateTimeColumn4.MappingName = "Actualitzat";
            gridDateTimeColumn4.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn4.Width = 150D;
            this.sfDataGridProviders.Columns.Add(gridTextColumn7);
            this.sfDataGridProviders.Columns.Add(gridTextColumn8);
            this.sfDataGridProviders.Columns.Add(gridTextColumn9);
            this.sfDataGridProviders.Columns.Add(gridTextColumn10);
            this.sfDataGridProviders.Columns.Add(gridTextColumn11);
            this.sfDataGridProviders.Columns.Add(gridTextColumn12);
            this.sfDataGridProviders.Columns.Add(gridDateTimeColumn3);
            this.sfDataGridProviders.Columns.Add(gridDateTimeColumn4);
            this.sfDataGridProviders.Location = new System.Drawing.Point(14, 5);
            this.sfDataGridProviders.Name = "sfDataGridProviders";
            this.sfDataGridProviders.Size = new System.Drawing.Size(1000, 396);
            this.sfDataGridProviders.TabIndex = 0;
            this.sfDataGridProviders.Text = "sfDataGridShops";
            this.sfDataGridProviders.Click += new System.EventHandler(this.sfDataGridProducts_Click);
            // 
            // sfButtonExport
            // 
            this.sfButtonExport.AccessibleName = "Button";
            this.sfButtonExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonExport.Location = new System.Drawing.Point(918, 407);
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
            this.sfButtonDelete.Location = new System.Drawing.Point(218, 407);
            this.sfButtonDelete.Name = "sfButtonDelete";
            this.sfButtonDelete.Size = new System.Drawing.Size(96, 28);
            this.sfButtonDelete.Style.Image = global::SadegelStock.Properties.Resources.error;
            this.sfButtonDelete.TabIndex = 3;
            this.sfButtonDelete.Text = "Eliminar";
            this.sfButtonDelete.Click += new System.EventHandler(this.sfButtonDelete_Click);
            // 
            // sfButtonEdit
            // 
            this.sfButtonEdit.AccessibleName = "Button";
            this.sfButtonEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonEdit.Location = new System.Drawing.Point(116, 407);
            this.sfButtonEdit.Name = "sfButtonEdit";
            this.sfButtonEdit.Size = new System.Drawing.Size(96, 28);
            this.sfButtonEdit.Style.Image = global::SadegelStock.Properties.Resources.notice;
            this.sfButtonEdit.TabIndex = 2;
            this.sfButtonEdit.Text = "Editar";
            this.sfButtonEdit.Click += new System.EventHandler(this.sfButtonEdit_Click);
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
            // ProviderMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 441);
            this.Controls.Add(this.sfButtonExport);
            this.Controls.Add(this.sfButtonDelete);
            this.Controls.Add(this.sfButtonEdit);
            this.Controls.Add(this.sfButtonCreate);
            this.Controls.Add(this.sfDataGridProviders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProviderMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manteniment Productes";
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridProviders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridProviders;
        private Syncfusion.WinForms.Controls.SfButton sfButtonCreate;
        private Syncfusion.WinForms.Controls.SfButton sfButtonEdit;
        private Syncfusion.WinForms.Controls.SfButton sfButtonDelete;
        private Syncfusion.WinForms.Controls.SfButton sfButtonExport;
    }
}