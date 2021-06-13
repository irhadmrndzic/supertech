﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using superTech.Models.City;
using superTech.Models.User;

namespace superTech.WinUI.Users
{
    public partial class frmUsers : Form
    {
        private readonly APIService.APIService _usersApiService = new APIService.APIService("users");
        public frmUsers()
        {
            InitializeComponent();
        }

        private async void btnShowUsers_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var search = new UserSearchRequest
            {
                FirstName = txtUsersFirstName.Text,
                LastName = txtUsersLastName.Text
            };

            dgvUsers.AutoGenerateColumns = false;

            //if (search.FirstName == "" && search.LastName == "")
            //{
            //    search = null;

            //}

            var users = await _usersApiService.Get<List<UserModel>>(search);
            if (users.Count > 0)
            {
                Cursor.Current = Cursor.Current;
                dgvUsers.AutoGenerateColumns = false;
                dgvUsers.DataSource = users;
            }


        }

        private async  void frmUsers_Load(object sender, EventArgs e)
        {
        }

        private void dgvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvUsers.SelectedRows[0].Cells[0].Value;
            frmUserDetails frmUserDetails = new frmUserDetails(int.Parse(id.ToString()));
            frmUserDetails.Show();
        }
    }
}
