using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using PSS_Final.DB;
using PSS_Final.Forms.DashboardForms;
using Color = System.Drawing.Color;

namespace PSS_Final.Forms
{
    public partial class AdminForm : Form
    {
        private User currentUser;
        private IconButton currentBtn;

        private Form currentChildForm;

        private LoginForm loginForm;

        public void HelpInitMethod()
        {
            InitializeComponent();
        }

        public AdminForm(Form loginForm, User currentUser)
        {
            InitializeComponent();

            //load home pages
            OpenChildForm(new HomePageForm());

            //set instance of login form for log out issues
            this.loginForm = (LoginForm)loginForm;

            this.currentUser = currentUser;

            InitItems();
        }

        public void InitItems()
        {
            //photo
            this.smallAvatar.Image = Program.ConvertByteArrayToImage(currentUser.Photo);

            //homepage label with user's name
            this.homePageUsernameLabel.Text = currentUser.Name + " " + currentUser.Surname;

        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(196, 196, 196);
        }

        //Methods
        private void OpenChildForm(Form childForm)
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

        private void accountInfoBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new AccountInformationForm(currentUser));
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new UsersForm());
        }

        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new AttendanceForm());
        }

        /// <summary>
        /// return to home page by clicking on logo image
        /// </summary>
        private void logoHomeBtn_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            DisableButton();
            //return to home page
            OpenChildForm(new HomePageForm());
        }

        /// <summary>
        /// make logo panel sensitive to click and also use it as return to home page
        /// </summary>
        private void logoPanel_Paint(object sender, PaintEventArgs e)
        {
            currentChildForm.Close();
            DisableButton();
            //return to home page
            OpenChildForm(new HomePageForm());
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.dateTime.Text = System.DateTime.Now.ToString();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.timer.Start();

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
