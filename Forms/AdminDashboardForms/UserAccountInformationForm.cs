using PSS_Final.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS_Final.Forms.DashboardForms
{
    public partial class UserAccountInformationForm : Form
    {
        private User userInstance;
        public UserAccountInformationForm(User userInstance)
        {
            InitializeComponent();
            this.userInstance = userInstance;
        }

        public void InitItems()
        {
            this.nameLabel.Text = userInstance.Name;
            this.surnameLabel.Text = userInstance.Surname;
            this.rfidLabel.Text = userInstance.Rfid_tag;
            this.roleLabel.Text = userInstance.Role;
            this.phoneLabel.Text = userInstance.Phone;
            this.emailLabel.Text = userInstance.Email;

            this.userImage.Image = Program.ConvertByteArrayToImage(userInstance.Photo);
        }

        public void InitItemsEvent(object sender, EventArgs a)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            userInstance = bll.GetCurrentUser(userInstance.Login);
            InitItems();

        }
        private void changeAccountInfoBtn_Click(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
