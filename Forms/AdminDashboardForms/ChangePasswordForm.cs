using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSS_Final;
using PSS_Final.DB;
using PSS_Final.Objects;

namespace PSS_Final.Forms.DashboardForms
{
    public partial class ChangePasswordForm : Form
    {
        private int userID;
        public ChangePasswordForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void applyNewPasswordBtn_Click(object sender, EventArgs e)
        {
            if (this.newPasswordTextBox.Text != this.retypeNewPasswordTextBox.Text)
            {
                MessageBox.Show("Incorrectly retyped password");
                return;
            }

            BusinessLogicLayer bll = new BusinessLogicLayer();
            if (bll.UpdatePassword(userID, this.oldPasswordTextBox.Text, this.newPasswordTextBox.Text))
            {
                MessageBox.Show("Password changed successfully");
                this.Close();
            }

            
        }
    }
}
