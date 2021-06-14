using superTech.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using superTech.Models.City;
using superTech.Models.Roles;

namespace superTech.WinUI.Users
{
    public partial class frmUserDetails : Form
    {

        private readonly APIService.APIService _apiService = new APIService.APIService("users");
        private readonly APIService.APIService _apiServiceCities = new APIService.APIService("cities");
        private readonly APIService.APIService _apiServiceRoles = new APIService.APIService("roles");


        private int? _id = null;

        public frmUserDetails(int? userId = null)
        {
            InitializeComponent();

            _id = userId;

        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            { 
                var user = await _apiService.GetById<UserModel>(_id);
                List<CityModel> cities = await _apiServiceCities.Get<List<CityModel>>(null);
                List<RolesModel> roles = await _apiServiceRoles.Get<List<RolesModel>>(null);


                cmbCity.DataSource = cities;
                cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCity.DisplayMember = "Name";
                cmbCity.ValueMember = "CityId";

                foreach (var city in cities)
                {
                    if (int.Parse(city.CityId) == user.City)
                    {
                        cmbCity.SelectedItem = city;
                    }
                }

                cbRoles.DataSource = roles;
                cbRoles.DisplayMember = "Name";
                cbRoles.ValueMember = "RoleId";

                var castedRoles = cbRoles.Items.Cast<RolesModel>().Select(x => x.RoleId).ToList();


                for (int i = 0; i < castedRoles.Count; i++)
                {
                    for (int j = 0; j < user.Roles.Count; j++)
                    {
                        if (castedRoles[i] == user.Roles[j])
                        {
                            cbRoles.SetItemChecked(i,true);
                        }
                    }
                }


                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtPhoneNumber.Text = user.PhoneNumber;
                dpDOB.Value = Convert.ToDateTime(user.DateOfBirth);

                if (!string.IsNullOrEmpty(user.RegistrationDate))
                {
                    dpDOR.Value = Convert.ToDateTime(user.RegistrationDate);
                    dpDOR.Enabled = false;
                }

                txtGender.Text = user.Gender;
                cbxActive.Checked = user.Active;
                txtAddress.Text = user.Address;
                txtUsername.Text = user.UserName;
                txtEmail.Text = user.Email;
            }
            else
            {
                List<CityModel> cities = await _apiServiceCities.Get<List<CityModel>>(null);
                List<RolesModel> roles = await _apiServiceRoles.Get<List<RolesModel>>(null);

                dpDOR.Value = DateTime.Now;
                dpDOR.Enabled = false;
                cmbCity.DataSource = cities;
                cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCity.DisplayMember = "Name";
                cmbCity.ValueMember = "CityId";

                cbRoles.DataSource = roles;
                cbRoles.DisplayMember = "Name";
                cbRoles.ValueMember = "RoleId";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<int> selectedRoles =
                    cbRoles.CheckedItems.Cast<RolesModel>().Select(x => x.RoleId).ToList();

                UserUpsertRequest request = new UserUpsertRequest
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = Convert.ToDateTime(dpDOB.Value).ToString(),
                    DateOfRegistration = Convert.ToDateTime(dpDOR.Value).ToString(),
                    Gender = txtGender.Text,
                    Active = cbxActive.Checked,
                    Address = txtAddress.Text,
                    UserName = txtUsername.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPassword.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    CityId = int.Parse(cmbCity.SelectedValue.ToString()),
                    Roles = selectedRoles
                };

                if (_id.HasValue)
                {
                    await _apiService.Update<UserModel>(_id, request);
                    MessageBox.Show("Uspješno ste uredili korisnika: " + txtFirstName.Text + " !");

                }
                else
                {
                    await _apiService.Insert<UserModel>(request);
                    MessageBox.Show("Uspješno ste sačuvali korisnika !");
                }

            }

     

        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errProvider.SetError(txtFirstName, Properties.Resources.Validate_Input);
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(txtFirstName,null);
            }
        }

 

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errProvider.SetError(txtLastName, Properties.Resources.Validate_Input);
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(txtLastName, null);
            }
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errProvider.SetError(txtUsername, Properties.Resources.Validate_Input);
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(txtUsername, null);
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errProvider.SetError(txtEmail, Properties.Resources.Validate_Input);
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(txtEmail, null);
            }
        }

        private void txtPhoneNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                errProvider.SetError(txtPhoneNumber, Properties.Resources.Validate_Input);
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(txtPhoneNumber, null);
            }
        }

        private void txtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errProvider.SetError(txtAddress, Properties.Resources.Validate_Input);
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(txtAddress, null);
            }
        }

        private void txtGender_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGender.Text))
            {
                errProvider.SetError(txtGender, Properties.Resources.Validate_Input);
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(txtGender, null);
            }
        }

        private void cbRoles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            List<int> selectedRoles =
                cbRoles.CheckedItems.Cast<RolesModel>().Select(x => x.RoleId).ToList();

            if (selectedRoles.Count <= 0)
            {
                errProvider.SetError(cbRoles, Properties.Resources.Validate_Input);
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(cbRoles, null);
            }
        }

    
    }
}
