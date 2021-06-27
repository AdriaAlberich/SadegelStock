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
    public partial class ProviderInput : SfForm
    {

        private bool EditMode = false;
        private Provider Provider = null;
        public ProviderInput(bool EditMode, Provider Provider)
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
            this.Provider = Provider;

            this.Text = this.EditMode ? "Modificar Proveïdor " + Provider.Name : "Crear nou Proveïdor";

            SortedDictionary<string, string> Countries = new SortedDictionary<string, string>();
            foreach (Country Country in Globals.CountryPool)
            {
                Countries.Add(Country.IsoCode, Country.Name);
            }

            cmbCountry.DataSource = new BindingSource(Countries, null);
            cmbCountry.DisplayMember = "Value";
            cmbCountry.ValueMember = "Key";

            if (this.EditMode && Provider != null)
            {
                txtName.Text = Provider.Name;
                txtId.Text = Provider.Id;
                txtPhone.Text = Provider.Phone;
                txtEmail.Text = Provider.Email;
                txtStreet.Text = Provider.Address.Street;
                txtNumber.Text = Provider.Address.Number;
                txtCity.Text = Provider.Address.City;
                txtCP.Text = Provider.Address.ZipCode;
                cmbCountry.SelectedValue = Provider.Country.IsoCode;
                btnAdd.Text = "Desar";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (this.EditMode && Provider != null)
            {
                bool ok = true;

                if(txtName.Text != string.Empty)
                {
                    txtName.BorderColor = SystemColors.Control;
                    Provider.Name = txtName.Text;
                }
                else
                {
                    txtName.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtId.Text != string.Empty)
                {
                    txtId.BorderColor = SystemColors.Control;
                    Provider.Id = txtId.Text;
                }
                else
                {
                    txtId.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtPhone.Text != string.Empty)
                {
                    txtPhone.BorderColor = SystemColors.Control;
                    Provider.Phone = txtPhone.Text;
                }
                else
                {
                    txtPhone.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtEmail.Text != string.Empty)
                {
                    txtEmail.BorderColor = SystemColors.Control;
                    Provider.Email = txtEmail.Text;
                }
                else
                {
                    txtEmail.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtStreet.Text != string.Empty)
                {
                    txtStreet.BorderColor = SystemColors.Control;
                    Provider.Address.Street = txtStreet.Text;
                }
                else
                {
                    txtStreet.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtNumber.Text != string.Empty)
                {
                    txtNumber.BorderColor = SystemColors.Control;
                    Provider.Address.Number = txtNumber.Text;
                }
                else
                {
                    txtNumber.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtCity.Text != string.Empty)
                {
                    txtCity.BorderColor = SystemColors.Control;
                    Provider.Address.City = txtCity.Text;
                }
                else
                {
                    txtCity.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtCP.Text != string.Empty)
                {
                    txtCP.BorderColor = SystemColors.Control;
                    Provider.Address.ZipCode = txtCP.Text;
                }
                else
                {
                    txtCP.BorderColor = Color.LightCoral;
                    ok = false;
                }

                Provider.Address.Door = "";
                Provider.Address.Floor = "";

                if (cmbCountry.Text != string.Empty)
                {
                    cmbCountry.BackColor = SystemColors.Control;
                    Provider.Country = Country.FindByCode(cmbCountry.SelectedValue.ToString());
                }
                else
                {
                    cmbCountry.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (ok)
                {
                    if (Provider.Update())
                    {
                        Logs.EventLog("Modificat proveïdor " + Provider.Name, EventLogOrigin.SadegelStock, EventLogType.ProviderMaintenance);
                        MessageBox.Show("Proveïdor desat correctament", "Proveïdors", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al desar proveïdor", "Proveïdors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Provider = new Provider();
                bool ok = true;

                if (txtName.Text != string.Empty)
                {
                    txtName.BorderColor = SystemColors.Control;
                    Provider.Name = txtName.Text;
                }
                else
                {
                    txtName.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtId.Text != string.Empty)
                {
                    txtId.BorderColor = SystemColors.Control;
                    Provider.Id = txtId.Text;
                }
                else
                {
                    txtId.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtPhone.Text != string.Empty)
                {
                    txtPhone.BorderColor = SystemColors.Control;
                    Provider.Phone = txtPhone.Text;
                }
                else
                {
                    txtPhone.BorderColor = Color.LightCoral;
                    ok = false;
                }

                if (txtEmail.Text != string.Empty)
                {
                    txtEmail.BorderColor = SystemColors.Control;
                    Provider.Email = txtEmail.Text;
                }
                else
                {
                    txtEmail.BorderColor = Color.LightCoral;
                    ok = false;
                }

                Provider.Address = new Address();

                Provider.Address.Street = txtStreet.Text;

                Provider.Address.Number = txtNumber.Text;

                Provider.Address.Floor = string.Empty;

                Provider.Address.Door = string.Empty;

                Provider.Address.ZipCode = txtCP.Text;

                Provider.Address.City = txtCity.Text;

                if (cmbCountry.Text != string.Empty)
                {
                    cmbCountry.BackColor = SystemColors.Control;
                    Provider.Country = Country.FindByCode(cmbCountry.SelectedValue.ToString());
                }
                else
                {
                    cmbCountry.BackColor = Color.LightCoral;
                    ok = false;
                }

                if (ok)
                {
                    Provider = Provider.Create(Provider.Name, Provider.Id, Provider.Email, Provider.Phone, Provider.Address, Provider.Country);

                    if (Provider != null)
                    {
                        Logs.EventLog("Afegit proveïdor " + Provider.Name, EventLogOrigin.SadegelStock, EventLogType.ProviderMaintenance);
                        MessageBox.Show("Proveïdor afegit correctament", "Proveïdors", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al afegir proveïdor", "Proveïdors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            
        }
    }
}
