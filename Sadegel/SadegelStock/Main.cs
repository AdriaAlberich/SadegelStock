using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using SadegelCore;
using Syncfusion.Windows.Forms.Tools;

namespace SadegelStock
{
    public partial class Main : SfForm
    {
        public Main()
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
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Left;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.ShowIcon = false;

            TreeMenuItem ShopSubOption = new TreeMenuItem();
            ShopSubOption.Text = "Establiments";
            ShopSubOption.Name = "shopsMaintenance";
            ShopSubOption.Parent = maintenanceItem;
            maintenanceItem.Items.Add(ShopSubOption);

            TreeMenuItem ProductsSubOption = new TreeMenuItem();
            ProductsSubOption.Text = "Productes";
            ProductsSubOption.Name = "productsMaintenance";
            ProductsSubOption.Parent = maintenanceItem;
            maintenanceItem.Items.Add(ProductsSubOption);

            TreeMenuItem CategoriesSubOption = new TreeMenuItem();
            CategoriesSubOption.Text = "Categories";
            CategoriesSubOption.Name = "categoriesMaintenance";
            CategoriesSubOption.Parent = maintenanceItem;
            maintenanceItem.Items.Add(CategoriesSubOption);

            TreeMenuItem ProviderSubOption = new TreeMenuItem();
            ProviderSubOption.Text = "Proveïdors";
            ProviderSubOption.Name = "providersMaintenance";
            ProviderSubOption.Parent = maintenanceItem;
            maintenanceItem.Items.Add(ProviderSubOption);

            TreeMenuItem CountrySubOption = new TreeMenuItem();
            CountrySubOption.Text = "Països";
            CountrySubOption.Name = "countriesMaintenance";
            CountrySubOption.Parent = maintenanceItem;
            maintenanceItem.Items.Add(CountrySubOption);

            this.Text = "Sadegel Stock " + Application.ProductVersion + " | Connexió amb base de dades: " + (Util.CheckDBConnection() ? "Si" : "No") + " | © Sadegel S.L";

            SadegelCore.Main.Initialize();
            UpdateData();
            UpdateEventLogs();
        }

        private void controlItem_Click(object sender, EventArgs e)
        {

        }

        private void menu_SelectionChanged(Syncfusion.Windows.Forms.Tools.TreeNavigator sender, Syncfusion.Windows.Forms.Tools.SelectionStateChangedEventArgs e)
        {
            string SelectedItemId = e.SelectedItem.Name;
            switch(SelectedItemId)
            {
                case "controlItem":
                    {
                        SfForm Control = new Control();
                        Control.ShowDialog();
                        break;
                    }
                case "inventoryItem":
                    {
                        SfForm SearchShopForm = new TextInput("Escriu en numero de l'establiment o el nom");
                        SearchShopForm.ShowDialog();
                        string Response = Program.InputResponse;
                        if (Response != string.Empty)
                        {
                            Shop Shop = null;
                            if(Util.IsNumeric(Response))
                            {
                                Shop = Shop.FindById(uint.Parse(Response));
                            }
                            else
                            {
                                Shop = Shop.FindByNamePart(Response);
                            }

                            if (Shop != null)
                            {
                                SfForm Inventory = new Inventory(Shop);
                                Inventory.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No s'ha trobat cap establiment", "Inventari", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    }
                case "reportItem":
                    {
                        SfForm ReportGenerator = new ReportGenerator();
                        ReportGenerator.ShowDialog();
                        break;
                    }
                case "shopsMaintenance":
                    {
                        SfForm ShopMaintenance = new ShopMaintenance();
                        ShopMaintenance.ShowDialog();
                        break;
                    }
                case "productsMaintenance":
                    {
                        SfForm ProductMaintenance = new ProductMaintenance();
                        ProductMaintenance.ShowDialog();
                        break;
                    }
                case "categoriesMaintenance":
                    {
                        SfForm CategoryMaintenance = new ProductCategoriesMaintenance();
                        CategoryMaintenance.ShowDialog();
                        break;
                    }
                case "providersMaintenance":
                    {
                        SfForm ProviderMaintenance = new ProviderMaintenance();
                        ProviderMaintenance.ShowDialog();
                        break;
                    }
                case "countriesMaintenance":
                    {
                        SfForm CountryMaintenance = new CountriesMaintenance();
                        CountryMaintenance.ShowDialog();
                        break;
                    }

            }

            menu.ResetSelectedItem();
            

        }

        private void UpdateData()
        {
            Country.LoadAll();
            ProductCategory.LoadAll();
            Product.LoadAll();
            Shop.LoadAll();
            Provider.LoadAll();
            Role.LoadAll();
        }

        private void UpdateEventLogs()
        {
            List<EventLogModel> RecentBotLogs = Logs.GetEventLog(10, EventLogOrigin.SadegelBot);
            grdEventLogBot.DataSource = new BindingSource(RecentBotLogs, null);
            grdEventLogBot.Refresh();

            List<EventLogModel> RecentStockLogs = Logs.GetEventLog(10, EventLogOrigin.SadegelStock);
            grdEventLogStock.DataSource = new BindingSource(RecentStockLogs, null);
            grdEventLogStock.Refresh();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            UpdateData();
            UpdateEventLogs();
        }
    }
}
