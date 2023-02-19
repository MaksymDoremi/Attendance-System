using PSS_Final.DB;
using PSS_Final.Forms;
using PSS_Final.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS_Final
{
    public partial class LoginForm : Form
    {
        public static User currentUser;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void loginIntoSystem_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLogicLayer bll = new BusinessLogicLayer();


                if (!bll.Login(this.loginTextBox.Text, Program.ComputeSHA256(this.passwordTextBox.Text)))
                {
                    MessageBox.Show("Login or password is incorrect");
                    return;
                }

                currentUser = bll.GetCurrentUser(this.loginTextBox.Text);

                if (currentUser.Role == "Admin")
                {
                    AdminForm form = new AdminForm(this, currentUser);
                    form.Show();
                    this.Hide();
                }
                else if (currentUser.Role == "User")
                {
                    UserForm form = new UserForm();
                    form.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

    }
}
