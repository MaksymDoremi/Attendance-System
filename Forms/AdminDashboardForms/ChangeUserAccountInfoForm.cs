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

namespace PSS_Final.Forms.AdminDashboardForms
{
    public partial class ChangeUserAccountInfoForm : Form
    {
        private User userInstance;

        public event EventHandler SubmitChanges;
        public ChangeUserAccountInfoForm(User userInstance)
        {
            InitializeComponent();
            this.userInstance = userInstance;

            InitItems();
        }

        public void InitItems()
        {
            this.changeNameTextBox.Text = userInstance.Name;
            this.changeSurnameTextBox.Text = userInstance.Surname;
            this.changeRfidTagTextBox.Text = userInstance.Rfid_tag;
            this.changeEmailTextBox.Text = userInstance.Email;
            this.changePhoneTextBox.Text = userInstance.Phone;

            if (userInstance.Photo != null)
            {
                this.changeImageBox.Image = Program.ConvertByteArrayToImage(userInstance.Photo);

            }

        }
        private void browseImagesBtn_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    changeImageBox.ImageLocation = imageLocation;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void applyChangesAccountInfoBtn_Click(object sender, EventArgs e)
        {
            User u = new User(userInstance.Id, this.changeRfidTagTextBox.Text, userInstance.Role, userInstance.Login, this.changeNameTextBox.Text, this.changeSurnameTextBox.Text, Program.ImageToByteArray(this.changeImageBox.Image), this.changeEmailTextBox.Text, this.changePhoneTextBox.Text);
            BusinessLogicLayer bll = new BusinessLogicLayer();
            if (bll.UpdateUser(u))
            {
                MessageBox.Show("Changes applied");
                if(SubmitChanges != null)
                {
                    SubmitChanges.Invoke(this, e);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
