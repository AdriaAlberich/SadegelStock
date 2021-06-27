using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using SadegelCore;

namespace SadegelStock
{
    public partial class ProductInput : SfForm
    {
        private class IngredientModel
        {
            public string Name { get; set; }
            public string Quantity { get; set; }
            public bool Unit { get; set; }
        }

        private class ProviderModel
        {
            public string Name { get; set; }
            public string Price { get; set; }
        }

        private bool EditMode = false;
        private Product Product = null;
        public ProductInput(bool EditMode, Product Product)
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
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;

            this.ShowIcon = false;
            this.EditMode = EditMode;
            this.Product = Product;

            this.Text = this.EditMode ? "Modificar Producte " + Product.Name : "Crear nou Producte";

            Dictionary<string, string> ProductTypes = new Dictionary<string, string>();
            ProductTypes.Add("raw", "Materia primera");
            ProductTypes.Add("manufactured", "Elaborat");
            ProductTypes.Add("consumable", "Consumible");

            cmbType.DataSource = new BindingSource(ProductTypes, null);
            cmbType.DisplayMember = "Value";
            cmbType.ValueMember = "Key";
        
            
            Dictionary<string, string> ProductUnits = new Dictionary<string, string>();
            ProductUnits.Add("g", "Gram");
            ProductUnits.Add("kg", "Kilo");
            ProductUnits.Add("l", "Litre");
            ProductUnits.Add("ml", "Mililitre");

            cmbUnit.DataSource = new BindingSource(ProductUnits, null);
            cmbUnit.DisplayMember = "Value";
            cmbUnit.ValueMember = "Key";
            

            List<string> ProductCategories = new List<string>();
            foreach(ProductCategory Category in Globals.ProductCategoryPool)
            {
                ProductCategories.Add(Category.Name);
            }

            cmbCategory.DataSource = new BindingSource(ProductCategories, null);

            if (this.EditMode && Product != null)
            {

                RefreshIdentifiers();

                RefreshIngredients();

                RefreshProviders();

                txtId.Text = Product.Id.ToString();
                txtName.Text = Product.Name;
                cmbType.SelectedValue = Product.Type;
                cmbCategory.Text = Product.Category.Name;
                cmbUnit.SelectedValue = Product.BaseUnit;
                chkIsIcecream.Checked = Product.isIcecream;
                txtWeight.Text = Product.Weight.ToString();
                btnAdd.Text = "Desar";
            }
            else
            {
                lstIdentifiers.Enabled = false;
                btnIdentifiersAdd.Enabled = false;
                btnIdentifiersDel.Enabled = false;
                grdIngredients.Enabled = false;
                btnIngredientAdd.Enabled = false;
                btnIngredientDel.Enabled = false;
                grdProviders.Enabled = false;
                btnProviderAdd.Enabled = false;
                btnProviderDel.Enabled = false;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (this.EditMode && Product != null)
            {
                bool ok = true;

                if(txtName.Text != string.Empty)
                {
                    txtName.BorderColor = SystemColors.Control;
                    Product.Name = txtName.Text;
                }
                else
                {
                    txtName.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if(cmbType.Text != string.Empty)
                {
                    cmbType.BackColor = SystemColors.Control;
                    Product.Type = cmbType.SelectedValue.ToString();
                }
                else
                {
                    cmbType.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (cmbCategory.Text != string.Empty)
                {
                    cmbType.BackColor = SystemColors.Control;
                    Product.Category = ProductCategory.FindByName(cmbCategory.Text);
                }
                else
                {
                    cmbType.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (txtWeight.Text != string.Empty)
                {
                    txtWeight.BorderColor = SystemColors.Control;
                    Product.Weight = float.Parse(txtWeight.Text);
                }
                else
                {
                    txtWeight.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (cmbUnit.Text != string.Empty)
                {
                    cmbUnit.BackColor = SystemColors.Control;
                    Product.BaseUnit = cmbUnit.SelectedValue.ToString();
                }
                else
                {
                    cmbUnit.BackColor = Color.LightCoral;
                    ok = false;
                }

                Product.isIcecream = chkIsIcecream.Checked;

                if (ok)
                {
                    if (Product.Update())
                    {
                        MessageBox.Show("Producte desat correctament", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logs.EventLog("Modificat producte " + Product.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                    }
                    else
                    {
                        MessageBox.Show("Error al desar producte", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Product = new Product();
                bool ok = true;

                if (txtName.Text != string.Empty)
                {
                    txtName.BorderColor = SystemColors.Control;
                    Product.Name = txtName.Text;
                }
                else
                {
                    txtName.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (cmbType.Text != string.Empty)
                {
                    cmbType.BackColor = SystemColors.Control;
                    Product.Type = cmbType.SelectedValue.ToString();
                }
                else
                {
                    cmbType.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (cmbCategory.Text != string.Empty)
                {
                    cmbType.BackColor = SystemColors.Control;
                    Product.Category = ProductCategory.FindByName(cmbCategory.Text);
                }
                else
                {
                    cmbType.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (txtWeight.Text != string.Empty)
                {
                    txtWeight.BorderColor = SystemColors.Control;
                    Product.Weight = float.Parse(txtWeight.Text);
                }
                else
                {
                    txtWeight.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (cmbUnit.Text != string.Empty)
                {
                    cmbUnit.BackColor = SystemColors.Control;
                    Product.BaseUnit = cmbUnit.SelectedValue.ToString();
                }
                else
                {
                    cmbUnit.BackColor = Color.LightCoral;
                    ok = false;
                }

                Product.isIcecream = chkIsIcecream.Checked;

                if (ok)
                {
                    Product = Product.Create(Product.Name, Product.Type, Product.Weight, Product.BaseUnit, Product.Category, Product.isIcecream, Product.Name);

                    if (Product != null)
                    {
                        MessageBox.Show("Producte afegit correctament", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logs.EventLog("Creat nou producte " + Product.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al afegir producte", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            
        }

        private void btnIdentifiersAdd_Click(object sender, EventArgs e)
        {
            SfForm NewIdentifierForm = new TextInput("Afegir identificador");
            NewIdentifierForm.ShowDialog();
            string NewIdentifier = Program.InputResponse;
            if(NewIdentifier != string.Empty)
            {
                if(NewIdentifier.Length <= 32)
                {
                    if(!Product.AddIdentifier(NewIdentifier))
                    {
                        MessageBox.Show("Identificador no vàlid o duplicat. Ha de ser únic.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Logs.EventLog("Afegit identificador " + NewIdentifier + " al producte " + Product.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                        RefreshIdentifiers();
                    }
                }
                else
                {
                    MessageBox.Show("Identificador ha de ser màxim de 32 caràcters alfanumèrics.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIdentifiersDel_Click(object sender, EventArgs e)
        {
            string Identifier = lstIdentifiers.Text;
            if(Identifier != string.Empty)
            {
                if(!Product.RemoveIdentifier(Identifier))
                {
                    MessageBox.Show("Error a l'eliminar l'identificador.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Logs.EventLog("Eliminat identificador " + Identifier + " al producte " + Product.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                    RefreshIdentifiers();
                }
            }
        }

        private void RefreshIdentifiers()
        {
            lstIdentifiers.DataSource = new BindingSource(Product.GetIdentifiersFromProductId(Product.Id), null);
            lstIdentifiers.Refresh();
        }

        private void btnIngredientAdd_Click(object sender, EventArgs e)
        {
            SfForm NewIngredientForm = new TextInput("Codi o nom de l'ingredient (Producte)");
            NewIngredientForm.ShowDialog();
            string NewIngredient = Program.InputResponse;
            if (NewIngredient != string.Empty)
            {
                Product Ingredient = null;
                if (Util.IsNumeric(NewIngredient))
                {
                    Ingredient = Product.FindById(uint.Parse(NewIngredient));
                }
                else
                {
                    Ingredient = Product.FindByNamePart(NewIngredient);
                }

                if (Ingredient != null)
                {
                    SfForm NewIngredientQuantityForm = new TextInput("Quantitat de " + Ingredient.Name + "(en " + Ingredient.BaseUnit + ")");
                    NewIngredientQuantityForm.ShowDialog();
                    string NewIngredientQuantity = Program.InputResponse;
                    if (NewIngredientQuantity != string.Empty)
                    {
                        float IngredientQuantity = float.Parse(NewIngredientQuantity);
                        if(IngredientQuantity > 0f)
                        {
                            if(Product.AddIngredient(Ingredient, float.Parse(NewIngredientQuantity)))
                            {
                                Logs.EventLog("Afegit ingredient " + Ingredient.Name + "(" + IngredientQuantity + ") al producte " + Product.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                                RefreshIngredients();
                            }
                            else
                            {
                                MessageBox.Show("Error al afegir ingredient.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quantitat ha de ser positiva.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnIngredientDel_Click(object sender, EventArgs e)
        {
            IngredientModel SelectedRow = (IngredientModel)grdIngredients.SelectedItem;
            if (SelectedRow != null)
            {
                if (!Product.RemoveIngredient(Product.FindByName(SelectedRow.Name)))
                {
                    MessageBox.Show("Error a l'eliminar ingredient.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Logs.EventLog("Eliminat ingredient " + SelectedRow.Name + " al producte " + Product.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                    RefreshIngredients();
                }
            }
        }

        private void RefreshIngredients()
        {
            List<IngredientModel> Ingredients = new List<IngredientModel>();
            foreach (ProductAmount ProductAmount in Product.GetIngredients())
            {
                IngredientModel NewIngredient = new IngredientModel();
                NewIngredient.Name = ProductAmount.Product.Name;
                NewIngredient.Quantity = ProductAmount.Amount.ToString();
                NewIngredient.Unit = ProductAmount.Unit;
                Ingredients.Add(NewIngredient);
            }

            grdIngredients.DataSource = new BindingSource(Ingredients, null);
        }

        private void btnProviderAdd_Click(object sender, EventArgs e)
        {
            SfForm NewProviderForm = new TextInput("Nom del proveïdor");
            NewProviderForm.ShowDialog();
            string NewProvider = Program.InputResponse;
            if (NewProvider != string.Empty)
            {
                Provider Provider = Provider.FindByNamePart(NewProvider);
                if(Provider != null)
                {
                    SfForm NewProviderPriceForm = new TextInput("Preu per al proveïdor " + Provider.Name + "(Producte " + Product.Name + ")");
                    NewProviderPriceForm.ShowDialog();
                    string NewProviderPrice = Program.InputResponse;
                    if (NewProviderPrice != string.Empty)
                    {
                        if (Util.IsNumeric(NewProviderPrice))
                        {
                            float Price = float.Parse(NewProviderPrice);
                            if (Price > 0f)
                            {
                                SfForm NewProviderPriceCurrencyForm = new TextInput("Introdueix la divisa (EUR o USD)");
                                NewProviderPriceForm.ShowDialog();
                                string NewProviderPriceCurrency = Program.InputResponse;
                                if (NewProviderPriceCurrency != string.Empty)
                                {
                                    if (Product.AddProvider(Provider, Price, NewProviderPriceCurrency))
                                    {
                                        Logs.EventLog("Afegit proveïdor " + Provider.Name + " al producte " + Product.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                                        RefreshProviders();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al afegir proveïdor (divisa no valida?).", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El preu ha de ser positiu.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El preu ha de ser un nombre positiu.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnProviderDel_Click(object sender, EventArgs e)
        {
            ProviderModel SelectedRow = (ProviderModel)grdProviders.SelectedItem;
            if (SelectedRow != null)
            {
                if (!Product.RemoveProvider(Provider.FindByName(SelectedRow.Name)))
                {
                    MessageBox.Show("Error a l'eliminar proveïdor.", "Productes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Logs.EventLog("Eliminat proveïdor " + SelectedRow.Name + " al producte " + Product.Name, EventLogOrigin.SadegelStock, EventLogType.ProductMaintenance);
                    RefreshProviders();
                }
            }
        }

        private void RefreshProviders()
        {
            List<ProviderModel> Providers = new List<ProviderModel>();
            foreach (ProductProvider ProductProvider in Product.GetProvidersFromProductId(Product.Id))
            {
                ProviderModel NewProvider = new ProviderModel();
                NewProvider.Name = ProductProvider.Provider.Name;
                NewProvider.Price = ProductProvider.Price.ToString() + " " + ProductProvider.Currency;
                Providers.Add(NewProvider);
            }

            grdProviders.DataSource = new BindingSource(Providers, null);
        }

        private void grdIngredients_CellCheckBoxClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventArgs e)
        {
            IngredientModel SelectedRow = (IngredientModel)grdIngredients.SelectedItem;
            if (SelectedRow != null)
            {
                Product Ingredient = Product.FindByName(SelectedRow.Name);
                if(Ingredient != null)
                {
                    bool NewUnitState = SelectedRow.Unit;
                    Logs.Debug("NewUnitState = " + NewUnitState);
                    Product.UpdateIngredientQuantity(Ingredient, float.Parse(SelectedRow.Quantity), NewUnitState);
                }
            }
        }
    }
}
