using System;
using System.Windows.Forms;

namespace superTech.WinUI.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private readonly APIService.APIService _usersApiService = new APIService.APIService("users");
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            APIService.APIService.Username = txtUsername.Text;
            APIService.APIService.Password = txtPassword.Text;

            try
            {
                await _usersApiService.Get<object>(null);
                Cursor.Current = Cursors.WaitCursor;
                frmMenu frmMenu = new frmMenu();
                frmMenu.Show();
                Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Autentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
