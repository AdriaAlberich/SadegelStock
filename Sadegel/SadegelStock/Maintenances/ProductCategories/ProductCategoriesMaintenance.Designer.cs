namespace SadegelStock
{
    partial class ProductCategoriesMaintenance
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
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn2 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            this.sfDataGridCategories = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfButtonExport = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonDelete = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonEdit = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButtonCreate = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGridCategories
            // 
            this.sfDataGridCategories.AccessibleName = "Table";
            this.sfDataGridCategories.AllowEditing = false;
            this.sfDataGridCategories.AllowFiltering = true;
            this.sfDataGridCategories.AllowGrouping = false;
            this.sfDataGridCategories.AllowResizingColumns = true;
            this.sfDataGridCategories.AutoGenerateColumns = false;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.AllowGrouping = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.HeaderText = "# Id";
            gridTextColumn1.MappingName = "id";
            gridTextColumn1.Width = 100D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.AllowGrouping = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Nom";
            gridTextColumn2.MappingName = "Nom";
            gridTextColumn2.Width = 216D;
            gridDateTimeColumn1.AllowEditing = false;
            gridDateTimeColumn1.AllowFiltering = true;
            gridDateTimeColumn1.AllowGrouping = false;
            gridDateTimeColumn1.AllowResizing = true;
            gridDateTimeColumn1.HeaderText = "Creat";
            gridDateTimeColumn1.MappingName = "Creat";
            gridDateTimeColumn1.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.Width = 142D;
            gridDateTimeColumn2.AllowEditing = false;
            gridDateTimeColumn2.AllowFiltering = true;
            gridDateTimeColumn2.AllowGrouping = false;
            gridDateTimeColumn2.AllowResizing = true;
            gridDateTimeColumn2.HeaderText = "Actualitzat";
            gridDateTimeColumn2.MappingName = "Actualitzat";
            gridDateTimeColumn2.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn2.Width = 142D;
            this.sfDataGridCategories.Columns.Add(gridTextColumn1);
            this.sfDataGridCategories.Columns.Add(gridTextColumn2);
            this.sfDataGridCategories.Columns.Add(gridDateTimeColumn1);
            this.sfDataGridCategories.Columns.Add(gridDateTimeColumn2);
            this.sfDataGridCategories.Location = new System.Drawing.Point(14, 5);
            this.sfDataGridCategories.Name = "sfDataGridCategories";
            this.sfDataGridCategories.Size = new System.Drawing.Size(402, 396);
            this.sfDataGridCategories.TabIndex = 0;
            this.sfDataGridCategories.Text = "sfDataGridShops";
            this.sfDataGridCategories.Click += new System.EventHandler(this.sfDataGridCategories_Click);
            // 
            // sfButtonExport
            // 
            this.sfButtonExport.AccessibleName = "Button";
            this.sfButtonExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonExport.Location = new System.Drawing.Point(320, 407);
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
            // ProductCategoriesMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 441);
            this.Controls.Add(this.sfButtonExport);
            this.Controls.Add(this.sfButtonDelete);
            this.Controls.Add(this.sfButtonEdit);
            this.Controls.Add(this.sfButtonCreate);
            this.Controls.Add(this.sfDataGridCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductCategoriesMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manteniment Categories";
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridCategories;
        private Syncfusion.WinForms.Controls.SfButton sfButtonCreate;
        private Syncfusion.WinForms.Controls.SfButton sfButtonEdit;
        private Syncfusion.WinForms.Controls.SfButton sfButtonDelete;
        private Syncfusion.WinForms.Controls.SfButton sfButtonExport;
    }
}