namespace SadegelStock
{
    partial class Control
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
            this.sfDataGridControl = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfButtonExport = new Syncfusion.WinForms.Controls.SfButton();
            this.lblOrigin = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblType = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblInitialDate = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dateInitial = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.dateFinal = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.lblFinalDate = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblTotalLogs = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbOrigin = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbShop = new System.Windows.Forms.ComboBox();
            this.lblShop = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGridControl
            // 
            this.sfDataGridControl.AccessibleName = "Table";
            this.sfDataGridControl.AllowEditing = false;
            this.sfDataGridControl.AllowFiltering = true;
            this.sfDataGridControl.AllowGrouping = false;
            this.sfDataGridControl.AllowResizingColumns = true;
            this.sfDataGridControl.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCellsWithLastColumnFill;
            this.sfDataGridControl.Location = new System.Drawing.Point(14, 5);
            this.sfDataGridControl.Name = "sfDataGridControl";
            this.sfDataGridControl.Size = new System.Drawing.Size(727, 396);
            this.sfDataGridControl.TabIndex = 0;
            this.sfDataGridControl.Text = "sfDataGridShops";
            // 
            // sfButtonExport
            // 
            this.sfButtonExport.AccessibleName = "Button";
            this.sfButtonExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonExport.Location = new System.Drawing.Point(641, 480);
            this.sfButtonExport.Name = "sfButtonExport";
            this.sfButtonExport.Size = new System.Drawing.Size(100, 28);
            this.sfButtonExport.TabIndex = 4;
            this.sfButtonExport.Text = "Exportar Llistat/";
            this.sfButtonExport.Click += new System.EventHandler(this.sfButtonExport_Click);
            // 
            // lblOrigin
            // 
            this.lblOrigin.Location = new System.Drawing.Point(14, 407);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(38, 13);
            this.lblOrigin.TabIndex = 6;
            this.lblOrigin.Text = "Origen";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(14, 460);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(33, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Tipus";
            // 
            // lblInitialDate
            // 
            this.lblInitialDate.Location = new System.Drawing.Point(582, 407);
            this.lblInitialDate.Name = "lblInitialDate";
            this.lblInitialDate.Size = new System.Drawing.Size(51, 13);
            this.lblInitialDate.TabIndex = 10;
            this.lblInitialDate.Text = "Data inici";
            // 
            // dateInitial
            // 
            this.dateInitial.Location = new System.Drawing.Point(639, 407);
            this.dateInitial.Name = "dateInitial";
            this.dateInitial.Size = new System.Drawing.Size(102, 21);
            this.dateInitial.TabIndex = 11;
            this.dateInitial.ValueChanged += new Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventHandler(this.dateInitial_ValueChanged);
            // 
            // dateFinal
            // 
            this.dateFinal.Location = new System.Drawing.Point(639, 442);
            this.dateFinal.Name = "dateFinal";
            this.dateFinal.Size = new System.Drawing.Size(102, 21);
            this.dateFinal.TabIndex = 13;
            this.dateFinal.ValueChanged += new Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventHandler(this.dateFinal_ValueChanged);
            // 
            // lblFinalDate
            // 
            this.lblFinalDate.Location = new System.Drawing.Point(595, 442);
            this.lblFinalDate.Name = "lblFinalDate";
            this.lblFinalDate.Size = new System.Drawing.Size(38, 13);
            this.lblFinalDate.TabIndex = 12;
            this.lblFinalDate.Text = "Data fi";
            // 
            // lblTotalLogs
            // 
            this.lblTotalLogs.Location = new System.Drawing.Point(14, 498);
            this.lblTotalLogs.Name = "lblTotalLogs";
            this.lblTotalLogs.Size = new System.Drawing.Size(61, 13);
            this.lblTotalLogs.TabIndex = 14;
            this.lblTotalLogs.Text = "X Registres";
            // 
            // cmbOrigin
            // 
            this.cmbOrigin.FormattingEnabled = true;
            this.cmbOrigin.Location = new System.Drawing.Point(58, 407);
            this.cmbOrigin.Name = "cmbOrigin";
            this.cmbOrigin.Size = new System.Drawing.Size(121, 21);
            this.cmbOrigin.TabIndex = 15;
            this.cmbOrigin.SelectedIndexChanged += new System.EventHandler(this.cmbOrigin_SelectedIndexChanged);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(58, 460);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 16;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(255, 460);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(321, 21);
            this.cmbProduct.TabIndex = 18;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(188, 460);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(50, 13);
            this.lblProduct.TabIndex = 17;
            this.lblProduct.Text = "Producte";
            // 
            // cmbShop
            // 
            this.cmbShop.FormattingEnabled = true;
            this.cmbShop.Location = new System.Drawing.Point(255, 407);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(321, 21);
            this.cmbShop.TabIndex = 20;
            this.cmbShop.SelectedIndexChanged += new System.EventHandler(this.cmbShop_SelectedIndexChanged);
            // 
            // lblShop
            // 
            this.lblShop.Location = new System.Drawing.Point(188, 407);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(61, 13);
            this.lblShop.TabIndex = 19;
            this.lblShop.Text = "Establiment";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 513);
            this.Controls.Add(this.cmbShop);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbOrigin);
            this.Controls.Add(this.lblTotalLogs);
            this.Controls.Add(this.dateFinal);
            this.Controls.Add(this.lblFinalDate);
            this.Controls.Add(this.dateInitial);
            this.Controls.Add(this.lblInitialDate);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.sfButtonExport);
            this.Controls.Add(this.sfDataGridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Control";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seguiment";
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridControl;
        private Syncfusion.WinForms.Controls.SfButton sfButtonExport;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblOrigin;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblType;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblInitialDate;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dateInitial;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dateFinal;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblFinalDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblTotalLogs;
        private System.Windows.Forms.ComboBox cmbOrigin;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbProduct;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProduct;
        private System.Windows.Forms.ComboBox cmbShop;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblShop;
    }
}