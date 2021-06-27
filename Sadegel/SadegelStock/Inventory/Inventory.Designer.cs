namespace SadegelStock
{
    partial class Inventory
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.sfDataGridInventory = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfButtonExport = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonDelete = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonEdit = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonCreate = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonTemplateImport = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonTemplateGenerate = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGridInventory
            // 
            this.sfDataGridInventory.AccessibleName = "Table";
            this.sfDataGridInventory.AllowEditing = false;
            this.sfDataGridInventory.AllowFiltering = true;
            this.sfDataGridInventory.AllowGrouping = false;
            this.sfDataGridInventory.AllowResizingColumns = true;
            this.sfDataGridInventory.AutoGenerateColumns = false;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.AllowGrouping = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.HeaderText = "Num Producte";
            gridTextColumn1.MappingName = "NumProducte";
            gridTextColumn1.Width = 150D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.AllowGrouping = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Nom Producte";
            gridTextColumn2.MappingName = "Producte";
            gridTextColumn2.Width = 288D;
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowFiltering = true;
            gridTextColumn3.AllowGrouping = false;
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.HeaderText = "Tipus Producte";
            gridTextColumn3.MappingName = "Tipus";
            gridTextColumn3.Width = 150D;
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowFiltering = true;
            gridTextColumn4.AllowGrouping = false;
            gridTextColumn4.AllowResizing = true;
            gridTextColumn4.HeaderText = "Categoria Producte";
            gridTextColumn4.MappingName = "Categoria";
            gridTextColumn4.Width = 200D;
            gridTextColumn5.AllowEditing = false;
            gridTextColumn5.AllowFiltering = true;
            gridTextColumn5.AllowGrouping = false;
            gridTextColumn5.AllowResizing = true;
            gridTextColumn5.HeaderText = "Pes Unitari";
            gridTextColumn5.MappingName = "PesUnitari";
            gridTextColumn5.Width = 150D;
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.AllowFiltering = true;
            gridTextColumn6.AllowGrouping = false;
            gridTextColumn6.AllowResizing = true;
            gridTextColumn6.HeaderText = "Quantitat";
            gridTextColumn6.MappingName = "Quantitat";
            gridTextColumn6.Width = 150D;
            this.sfDataGridInventory.Columns.Add(gridTextColumn1);
            this.sfDataGridInventory.Columns.Add(gridTextColumn2);
            this.sfDataGridInventory.Columns.Add(gridTextColumn3);
            this.sfDataGridInventory.Columns.Add(gridTextColumn4);
            this.sfDataGridInventory.Columns.Add(gridTextColumn5);
            this.sfDataGridInventory.Columns.Add(gridTextColumn6);
            this.sfDataGridInventory.Location = new System.Drawing.Point(14, 5);
            this.sfDataGridInventory.Name = "sfDataGridInventory";
            this.sfDataGridInventory.Size = new System.Drawing.Size(727, 396);
            this.sfDataGridInventory.TabIndex = 0;
            this.sfDataGridInventory.Text = "sfDataGridShops";
            this.sfDataGridInventory.Click += new System.EventHandler(this.sfDataGridProducts_Click);
            // 
            // sfButtonExport
            // 
            this.sfButtonExport.AccessibleName = "Button";
            this.sfButtonExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonExport.Location = new System.Drawing.Point(641, 408);
            this.sfButtonExport.Name = "sfButtonExport";
            this.sfButtonExport.Size = new System.Drawing.Size(100, 28);
            this.sfButtonExport.TabIndex = 4;
            this.sfButtonExport.Text = "Exportar Llistat/";
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
            this.sfButtonEdit.Text = "Modificar";
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
            this.sfButtonCreate.Text = "Afegir producte";
            this.sfButtonCreate.Click += new System.EventHandler(this.sfButtonCreate_Click);
            // 
            // sfButtonTemplateImport
            // 
            this.sfButtonTemplateImport.AccessibleName = "Button";
            this.sfButtonTemplateImport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonTemplateImport.Location = new System.Drawing.Point(515, 408);
            this.sfButtonTemplateImport.Name = "sfButtonTemplateImport";
            this.sfButtonTemplateImport.Size = new System.Drawing.Size(120, 28);
            this.sfButtonTemplateImport.TabIndex = 5;
            this.sfButtonTemplateImport.Text = "Importar Plantilla/";
            this.sfButtonTemplateImport.Click += new System.EventHandler(this.sfButtonTemplateImport_Click);
            // 
            // sfButtonTemplateGenerate
            // 
            this.sfButtonTemplateGenerate.AccessibleName = "Button";
            this.sfButtonTemplateGenerate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonTemplateGenerate.Location = new System.Drawing.Point(389, 408);
            this.sfButtonTemplateGenerate.Name = "sfButtonTemplateGenerate";
            this.sfButtonTemplateGenerate.Size = new System.Drawing.Size(120, 28);
            this.sfButtonTemplateGenerate.TabIndex = 6;
            this.sfButtonTemplateGenerate.Text = "Generar Plantilla";
            this.sfButtonTemplateGenerate.Click += new System.EventHandler(this.sfButtonTemplateGenerate_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 441);
            this.Controls.Add(this.sfButtonTemplateGenerate);
            this.Controls.Add(this.sfButtonTemplateImport);
            this.Controls.Add(this.sfButtonExport);
            this.Controls.Add(this.sfButtonDelete);
            this.Controls.Add(this.sfButtonEdit);
            this.Controls.Add(this.sfButtonCreate);
            this.Controls.Add(this.sfDataGridInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manteniment Productes";
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridInventory;
        private Syncfusion.WinForms.Controls.SfButton sfButtonCreate;
        private Syncfusion.WinForms.Controls.SfButton sfButtonEdit;
        private Syncfusion.WinForms.Controls.SfButton sfButtonDelete;
        private Syncfusion.WinForms.Controls.SfButton sfButtonExport;
        private Syncfusion.WinForms.Controls.SfButton sfButtonTemplateImport;
        private Syncfusion.WinForms.Controls.SfButton sfButtonTemplateGenerate;
    }
}