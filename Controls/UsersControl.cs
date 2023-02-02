using PSS_Final.Forms.DashboardForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS_Final.Controls
{
    public partial class UsersControl : UserControl
    {
        private User userInstance;
        public UsersControl(User userInstance)
        {
            InitializeComponent();
            this.userInstance = userInstance;
            InitItems();
        }
        
        public void InitItems()
        {
            this.userName.Text = userInstance.Name + " " + userInstance.Surname;
            this.userRole.Text = userInstance.Role;
            if(userInstance.Photo != null)
            {
                this.userImage.Image = Program.ConvertByteArrayToImage(userInstance.Photo);
            }

        }
        /// <summary>
        /// Opens account information for user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersControl_OnClick(object sender, EventArgs e)
        {
            UserAccountInformationForm form = new UserAccountInformationForm(userInstance);

        }
    }
}
