using PSS_Final.DB;
using PSS_Final.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS_Final.Forms.DashboardForms
{
    public partial class ChangeAccountInfoForm : Form
    {
        private string _loginInput;
        private string name;
        private string surname;
        private string email;
        private string phone;
        

        //explicitly create byte array for image
        private byte[] imageBytes;

        private User currentUser;

        public ChangeAccountInfoForm(User currentUser)
        {
            InitializeComponent();
         
            this.currentUser = currentUser;

            InitItems();
        }

        private void InitItems()
        {
            this.changeNameTextBox.Text = currentUser.Name;
            this.changeSurnameTextBox.Text = currentUser.Surname;
            this.changeEmailTextBox.Text = currentUser.Email;
            this.changePhoneTextBox.Text = currentUser.Phone;
            this.changeImageBox.Image = Program.ConvertByteArrayToImage(currentUser.Photo);

        }

        //APPLY CHANGES TO DATABASE
        private void applyChangesAccountInfoBtn_Click(object sender, EventArgs e)
        {
            User u = new User(currentUser.Id,currentUser.Rfid_tag,currentUser.Role,currentUser.Login,this.changeNameTextBox.Text, this.changeSurnameTextBox.Text, Program.ImageToByteArray(this.changeImageBox.Image),this.changeEmailTextBox.Text, this.changePhoneTextBox.Text);


            BusinessLogicLayer bll = new BusinessLogicLayer();
            bll.UpdateUser(u);
          
        }

        //BROWSE IMAGES AND SET A NEW ONE
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
                    imageBytes = File.ReadAllBytes(imageLocation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        
    }
}
