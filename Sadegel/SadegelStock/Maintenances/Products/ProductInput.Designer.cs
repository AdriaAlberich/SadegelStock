namespace SadegelStock
{
    partial class ProductInput
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
            Syncfusion.WinForms.DataGrid.GridCheckBoxColumn gridCheckBoxColumn1 = new Syncfusion.WinForms.DataGrid.GridCheckBoxColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.txtId = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblId = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblType = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblUnit = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.panelIdentifiers = new System.Windows.Forms.Panel();
            this.btnIdentifiersDel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnIdentifiersAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.lstIdentifiers = new System.Windows.Forms.ListBox();
            this.lblIdentifiers = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblWeight = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtWeight = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblIngredients = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.grdIngredients = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.btnIngredientAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.btnIngredientDel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnProviderDel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnProviderAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.grdProviders = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.lblProviders = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.chkIsIcecream = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            this.panelIdentifiers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BeforeTouchSize = new System.Drawing.Size(121, 20);
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
            this.txtName.BeforeTouchSize = new System.Drawing.Size(121, 20);
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
            "Materia primera",
            "Produït",
            "Consumible"});
            this.cmbType.Location = new System.Drawing.Point(44, 65);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 5;
            // 
            // lblUnit
            // 
            this.lblUnit.Location = new System.Drawing.Point(176, 99);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(35, 13);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "Unitat";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(215, 96);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(129, 21);
            this.cmbUnit.TabIndex = 7;
            // 
            // panelIdentifiers
            // 
            this.panelIdentifiers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIdentifiers.Controls.Add(this.btnIdentifiersDel);
            this.panelIdentifiers.Controls.Add(this.btnIdentifiersAdd);
            this.panelIdentifiers.Controls.Add(this.lstIdentifiers);
            this.panelIdentifiers.Location = new System.Drawing.Point(5, 216);
            this.panelIdentifiers.Name = "panelIdentifiers";
            this.panelIdentifiers.Size = new System.Drawing.Size(339, 125);
            this.panelIdentifiers.TabIndex = 8;
            this.panelIdentifiers.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnIdentifiersDel
            // 
            this.btnIdentifiersDel.AccessibleName = "Button";
            this.btnIdentifiersDel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnIdentifiersDel.Location = new System.Drawing.Point(306, 96);
            this.btnIdentifiersDel.Name = "btnIdentifiersDel";
            this.btnIdentifiersDel.Size = new System.Drawing.Size(32, 28);
            this.btnIdentifiersDel.TabIndex = 2;
            this.btnIdentifiersDel.Text = "-";
            this.btnIdentifiersDel.Click += new System.EventHandler(this.btnIdentifiersDel_Click);
            // 
            // btnIdentifiersAdd
            // 
            this.btnIdentifiersAdd.AccessibleName = "Button";
            this.btnIdentifiersAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnIdentifiersAdd.Location = new System.Drawing.Point(306, -1);
            this.btnIdentifiersAdd.Name = "btnIdentifiersAdd";
            this.btnIdentifiersAdd.Size = new System.Drawing.Size(32, 28);
            this.btnIdentifiersAdd.TabIndex = 1;
            this.btnIdentifiersAdd.Text = "+";
            this.btnIdentifiersAdd.Click += new System.EventHandler(this.btnIdentifiersAdd_Click);
            // 
            // lstIdentifiers
            // 
            this.lstIdentifiers.FormattingEnabled = true;
            this.lstIdentifiers.Location = new System.Drawing.Point(-1, 1);
            this.lstIdentifiers.Name = "lstIdentifiers";
            this.lstIdentifiers.Size = new System.Drawing.Size(301, 121);
            this.lstIdentifiers.TabIndex = 0;
            // 
            // lblIdentifiers
            // 
            this.lblIdentifiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentifiers.Location = new System.Drawing.Point(5, 191);
            this.lblIdentifiers.Name = "lblIdentifiers";
            this.lblIdentifiers.Size = new System.Drawing.Size(134, 24);
            this.lblIdentifiers.TabIndex = 9;
            this.lblIdentifiers.Text = "Identificadors";
            // 
            // lblWeight
            // 
            this.lblWeight.Location = new System.Drawing.Point(8, 99);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(25, 13);
            this.lblWeight.TabIndex = 12;
            this.lblWeight.Text = "Pes";
            // 
            // txtWeight
            // 
            this.txtWeight.BeforeTouchSize = new System.Drawing.Size(121, 20);
            this.txtWeight.Location = new System.Drawing.Point(44, 96);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(121, 20);
            this.txtWeight.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnCancel.Location = new System.Drawing.Point(593, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 28);
            this.btnCancel.Style.Image = global::SadegelStock.Properties.Resources.error;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel·lar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleName = "Button";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnAdd.Location = new System.Drawing.Point(5, 347);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 28);
            this.btnAdd.Style.Image = global::SadegelStock.Properties.Resources.success;
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Afegir";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Materia primera",
            "Produït",
            "Consumible"});
            this.cmbCategory.Location = new System.Drawing.Point(223, 65);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 15;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(171, 68);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 14;
            this.lblCategory.Text = "Categoria";
            // 
            // lblIngredients
            // 
            this.lblIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredients.Location = new System.Drawing.Point(350, 191);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(114, 24);
            this.lblIngredients.TabIndex = 17;
            this.lblIngredients.Text = "Ingredients";
            // 
            // grdIngredients
            // 
            this.grdIngredients.AccessibleName = "Table";
            gridTextColumn1.HeaderText = "Nom";
            gridTextColumn1.MappingName = "Name";
            gridTextColumn1.Width = 200D;
            gridTextColumn2.HeaderText = "Quantitat";
            gridTextColumn2.MappingName = "Quantity";
            gridTextColumn2.Width = 99D;
            gridCheckBoxColumn1.HeaderText = "Unitat";
            gridCheckBoxColumn1.MappingName = "Unit";
            this.grdIngredients.Columns.Add(gridTextColumn1);
            this.grdIngredients.Columns.Add(gridTextColumn2);
            this.grdIngredients.Columns.Add(gridCheckBoxColumn1);
            this.grdIngredients.Location = new System.Drawing.Point(350, 216);
            this.grdIngredients.Name = "grdIngredients";
            this.grdIngredients.Size = new System.Drawing.Size(301, 125);
            this.grdIngredients.TabIndex = 18;
            this.grdIngredients.Text = "sfDataGrid1";
            this.grdIngredients.CellCheckBoxClick += new Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventHandler(this.grdIngredients_CellCheckBoxClick);
            // 
            // btnIngredientAdd
            // 
            this.btnIngredientAdd.AccessibleName = "Button";
            this.btnIngredientAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnIngredientAdd.Location = new System.Drawing.Point(657, 216);
            this.btnIngredientAdd.Name = "btnIngredientAdd";
            this.btnIngredientAdd.Size = new System.Drawing.Size(32, 28);
            this.btnIngredientAdd.TabIndex = 3;
            this.btnIngredientAdd.Text = "+";
            this.btnIngredientAdd.Click += new System.EventHandler(this.btnIngredientAdd_Click);
            // 
            // btnIngredientDel
            // 
            this.btnIngredientDel.AccessibleName = "Button";
            this.btnIngredientDel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnIngredientDel.Location = new System.Drawing.Point(657, 313);
            this.btnIngredientDel.Name = "btnIngredientDel";
            this.btnIngredientDel.Size = new System.Drawing.Size(32, 28);
            this.btnIngredientDel.TabIndex = 3;
            this.btnIngredientDel.Text = "-";
            this.btnIngredientDel.Click += new System.EventHandler(this.btnIngredientDel_Click);
            // 
            // btnProviderDel
            // 
            this.btnProviderDel.AccessibleName = "Button";
            this.btnProviderDel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnProviderDel.Location = new System.Drawing.Point(657, 151);
            this.btnProviderDel.Name = "btnProviderDel";
            this.btnProviderDel.Size = new System.Drawing.Size(32, 28);
            this.btnProviderDel.TabIndex = 19;
            this.btnProviderDel.Text = "-";
            this.btnProviderDel.Click += new System.EventHandler(this.btnProviderDel_Click);
            // 
            // btnProviderAdd
            // 
            this.btnProviderAdd.AccessibleName = "Button";
            this.btnProviderAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnProviderAdd.Location = new System.Drawing.Point(657, 54);
            this.btnProviderAdd.Name = "btnProviderAdd";
            this.btnProviderAdd.Size = new System.Drawing.Size(32, 28);
            this.btnProviderAdd.TabIndex = 20;
            this.btnProviderAdd.Text = "+";
            this.btnProviderAdd.Click += new System.EventHandler(this.btnProviderAdd_Click);
            // 
            // grdProviders
            // 
            this.grdProviders.AccessibleName = "Table";
            gridTextColumn3.HeaderText = "Nom";
            gridTextColumn3.MappingName = "Name";
            gridTextColumn3.Width = 200D;
            gridTextColumn4.HeaderText = "Preu";
            gridTextColumn4.MappingName = "Price";
            gridTextColumn4.Width = 99D;
            this.grdProviders.Columns.Add(gridTextColumn3);
            this.grdProviders.Columns.Add(gridTextColumn4);
            this.grdProviders.Location = new System.Drawing.Point(350, 54);
            this.grdProviders.Name = "grdProviders";
            this.grdProviders.Size = new System.Drawing.Size(301, 125);
            this.grdProviders.TabIndex = 22;
            this.grdProviders.Text = "sfDataGrid1";
            // 
            // lblProviders
            // 
            this.lblProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProviders.Location = new System.Drawing.Point(350, 29);
            this.lblProviders.Name = "lblProviders";
            this.lblProviders.Size = new System.Drawing.Size(110, 24);
            this.lblProviders.TabIndex = 21;
            this.lblProviders.Text = "Proveïdors";
            // 
            // chkIsIcecream
            // 
            this.chkIsIcecream.AutoSize = true;
            this.chkIsIcecream.Location = new System.Drawing.Point(264, 123);
            this.chkIsIcecream.Name = "chkIsIcecream";
            this.chkIsIcecream.Size = new System.Drawing.Size(70, 17);
            this.chkIsIcecream.TabIndex = 24;
            this.chkIsIcecream.Text = "Es gelat?";
            this.chkIsIcecream.UseVisualStyleBackColor = true;
            // 
            // ProductInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 382);
            this.Controls.Add(this.chkIsIcecream);
            this.Controls.Add(this.btnProviderDel);
            this.Controls.Add(this.btnProviderAdd);
            this.Controls.Add(this.grdProviders);
            this.Controls.Add(this.lblProviders);
            this.Controls.Add(this.btnIngredientDel);
            this.Controls.Add(this.btnIngredientAdd);
            this.Controls.Add(this.grdIngredients);
            this.Controls.Add(this.lblIngredients);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblIdentifiers);
            this.Controls.Add(this.panelIdentifiers);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProductInput";
            ((System.ComponentModel.ISupportInitialize)(this.txtId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            this.panelIdentifiers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProviders)).EndInit();
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
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Panel panelIdentifiers;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblIdentifiers;
        private Syncfusion.WinForms.Controls.SfButton btnAdd;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblWeight;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtWeight;
        private Syncfusion.WinForms.Controls.SfButton btnIdentifiersDel;
        private Syncfusion.WinForms.Controls.SfButton btnIdentifiersAdd;
        private System.Windows.Forms.ListBox lstIdentifiers;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblCategory;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblIngredients;
        private Syncfusion.WinForms.DataGrid.SfDataGrid grdIngredients;
        private Syncfusion.WinForms.Controls.SfButton btnIngredientAdd;
        private Syncfusion.WinForms.Controls.SfButton btnIngredientDel;
        private Syncfusion.WinForms.Controls.SfButton btnProviderDel;
        private Syncfusion.WinForms.Controls.SfButton btnProviderAdd;
        private Syncfusion.WinForms.DataGrid.SfDataGrid grdProviders;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProviders;
        private System.Windows.Forms.CheckBox chkIsIcecream;
    }
}