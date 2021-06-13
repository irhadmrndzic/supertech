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
            txtDOE.Text = user.DateOfEmployment;
            txtDOB.Text = user.DateOfBirth;
            txtDOR.Text = user.RegistrationDate;
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
            List<int> selectedRoles =
                cbRoles.CheckedItems.Cast<RolesModel>().Select(x => x.RoleId).ToList();
          
            UserUpsertRequest request = new UserUpsertRequest
            {
              FirstName = txtFirstName.Text,
              LastName = txtLastName.Text,
              DateOfBirth  = txtDOB.Text,
              DateOfRegistration = DateTime.Now.ToString(),
              DateOfEmployment = DateTime.Now.ToString(),
              Gender = txtGender.Text,
              Active = cbxActive.Checked,
              Address  = txtAddress.Text,
              UserName  = txtUsername.Text,
              Email = txtEmail.Text,
              Password = txtPassword.Text,
              PasswordConfirmation = txtPassword.Text,
              CityId = int.Parse(cmbCity.SelectedValue.ToString()),
              Roles = selectedRoles
           };

            

         await _apiService.Insert<UserModel>(request);
        }
    }
}
