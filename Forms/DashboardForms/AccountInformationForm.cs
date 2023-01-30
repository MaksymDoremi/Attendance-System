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

namespace PSS_Final.Forms.DashboardForms
{
    public partial class AccountInformationForm : Form
    {
        private User currentUser;

        public AccountInformationForm(User currentUser)
        {
            InitializeComponent();

            this.currentUser = currentUser;

            InitItems();

        }

        private void InitItems()
        {

            //LOAD ROLE
            this.actualRoleFromDB.Text = currentUser.Role;

            //LOAD NAME
            this.actualNameFromDB.Text = currentUser.Name;

            //LOAD SURNAME
            this.actualSurnameFromDB.Text = currentUser.Surname;

            //LOAD PHOTO
            
            this.bigAvatarPicture.Image = Program.ConvertByteArrayToImage(currentUser.Photo);

            //LOAD EMAIL
            this.actualEmailFromDB.Text = currentUser.Email;

            //LOAD PHONE
            this.actualPhoneFromDB.Text = currentUser.Phone;

        }

        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm(currentUser.Id);
            form.ShowDialog();

        }

        private void changeAccountInfoBtn_Click(object sender, EventArgs e)
        {

            ChangeAccountInfoForm form = new ChangeAccountInfoForm(currentUser);

            form.FormClosed += DialogClosed;
            form.ShowDialog();
            
        }

        void DialogClosed(object sender, EventArgs e)
        {
            InitItems();
            InitializeComponent();
            Application.DoEvents();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.BringToFront();


        }
    }
}
