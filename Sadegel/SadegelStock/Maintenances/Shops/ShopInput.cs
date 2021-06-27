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
    public partial class ShopInput : SfForm
    {
        private bool EditMode = false;
        private Shop Shop = null;
        public ShopInput(bool EditMode, Shop Shop)
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
            this.Shop = Shop;

            this.Text = this.EditMode ? "Modificar Establiment " + Shop.Name : "Crear nou Establiment";

            SortedDictionary<string, string> ShopTypes = new SortedDictionary<string, string>();
            ShopTypes.Add("owned", "Propi");
            ShopTypes.Add("franchise", "Franquícia");
            ShopTypes.Add("international", "Internacional");

            cmbType.DataSource = new BindingSource(ShopTypes, null);
            cmbType.DisplayMember = "Value";
            cmbType.ValueMember = "Key";

            SortedDictionary<string, string> Countries = new SortedDictionary<string, string>();
            foreach(Country Country in Globals.CountryPool)
            {
                Countries.Add(Country.IsoCode, Country.Name);
            }

            cmbCountry.DataSource = new BindingSource(Countries, null);
            cmbCountry.DisplayMember = "Value";
            cmbCountry.ValueMember = "Key";

            if(this.EditMode && Shop != null)
            {
                txtId.Text = Shop.Id.ToString();
                txtName.Text = Shop.Name;
                cmbType.SelectedValue = Shop.Type;
                cmbTPV.Text = Shop.Tpv;
                txtStreet.Text = Shop.Address.Street;
                txtNumber.Text = Shop.Address.Number;
                txtCP.Text = Shop.Address.ZipCode;
                txtCity.Text = Shop.Address.City;
                cmbCountry.SelectedValue = Shop.Country.IsoCode;
                btnAdd.Text = "Desar";
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
            if (this.EditMode && Shop != null)
            {
                bool ok = true;

                if(txtName.Text != string.Empty)
                {
                    txtName.BorderColor = SystemColors.Control;
                    Shop.Name = txtName.Text;
                }
                else
                {
                    txtName.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if(cmbType.Text != string.Empty)
                {
                    cmbType.BackColor = SystemColors.Control;
                    Shop.Type = cmbType.SelectedValue.ToString();
                }
                else
                {
                    cmbType.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (cmbTPV.Text != string.Empty)
                {
                    cmbTPV.BackColor = SystemColors.Control;
                    Shop.Tpv = cmbTPV.Text;
                }
                else
                {
                    cmbTPV.BackColor = Color.LightCoral;
                    ok = false;
                }

                Shop.Address.Street = txtStreet.Text;

                Shop.Address.Number = txtNumber.Text;

                Shop.Address.ZipCode = txtCP.Text;

                Shop.Address.City = txtCity.Text;

                if (cmbCountry.Text != string.Empty)
                {
                    cmbCountry.BackColor = SystemColors.Control;
                    Shop.Country = Country.FindByCode(cmbCountry.SelectedValue.ToString());
                }
                else
                {
                    cmbCountry.BackColor = Color.LightCoral;
                    ok = false;
                }

                if(ok)
                {
                    if (Shop.Update())
                    {
                        Logs.EventLog("Modificat establiment " + Shop.Name, EventLogOrigin.SadegelStock, EventLogType.ShopMaintenance);
                        MessageBox.Show("Establiment desat correctament", "Establiments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al desar establiment", "Establiments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Shop = new Shop();
                bool ok = true;

                if (txtName.Text != string.Empty)
                {
                    txtName.BackColor = SystemColors.Control;
                    Shop.Name = txtName.Text;
                }
                else
                {
                    txtName.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (cmbType.Text != string.Empty)
                {
                    cmbType.BackColor = SystemColors.Control;
                    Shop.Type = cmbType.SelectedValue.ToString();
                }
                else
                {
                    cmbType.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (cmbTPV.Text != string.Empty)
                {
                    cmbTPV.BackColor = SystemColors.Control;
                    Shop.Tpv = cmbTPV.Text;
                }
                else
                {
                    cmbTPV.BackColor = Color.LightCoral;
                    ok = false;
                }

                Shop.Address = new Address();

                Shop.Address.Street = txtStreet.Text;

                Shop.Address.Number = txtNumber.Text;

                Shop.Address.Floor = string.Empty;

                Shop.Address.Door = string.Empty;

                Shop.Address.ZipCode = txtCP.Text;

                Shop.Address.City = txtCity.Text;

                if (cmbCountry.Text != string.Empty)
                {
                    cmbCountry.BackColor = SystemColors.Control;
                    Shop.Country = Country.FindByCode(cmbCountry.SelectedValue.ToString());
                }
                else
                {
                    cmbCountry.BackColor = Color.LightCoral;
                    ok = false;
                }

                if(ok)
                {
                    Shop = Shop.Create(Shop.Name, Shop.Type, Shop.Address, Shop.Tpv, Shop.Country);

                    if (Shop != null)
                    {
                        Logs.EventLog("Afegit establiment " + Shop.Name, EventLogOrigin.SadegelStock, EventLogType.ShopMaintenance);
                        MessageBox.Show("Establiment afegit correctament", "Establiments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al afegir establiment", "Establiments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
