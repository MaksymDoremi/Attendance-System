using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using PSS_Final.DB;
using PSS_Final.Forms.AdminDashboardForms;
using PSS_Final.Objects;
using Color = System.Drawing.Color;

namespace PSS_Final.Forms
{
    public partial class AdminForm : Form
    {
        private User currentUser;
        private IconButton currentBtn;

        private Form currentChildForm;

        private LoginForm loginForm;

        private BusinessLogicLayer bll;

        private Thread rfidThread;

        public AdminForm(Form loginForm, User currentUser, ref Thread rfidThread)
        {
            InitializeComponent();

            //load home page
            OpenChildForm(new HomePageForm(currentUser.Login));


            //set instance of login form for log out issues
            this.loginForm = (LoginForm)loginForm;

            this.currentUser = currentUser;

            bll = new BusinessLogicLayer();

            InitItems();
            this.rfidThread = rfidThread;
            this.timer.Start();
        }
        #region Init
        public void InitItems()
        {
            //photo
            this.smallAvatar.Image = Program.ConvertByteArrayToImage(currentUser.Photo);

            //homepage label with user's name
            this.homePageUsernameLabel.Text = currentUser.Name + " " + currentUser.Surname;

        }
        public void InitItemsEventHandler(object sender, EventArgs a)
        {
            currentUser = bll.GetCurrentUser(currentUser.Login);
            InitItems();
        }
        #endregion
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(196, 196, 196);
        }
        #region Open Forms
        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void OpenChildFormOverDashBoardForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion
        #region Activate Deactivate Buttons
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                //disable previous button
                DisableButton();

                //activate current button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(79, 79, 79);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                //disable current button
                currentBtn.BackColor = Color.FromArgb(100, 100, 100);
                currentBtn.ForeColor = Color.Black;
                currentBtn.IconColor = Color.Black;
            }
        }
        #endregion
        #region Dashboard Forms
        private void accountInfoBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new AccountInformationForm(currentUser, this));

        }
        private void usersBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new UsersForm(currentUser.Login, this, ref rfidThread));
        }
        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new AttendanceForm());
        }
        #endregion
        #region Home Page and logo
        /// <summary>
        /// return to home page by clicking on logo image
        /// </summary>
        private void logoHomeBtn_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            DisableButton();
            //return to home page
            OpenChildForm(new HomePageForm(currentUser.Login));
        }
        /// <summary>
        /// make logo panel sensitive to click and also use it as return to home page
        /// </summary>
        private void logoPanel_Paint(object sender, PaintEventArgs e)
        {
            currentChildForm.Close();
            DisableButton();
            //return to home page
            OpenChildForm(new HomePageForm(currentUser.Login));
        }
        #endregion
        private void timer_Tick(object sender, EventArgs e)
        {
            this.dateTime.Text = System.DateTime.Now.ToString();
        }
        private void AdminForm_Closed(object sender, EventArgs e)
        {
            timer.Stop();
            //close login form to completely kill the program
            loginForm.Close();
        }
        private void logOutBtn_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Hide();
        }

    }
}
