using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        AuthenticationService authService;
        AuthenticatedUser user;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginUserAsync();
        }

        void LoginUser()
        {
            InitAuthorization();
            user = authService.Authenticate(txtUserName.Text, txtPassword.Text);
            if (user != null && user.UserName != string.Empty)
                lblUserName.Text = string.Format("Hello {0}!", user.FirstName);
            else
                lblUserName.Text = "Login Failed!";
            CleanUp();
        }
        void InitAuthorization()
        {
            btnLogin.Enabled = false;
            user = null;
            authService = new AuthenticationService();
            lblUserName.Text = string.Empty;
        }
        void CleanUp()
        {
            btnLogin.Enabled = true;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        async void LoginUserAsync()
        {
            InitAuthorization();
            user = await Task.Factory.StartNew<AuthenticatedUser>(() =>
            {
                return authService.Authenticate(txtUserName.Text, txtPassword.Text);
            });
            if (user != null && user.UserName != string.Empty)
                lblUserName.Text = string.Format("Hello {0}!", user.FirstName);
            else
                lblUserName.Text = "Login Failed!";
            CleanUp();
        }
        async void LoginUserAsyncAwait()
        {
            InitAuthorization();
            
            user = await authService.AuthenticateAsync(txtUserName.Text, txtPassword.Text);

            if (user != null && user.UserName != string.Empty)
                lblUserName.Text = string.Format("Hello {0}!", user.FirstName);
            else
                lblUserName.Text = "Login Failed!";
            CleanUp();
        }
    }
}
