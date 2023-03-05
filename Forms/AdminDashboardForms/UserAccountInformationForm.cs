using PSS_Final.Forms.AdminDashboardForms;
using PSS_Final.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS_Final.Forms.DashboardForms
{
    public partial class UserAccountInformationForm : Form
    {
        private User userInstance;

        public event EventHandler updateChanges;
        private Thread rfidThread;
        public UserAccountInformationForm(User userInstance, ref Thread rfidThread)
        {
            InitializeComponent();
            this.userInstance = userInstance;
            InitItems();
            this.rfidThread = rfidThread;
        }

        public void InitItems()
        {
            this.nameLabel.Text = userInstance.Name;
            this.surnameLabel.Text = userInstance.Surname;
            this.rfidLabel.Text = userInstance.Rfid_tag;
            this.roleLabel.Text = userInstance.Role;
            this.phoneLabel.Text = userInstance.Phone;
            this.emailLabel.Text = userInstance.Email;

            if (userInstance.Photo != null)
            {
                this.userImage.Image = Program.ConvertByteArrayToImage(userInstance.Photo);

            }
        }

        public void InitItemsEvent(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            userInstance = bll.GetCurrentUser(userInstance.Login);
            InitItems();
            if (updateChanges != null)
            {
                updateChanges.Invoke(this, e);
            }

        }
        private void StartRfidThread(object sender, EventArgs e)
        {
            
            if (rfidThread != null)
            {
                RFID.OpenSerialPort();
                this.rfidThread.Resume();
            }
            
        }
        private void changeAccountInfoBtn_Click(object sender, EventArgs e)
        {
            ChangeUserAccountInfoForm form = new ChangeUserAccountInfoForm(userInstance);
            form.SubmitChanges += InitItemsEvent;
            form.FormClosed += StartRfidThread;
            
            if (rfidThread != null)
            {
                RFID.CloseSerialPort();
                this.rfidThread.Suspend();
            }
            
            form.ShowDialog();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();

            if (bll.DeleteAttendance(userInstance.Id) & bll.DeleteUser(userInstance.Id))
            {
                MessageBox.Show("User deleted successfully");
                if (updateChanges != null)
                {
                    updateChanges.Invoke(this, e);
                }
                this.Close();
            }
        }
    }
}
