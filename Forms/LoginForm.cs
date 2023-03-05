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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS_Final
{
    public partial class LoginForm : Form
    {
        private User currentUser;
        private Thread rfidThread;
        public LoginForm()
        {
            InitializeComponent();
            //start rfid thread
            try
            {
                RFID r = new RFID();

                rfidThread = new Thread(r.ReadTag);
                rfidThread.Start();
            }
            catch(Exception ex)
            {

            }
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
                    AdminForm form = new AdminForm(this, currentUser, ref rfidThread);
                    form.Show();
                    this.Hide();
                }
                else if (currentUser.Role == "User")
                {
                    UserForm form = new UserForm(this, currentUser);
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
