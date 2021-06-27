namespace SadegelStock
{
    partial class ShopInput
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
            this.txtId = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblId = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblType = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblTPV = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbTPV = new System.Windows.Forms.ComboBox();
            this.panelAddress = new System.Windows.Forms.Panel();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCity = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblCity = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCP = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblCP = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtNumber = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblNumber = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblStreet = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtStreet = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblAddress = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            this.panelAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStreet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BeforeTouchSize = new System.Drawing.Size(288, 20);
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(25, 29);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(41, 20);
            this.txtId.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(5, 33);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(14, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "#";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(82, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Nom";
            // 
            // txtName
            // 
            this.txtName.BeforeTouchSize = new System.Drawing.Size(288, 20);
            this.txtName.Location = new System.Drawing.Point(117, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(5, 68);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(33, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Tipus";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Propi",
            "Franquícia",
            "Internacional"});
            this.cmbType.Location = new System.Drawing.Point(44, 65);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 5;
            // 
            // lblTPV
            // 
            this.lblTPV.Location = new System.Drawing.Point(171, 68);
            this.lblTPV.Name = "lblTPV";
            this.lblTPV.Size = new System.Drawing.Size(28, 13);
            this.lblTPV.TabIndex = 6;
            this.lblTPV.Text = "TPV";
            // 
            // cmbTPV
            // 
            this.cmbTPV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTPV.FormattingEnabled = true;
            this.cmbTPV.Items.AddRange(new object[] {
            "Techniweb"});
            this.cmbTPV.Location = new System.Drawing.Point(205, 65);
            this.cmbTPV.Name = "cmbTPV";
            this.cmbTPV.Size = new System.Drawing.Size(139, 21);
            this.cmbTPV.TabIndex = 7;
            // 
            // panelAddress
            // 
            this.panelAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAddress.Controls.Add(this.cmbCountry);
            this.panelAddress.Controls.Add(this.lblCountry);
            this.panelAddress.Controls.Add(this.txtCity);
            this.panelAddress.Controls.Add(this.lblCity);
            this.panelAddress.Controls.Add(this.txtCP);
            this.panelAddress.Controls.Add(this.lblCP);
            this.panelAddress.Controls.Add(this.txtNumber);
            this.panelAddress.Controls.Add(this.lblNumber);
            this.panelAddress.Controls.Add(this.lblStreet);
            this.panelAddress.Controls.Add(this.txtStreet);
            this.panelAddress.Location = new System.Drawing.Point(5, 132);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Size = new System.Drawing.Size(339, 125);
            this.panelAddress.TabIndex = 8;
            this.panelAddress.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Items.AddRange(new object[] {
            "SPAIN"});
            this.cmbCountry.Location = new System.Drawing.Point(59, 94);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(275, 21);
            this.cmbCountry.TabIndex = 10;
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(11, 96);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(29, 13);
            this.lblCountry.TabIndex = 10;
            this.lblCountry.Text = "País";
            // 
            // txtCity
            // 
            this.txtCity.BeforeTouchSize = new System.Drawing.Size(288, 20);
            this.txtCity.Location = new System.Drawing.Point(59, 65);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(277, 20);
            this.txtCity.TabIndex = 15;
            // 
            // lblCity
            // 
            this.lblCity.Location = new System.Drawing.Point(11, 68);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(48, 13);
            this.lblCity.TabIndex = 14;
            this.lblCity.Text = "Població";
            // 
            // txtCP
            // 
            this.txtCP.BeforeTouchSize = new System.Drawing.Size(288, 20);
            this.txtCP.Location = new System.Drawing.Point(219, 39);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(117, 20);
            this.txtCP.TabIndex = 13;
            // 
            // lblCP
            // 
            this.lblCP.Location = new System.Drawing.Point(192, 42);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(21, 13);
            this.lblCP.TabIndex = 12;
            this.lblCP.Text = "CP";
            // 
            // txtNumber
            // 
            this.txtNumber.BeforeTouchSize = new System.Drawing.Size(288, 20);
            this.txtNumber.Location = new System.Drawing.Point(59, 39);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(124, 20);
            this.txtNumber.TabIndex = 11;
            // 
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(11, 42);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 10;
            this.lblNumber.Text = "Numero";
            // 
            // lblStreet
            // 
            this.lblStreet.Location = new System.Drawing.Point(11, 9);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(35, 13);
            this.lblStreet.TabIndex = 9;
            this.lblStreet.Text = "Carrer";
            // 
            // txtStreet
            // 
            this.txtStreet.BeforeTouchSize = new System.Drawing.Size(288, 20);
            this.txtStreet.Location = new System.Drawing.Point(48, 6);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(288, 20);
            this.txtStreet.TabIndex = 9;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(5, 108);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(77, 24);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Adreça";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleName = "Button";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnAdd.Location = new System.Drawing.Point(5, 263);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 28);
            this.btnAdd.Style.Image = global::SadegelStock.Properties.Resources.success;
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Afegir";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnCancel.Location = new System.Drawing.Point(248, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 28);
            this.btnCancel.Style.Image = global::SadegelStock.Properties.Resources.error;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel·lar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ShopInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 292);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.panelAddress);
            this.Controls.Add(this.cmbTPV);
            this.Controls.Add(this.lblTPV);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShopInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShopInput";
            ((System.ComponentModel.ISupportInitialize)(this.txtId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            this.panelAddress.ResumeLayout(false);
            this.panelAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStreet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtId;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblId;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblTPV;
        private System.Windows.Forms.ComboBox cmbTPV;
        private System.Windows.Forms.Panel panelAddress;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCity;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblCity;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCP;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblCP;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNumber;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblNumber;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblStreet;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtStreet;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblAddress;
        private System.Windows.Forms.ComboBox cmbCountry;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblCountry;
        private Syncfusion.WinForms.Controls.SfButton btnAdd;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
    }
}