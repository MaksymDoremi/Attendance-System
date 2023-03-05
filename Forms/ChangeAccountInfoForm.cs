using PSS_Final.Objects;
using System;
using System.IO;
using System.Windows.Forms;
using static PSS_Final.Program;

namespace PSS_Final.Forms
{
    public partial class ChangeAccountInfoForm : Form
    {
        private string _loginInput;
        private string name;
        private string surname;
        private string email;
        private string phone;

        /// <summary>
        /// After changing information => pull new data from database
        /// </summary>
        public event EventHandler ChangeAccountInfoHandler;

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
            if (bll.UpdateUser(u))
            {
                MessageBox.Show("Changes applied");
                if (this.ChangeAccountInfoHandler != null)
                {
                    ChangeAccountInfoHandler(this, e);                
                }   
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Something went wrong. Contact developer");
                this.Close();
            }

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
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        
    }
}
