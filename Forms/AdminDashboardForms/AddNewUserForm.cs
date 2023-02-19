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
    public partial class AddNewUserForm : Form
    {

        public event EventHandler UserAdded;
        public AddNewUserForm()
        {
            InitializeComponent();
        }

        private void addNewUserBtn_Click(object sender, EventArgs e)
        {
            User u = new User(this.rfidTagTextBox.Text,
                this.roleBox.Text,
                this.loginTextBox.Text,
                Program.ComputeSHA256(this.passwordTextBox.Text),
                this.nameTextBox.Text,
                this.surnameTextBox.Text,
                Program.ImageToByteArray(this.imageBox.Image),
                this.emailTextBox.Text,
                this.phoneTextBox.Text);

            BusinessLogicLayer bll = new BusinessLogicLayer();

            if (bll.InsertUser(u))
            {
                MessageBox.Show("User added");
                UserAdded.Invoke(this, e);
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
                    imageBox.ImageLocation = imageLocation;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
