namespace SadegelStock
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            Syncfusion.Windows.Forms.Tools.TreeNavigator.HeaderCollection headerCollection1 = new Syncfusion.Windows.Forms.Tools.TreeNavigator.HeaderCollection();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn9 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn10 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn2 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            this.menu = new Syncfusion.Windows.Forms.Tools.TreeNavigator();
            this.controlItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.inventoryItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.reportItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.maintenanceItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.shopsItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.productsItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.alertItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.eventlogItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.shopiventoryItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.shopItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.productItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.providerItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.categoryItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.countryItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.roleItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.userItem = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.grdEventLogBot = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.grdEventLogStock = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.shopMaintenance = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.shops = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.products = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.shopsMaintenanceOption = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.productsMaintenanceOption = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.categoriesMaintenanceOption = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.providersMaintenanceOption = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.countriesMaintenanceOption = new Syncfusion.Windows.Forms.Tools.TreeMenuItem();
            this.lblBot = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdEventLogBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEventLogStock)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menu.BorderThickness = 0;
            this.menu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            headerCollection1.Font = new System.Drawing.Font("Arial", 8F);
            headerCollection1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            headerCollection1.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.menu.Header = headerCollection1;
            this.menu.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menu.Items.Add(this.controlItem);
            this.menu.Items.Add(this.inventoryItem);
            this.menu.Items.Add(this.reportItem);
            this.menu.Items.Add(this.maintenanceItem);
            this.menu.Location = new System.Drawing.Point(5, 5);
            this.menu.MinimumSize = new System.Drawing.Size(150, 150);
            this.menu.Name = "menu";
            this.menu.ShowHeader = false;
            this.menu.Size = new System.Drawing.Size(209, 467);
            this.menu.Style = Syncfusion.Windows.Forms.Tools.TreeNavigatorStyle.Office2016White;
            this.menu.TabIndex = 1;
            this.menu.Text = "Menú";
            this.menu.ThemeName = "Office2016White";
            this.menu.SelectionChanged += new Syncfusion.Windows.Forms.Tools.SelectionStateChangedEventHandler(this.menu_SelectionChanged);
            // 
            // controlItem
            // 
            this.controlItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.controlItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.controlItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.controlItem.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.controlItem.Location = new System.Drawing.Point(0, 0);
            this.controlItem.Name = "controlItem";
            this.controlItem.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.controlItem.SelectedItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.controlItem.Size = new System.Drawing.Size(205, 50);
            this.controlItem.TabIndex = 1;
            this.controlItem.Text = "Seguiment";
            this.controlItem.Click += new System.EventHandler(this.controlItem_Click);
            // 
            // inventoryItem
            // 
            this.inventoryItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.inventoryItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.inventoryItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.inventoryItem.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.inventoryItem.Location = new System.Drawing.Point(0, 52);
            this.inventoryItem.Name = "inventoryItem";
            this.inventoryItem.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.inventoryItem.SelectedItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.inventoryItem.Size = new System.Drawing.Size(205, 50);
            this.inventoryItem.TabIndex = 1;
            this.inventoryItem.Text = "Inventari";
            // 
            // reportItem
            // 
            this.reportItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.reportItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.reportItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.reportItem.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.reportItem.Location = new System.Drawing.Point(0, 104);
            this.reportItem.Name = "reportItem";
            this.reportItem.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.reportItem.SelectedItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.reportItem.Size = new System.Drawing.Size(205, 50);
            this.reportItem.TabIndex = 1;
            this.reportItem.Text = "Informes";
            // 
            // maintenanceItem
            // 
            this.maintenanceItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.maintenanceItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintenanceItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.maintenanceItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.maintenanceItem.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.maintenanceItem.Location = new System.Drawing.Point(0, 156);
            this.maintenanceItem.Name = "maintenanceItem";
            this.maintenanceItem.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.maintenanceItem.SelectedItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.maintenanceItem.Size = new System.Drawing.Size(205, 50);
            this.maintenanceItem.TabIndex = 1;
            this.maintenanceItem.Text = "Manteniments";
            // 
            // shopsItem
            // 
            this.shopsItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.shopsItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.shopsItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.shopsItem.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.shopsItem.Location = new System.Drawing.Point(0, 0);
            this.shopsItem.Name = "shopsItem";
            this.shopsItem.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.shopsItem.SelectedItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.shopsItem.Size = new System.Drawing.Size(0, 0);
            this.shopsItem.TabIndex = 1;
            this.shopsItem.Text = "Establiments";
            // 
            // productsItem
            // 
            this.productsItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.productsItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.productsItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.productsItem.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.productsItem.Location = new System.Drawing.Point(0, 0);
            this.productsItem.Name = "productsItem";
            this.productsItem.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.productsItem.SelectedItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.productsItem.Size = new System.Drawing.Size(0, 0);
            this.productsItem.TabIndex = 1;
            this.productsItem.Text = "Productes";
            // 
            // alertItem
            // 
            this.alertItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.alertItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.alertItem.Location = new System.Drawing.Point(0, 0);
            this.alertItem.Name = "alertItem";
            this.alertItem.Size = new System.Drawing.Size(0, 0);
            this.alertItem.TabIndex = 1;
            this.alertItem.Text = "Alertes";
            // 
            // eventlogItem
            // 
            this.eventlogItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.eventlogItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventlogItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.eventlogItem.Location = new System.Drawing.Point(0, 0);
            this.eventlogItem.Name = "eventlogItem";
            this.eventlogItem.Size = new System.Drawing.Size(0, 0);
            this.eventlogItem.TabIndex = 1;
            this.eventlogItem.Text = "Esdeveniments";
            // 
            // shopiventoryItem
            // 
            this.shopiventoryItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopiventoryItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.shopiventoryItem.Location = new System.Drawing.Point(0, 0);
            this.shopiventoryItem.Name = "shopiventoryItem";
            this.shopiventoryItem.Size = new System.Drawing.Size(0, 0);
            this.shopiventoryItem.TabIndex = 0;
            this.shopiventoryItem.Text = "Establiments";
            // 
            // shopItem
            // 
            this.shopItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.shopItem.Location = new System.Drawing.Point(0, 0);
            this.shopItem.Name = "shopItem";
            this.shopItem.Size = new System.Drawing.Size(0, 0);
            this.shopItem.TabIndex = 0;
            this.shopItem.Text = "Establiments";
            // 
            // productItem
            // 
            this.productItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.productItem.Location = new System.Drawing.Point(0, 0);
            this.productItem.Name = "productItem";
            this.productItem.Size = new System.Drawing.Size(0, 0);
            this.productItem.TabIndex = 0;
            this.productItem.Text = "Productes";
            // 
            // providerItem
            // 
            this.providerItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.providerItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.providerItem.Location = new System.Drawing.Point(0, 0);
            this.providerItem.Name = "providerItem";
            this.providerItem.Size = new System.Drawing.Size(0, 0);
            this.providerItem.TabIndex = 0;
            this.providerItem.Text = "Proveïdors";
            // 
            // categoryItem
            // 
            this.categoryItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.categoryItem.Location = new System.Drawing.Point(0, 0);
            this.categoryItem.Name = "categoryItem";
            this.categoryItem.Size = new System.Drawing.Size(0, 0);
            this.categoryItem.TabIndex = 0;
            this.categoryItem.Text = "Categories de productes";
            // 
            // countryItem
            // 
            this.countryItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.countryItem.Location = new System.Drawing.Point(0, 0);
            this.countryItem.Name = "countryItem";
            this.countryItem.Size = new System.Drawing.Size(0, 0);
            this.countryItem.TabIndex = 0;
            this.countryItem.Text = "Països";
            // 
            // roleItem
            // 
            this.roleItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.roleItem.Location = new System.Drawing.Point(0, 0);
            this.roleItem.Name = "roleItem";
            this.roleItem.Size = new System.Drawing.Size(0, 0);
            this.roleItem.TabIndex = 0;
            this.roleItem.Text = "Rols";
            // 
            // userItem
            // 
            this.userItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userItem.ItemBackColor = System.Drawing.SystemColors.Control;
            this.userItem.Location = new System.Drawing.Point(0, 0);
            this.userItem.Name = "userItem";
            this.userItem.Size = new System.Drawing.Size(0, 0);
            this.userItem.TabIndex = 0;
            this.userItem.Text = "Usuaris";
            // 
            // grdEventLogBot
            // 
            this.grdEventLogBot.AccessibleName = "Table";
            this.grdEventLogBot.AutoGenerateColumns = false;
            gridTextColumn1.HeaderText = "Missatge";
            gridTextColumn1.MappingName = "Missatge";
            gridTextColumn1.Width = 700D;
            gridTextColumn2.HeaderText = "Establiment";
            gridTextColumn2.MappingName = "Establiment";
            gridTextColumn2.Width = 150D;
            gridTextColumn3.HeaderText = "Producte";
            gridTextColumn3.MappingName = "Producte";
            gridTextColumn3.Width = 150D;
            gridTextColumn4.HeaderText = "Quantitat";
            gridTextColumn4.MappingName = "Quantitat";
            gridTextColumn4.Width = 100D;
            gridDateTimeColumn1.AllowEditing = false;
            gridDateTimeColumn1.Format = "dd/MM/yyyy HH:mm:ss";
            gridDateTimeColumn1.HeaderText = "Data";
            gridDateTimeColumn1.MappingName = "Data";
            gridDateTimeColumn1.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn1.Width = 150D;
            this.grdEventLogBot.Columns.Add(gridTextColumn1);
            this.grdEventLogBot.Columns.Add(gridTextColumn2);
            this.grdEventLogBot.Columns.Add(gridTextColumn3);
            this.grdEventLogBot.Columns.Add(gridTextColumn4);
            this.grdEventLogBot.Columns.Add(gridDateTimeColumn1);
            this.grdEventLogBot.Location = new System.Drawing.Point(216, 43);
            this.grdEventLogBot.Name = "grdEventLogBot";
            this.grdEventLogBot.Size = new System.Drawing.Size(785, 206);
            this.grdEventLogBot.TabIndex = 2;
            this.grdEventLogBot.Text = "sfDataGridRecentAlerts";
            // 
            // grdEventLogStock
            // 
            this.grdEventLogStock.AccessibleName = "Table";
            this.grdEventLogStock.AutoGenerateColumns = false;
            gridTextColumn5.HeaderText = "Missatge";
            gridTextColumn5.MappingName = "Missatge";
            gridTextColumn5.Width = 700D;
            gridTextColumn6.HeaderText = "PC";
            gridTextColumn6.MappingName = "PC";
            gridTextColumn6.Width = 100D;
            gridTextColumn7.HeaderText = "Usuari";
            gridTextColumn7.MappingName = "Usuari";
            gridTextColumn7.Width = 100D;
            gridTextColumn8.HeaderText = "Establiment";
            gridTextColumn8.MappingName = "Establiment";
            gridTextColumn8.Width = 150D;
            gridTextColumn9.HeaderText = "Producte";
            gridTextColumn9.MappingName = "Producte";
            gridTextColumn9.Width = 150D;
            gridTextColumn10.HeaderText = "Quantitat";
            gridTextColumn10.MappingName = "Quantitat";
            gridTextColumn10.Width = 100D;
            gridDateTimeColumn2.Format = "dd/MM/yyyy H:mm:ss";
            gridDateTimeColumn2.HeaderText = "Data";
            gridDateTimeColumn2.MappingName = "Data";
            gridDateTimeColumn2.MaxDateTime = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn2.Pattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            gridDateTimeColumn2.Width = 150D;
            this.grdEventLogStock.Columns.Add(gridTextColumn5);
            this.grdEventLogStock.Columns.Add(gridTextColumn6);
            this.grdEventLogStock.Columns.Add(gridTextColumn7);
            this.grdEventLogStock.Columns.Add(gridTextColumn8);
            this.grdEventLogStock.Columns.Add(gridTextColumn9);
            this.grdEventLogStock.Columns.Add(gridTextColumn10);
            this.grdEventLogStock.Columns.Add(gridDateTimeColumn2);
            this.grdEventLogStock.Location = new System.Drawing.Point(217, 266);
            this.grdEventLogStock.Name = "grdEventLogStock";
            this.grdEventLogStock.Size = new System.Drawing.Size(785, 206);
            this.grdEventLogStock.TabIndex = 3;
            this.grdEventLogStock.Text = "sfDataGridRecentEvents";
            // 
            // shopMaintenance
            // 
            this.shopMaintenance.ItemBackColor = System.Drawing.SystemColors.Control;
            this.shopMaintenance.Location = new System.Drawing.Point(0, 0);
            this.shopMaintenance.Name = "shopMaintenance";
            this.shopMaintenance.Size = new System.Drawing.Size(0, 0);
            this.shopMaintenance.TabIndex = 1;
            this.shopMaintenance.Text = "Establiments";
            // 
            // shops
            // 
            this.shops.ItemBackColor = System.Drawing.SystemColors.Control;
            this.shops.Location = new System.Drawing.Point(0, 0);
            this.shops.Name = "shops";
            this.shops.Size = new System.Drawing.Size(0, 0);
            this.shops.TabIndex = 1;
            this.shops.Text = "Establiments";
            // 
            // products
            // 
            this.products.ItemBackColor = System.Drawing.SystemColors.Control;
            this.products.Location = new System.Drawing.Point(0, 0);
            this.products.Name = "products";
            this.products.Size = new System.Drawing.Size(0, 0);
            this.products.TabIndex = 1;
            this.products.Text = "Productes";
            // 
            // shopsMaintenanceOption
            // 
            this.shopsMaintenanceOption.ItemBackColor = System.Drawing.SystemColors.Control;
            this.shopsMaintenanceOption.Location = new System.Drawing.Point(0, 0);
            this.shopsMaintenanceOption.Name = "shopsMaintenanceOption";
            this.shopsMaintenanceOption.Size = new System.Drawing.Size(0, 0);
            this.shopsMaintenanceOption.TabIndex = 1;
            this.shopsMaintenanceOption.Text = "Establiments";
            // 
            // productsMaintenanceOption
            // 
            this.productsMaintenanceOption.ItemBackColor = System.Drawing.SystemColors.Control;
            this.productsMaintenanceOption.Location = new System.Drawing.Point(0, 0);
            this.productsMaintenanceOption.Name = "productsMaintenanceOption";
            this.productsMaintenanceOption.Size = new System.Drawing.Size(0, 0);
            this.productsMaintenanceOption.TabIndex = 1;
            this.productsMaintenanceOption.Text = "Productes";
            // 
            // categoriesMaintenanceOption
            // 
            this.categoriesMaintenanceOption.ItemBackColor = System.Drawing.SystemColors.Control;
            this.categoriesMaintenanceOption.Location = new System.Drawing.Point(0, 0);
            this.categoriesMaintenanceOption.Name = "categoriesMaintenanceOption";
            this.categoriesMaintenanceOption.Size = new System.Drawing.Size(0, 0);
            this.categoriesMaintenanceOption.TabIndex = 1;
            this.categoriesMaintenanceOption.Text = "Categories";
            // 
            // providersMaintenanceOption
            // 
            this.providersMaintenanceOption.ItemBackColor = System.Drawing.SystemColors.Control;
            this.providersMaintenanceOption.Location = new System.Drawing.Point(0, 0);
            this.providersMaintenanceOption.Name = "providersMaintenanceOption";
            this.providersMaintenanceOption.Size = new System.Drawing.Size(0, 0);
            this.providersMaintenanceOption.TabIndex = 1;
            this.providersMaintenanceOption.Text = "Proveïdors";
            // 
            // countriesMaintenanceOption
            // 
            this.countriesMaintenanceOption.ItemBackColor = System.Drawing.SystemColors.Control;
            this.countriesMaintenanceOption.Location = new System.Drawing.Point(0, 0);
            this.countriesMaintenanceOption.Name = "countriesMaintenanceOption";
            this.countriesMaintenanceOption.Size = new System.Drawing.Size(0, 0);
            this.countriesMaintenanceOption.TabIndex = 1;
            this.countriesMaintenanceOption.Text = "Països";
            // 
            // lblBot
            // 
            this.lblBot.Location = new System.Drawing.Point(216, 27);
            this.lblBot.Name = "lblBot";
            this.lblBot.Size = new System.Drawing.Size(96, 13);
            this.lblBot.TabIndex = 4;
            this.lblBot.Text = "Últims registres Bot";
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(216, 252);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(108, 13);
            this.autoLabel1.TabIndex = 5;
            this.autoLabel1.Text = "Últims registres Stock";
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 60000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 477);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.lblBot);
            this.Controls.Add(this.grdEventLogStock);
            this.Controls.Add(this.grdEventLogBot);
            this.Controls.Add(this.menu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.grdEventLogBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEventLogStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TreeNavigator menu;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem shopsItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem productsItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem controlItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem alertItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem eventlogItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem inventoryItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem shopiventoryItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem reportItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem maintenanceItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem shopItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem productItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem providerItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem categoryItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem countryItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem roleItem;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem userItem;
        private Syncfusion.WinForms.DataGrid.SfDataGrid grdEventLogBot;
        private Syncfusion.WinForms.DataGrid.SfDataGrid grdEventLogStock;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem shopMaintenance;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem shops;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem products;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem shopsMaintenanceOption;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem productsMaintenanceOption;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem categoriesMaintenanceOption;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem providersMaintenanceOption;
        private Syncfusion.Windows.Forms.Tools.TreeMenuItem countriesMaintenanceOption;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblBot;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Timer mainTimer;
    }
}