using PSS_Final.Forms;
using PSS_Final.Forms.DashboardForms;
using PSS_Final.Objects;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PSS_Final.Controls
{
    public partial class UsersControl : UserControl
    {
        private AdminForm adminForm;
        private User userInstance;
        public event EventHandler updateChanges;
        private Thread rfidThread;

        public UsersControl(User userInstance, AdminForm adminForm, ref Thread rfidThread)
        {
            InitializeComponent();
            this.userInstance = userInstance;
            this.adminForm = adminForm;
            InitItems();
            this.rfidThread = rfidThread;
        }

        /// <summary>
        /// Initialize labels and image box
        /// </summary>
        public void InitItems()
        {
            this.userName.Text = userInstance.Name + " " + userInstance.Surname;
            this.userRole.Text = userInstance.Role;
            if (userInstance.Photo != null)
            {
                this.userImage.Image = Program.ConvertByteArrayToImage(userInstance.Photo);
            }

        }
        /// <summary>
        /// Method for handling updates. Subscribed to event handler from UserAccountInformationForm.updateChanges
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InitItemsHandler(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            userInstance = bll.GetCurrentUser(userInstance.Login);
            if (userInstance != null)
            {
                InitItems();
            }

            if (updateChanges != null)
            {
                updateChanges.Invoke(this, e);
            }
        }
        /// <summary>
        /// Opens account information for user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersControl_OnClick(object sender, EventArgs e)
        {
            UserAccountInformationForm form = new UserAccountInformationForm(userInstance, ref rfidThread);
            //subscribe upadate method
            form.updateChanges += InitItemsHandler;
            adminForm.OpenChildFormOverDashBoardForm(form);

        }

        #region Mouse Listeners
        private void UsersControl_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Control;
        }
        private void UsersControl_MouseHover(object sender, System.EventArgs e)
        {
            this.BackColor = Color.FromArgb(145, 145, 145);
        }
        #endregion
    }
}
