using System;

using System.Windows.Forms;
using PSS_Final.Forms;
using PSS_Final.Objects;

namespace PSS_Final.Forms.UserDashboardForms
{
    public partial class UserAccountInformationForm : Form
    {
        private User currentUser;
        private BusinessLogicLayer bll;

        private UserForm mainForm;
        public UserAccountInformationForm(User currentUser, UserForm mainForm)
        {
            InitializeComponent();
            bll = new BusinessLogicLayer();

            this.currentUser = currentUser;
           
            this.mainForm = (UserForm)mainForm;
            
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

        private void UpdateAfterChange(object sender, EventArgs e)
        {
            this.currentUser = bll.GetCurrentUser(currentUser.Login);
            InitItems();
        }
        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm(currentUser.Id);
            form.ShowDialog();

        }

        private void changeAccountInfoBtn_Click(object sender, EventArgs e)
        {

            ChangeAccountInfoForm form = new ChangeAccountInfoForm(currentUser);

            form.FormClosed += UpdateAfterChange;
            form.ChangeAccountInfoHandler += UpdateAfterChange;
            form.ChangeAccountInfoHandler += mainForm.InitItemsEventHandler;
            form.ShowDialog();

        }
    }
}
