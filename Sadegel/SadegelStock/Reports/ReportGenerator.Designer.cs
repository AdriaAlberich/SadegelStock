namespace SadegelStock
{
    partial class ReportGenerator
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
            this.cmbShop = new System.Windows.Forms.ComboBox();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.dateFinal = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.dateInitial = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.sfButtonExport = new Syncfusion.WinForms.Controls.SfButton();
            this.lblShop = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblReport = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblInitialDate = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblFinalDate = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.SuspendLayout();
            // 
            // cmbShop
            // 
            this.cmbShop.FormattingEnabled = true;
            this.cmbShop.Location = new System.Drawing.Point(5, 33);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(389, 21);
            this.cmbShop.TabIndex = 21;
            // 
            // cmbReport
            // 
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Items.AddRange(new object[] {
            "Gelat"});
            this.cmbReport.Location = new System.Drawing.Point(5, 100);
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(389, 21);
            this.cmbReport.TabIndex = 22;
            // 
            // dateFinal
            // 
            this.dateFinal.Location = new System.Drawing.Point(244, 150);
            this.dateFinal.Name = "dateFinal";
            this.dateFinal.Size = new System.Drawing.Size(150, 21);
            this.dateFinal.TabIndex = 24;
            // 
            // dateInitial
            // 
            this.dateInitial.Location = new System.Drawing.Point(5, 150);
            this.dateInitial.Name = "dateInitial";
            this.dateInitial.Size = new System.Drawing.Size(150, 21);
            this.dateInitial.TabIndex = 23;
            // 
            // sfButtonExport
            // 
            this.sfButtonExport.AccessibleName = "Button";
            this.sfButtonExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButtonExport.Location = new System.Drawing.Point(273, 228);
            this.sfButtonExport.Name = "sfButtonExport";
            this.sfButtonExport.Size = new System.Drawing.Size(121, 28);
            this.sfButtonExport.TabIndex = 25;
            this.sfButtonExport.Text = "Generar Informe";
            this.sfButtonExport.Click += new System.EventHandler(this.sfButtonExport_Click);
            // 
            // lblShop
            // 
            this.lblShop.Location = new System.Drawing.Point(5, 14);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(61, 13);
            this.lblShop.TabIndex = 26;
            this.lblShop.Text = "Establiment";
            // 
            // lblReport
            // 
            this.lblReport.Location = new System.Drawing.Point(5, 81);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(42, 13);
            this.lblReport.TabIndex = 27;
            this.lblReport.Text = "Informe";
            // 
            // lblInitialDate
            // 
            this.lblInitialDate.Location = new System.Drawing.Point(5, 131);
            this.lblInitialDate.Name = "lblInitialDate";
            this.lblInitialDate.Size = new System.Drawing.Size(51, 13);
            this.lblInitialDate.TabIndex = 28;
            this.lblInitialDate.Text = "Data inici";
            // 
            // lblFinalDate
            // 
            this.lblFinalDate.Location = new System.Drawing.Point(244, 131);
            this.lblFinalDate.Name = "lblFinalDate";
            this.lblFinalDate.Size = new System.Drawing.Size(38, 13);
            this.lblFinalDate.TabIndex = 29;
            this.lblFinalDate.Text = "Data fi";
            // 
            // ReportGenerator
            // 
            this.ClientSize = new System.Drawing.Size(399, 261);
            this.Controls.Add(this.lblFinalDate);
            this.Controls.Add(this.lblInitialDate);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.sfButtonExport);
            this.Controls.Add(this.dateFinal);
            this.Controls.Add(this.dateInitial);
            this.Controls.Add(this.cmbReport);
            this.Controls.Add(this.cmbShop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbShop;
        private System.Windows.Forms.ComboBox cmbReport;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dateFinal;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dateInitial;
        private Syncfusion.WinForms.Controls.SfButton sfButtonExport;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblShop;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblReport;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblInitialDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblFinalDate;
    }
}