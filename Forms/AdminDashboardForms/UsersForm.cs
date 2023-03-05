using PSS_Final.Controls;
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

namespace PSS_Final.Forms.AdminDashboardForms
{
    public partial class UsersForm : Form
    {
        private string currentUserLogin;

        private List<User> userList;

        private AdminForm adminForm;

        private BusinessLogicLayer bll;

        private Thread rfidThread;
        public UsersForm(string currentUserLogin, AdminForm adminForm, ref Thread rfidThread)
        {
            InitializeComponent();
            userList = new List<User>();
            bll = new BusinessLogicLayer();
            this.currentUserLogin = currentUserLogin;
            this.adminForm = adminForm;

            InitUserList();
            InitControls();
            this.rfidThread = rfidThread;
        }
        public void InitEventHandler(object sender, EventArgs e)
        {
            InitUserList();
            InitControls();
        }
        public void InitControls()
        {
            flowLayoutPanel1.Controls.Clear();

            User[] users = userList.ToArray();

            foreach (User user in users)
            {
                UsersControl c = new UsersControl(user, adminForm, ref rfidThread);
                c.updateChanges += InitEventHandler;

                this.flowLayoutPanel1.Controls.Add(c);
            }
        }
        public void InitUserList()
        {
            userList.Clear();
            DataTable dt = bll.GetUsers(currentUserLogin);

            foreach (DataRow dr in dt.Rows)
            {
                userList.Add(new User((int)dr["ID"],
                    dr["RFID_Tag"].GetType() == typeof(DBNull) ? "" : (string)dr["RFID_Tag"],
                    (string)dr["Role"],
                    (string)dr["Login"],
                    (string)dr["Name"],
                    (string)dr["Surname"],
                    dr["Photo"].GetType() == typeof(DBNull) ? null : (byte[])dr["Photo"],
                    dr["Email"].GetType() == typeof(DBNull) ? "" : (string)dr["Email"],
                    dr["Phone"].GetType() == typeof(DBNull) ? "" : (string)dr["Phone"]));
            }
        }

        private void StartThread(object sender, EventArgs e)
        {
            RFID.OpenSerialPort();
            this.rfidThread.Resume();
        }
        private void addNewUserBtn_Click(object sender, EventArgs e)
        {
            AddNewUserForm form = new AddNewUserForm();
            form.UserAdded += InitEventHandler;
            form.FormClosed += StartThread;
            this.rfidThread.Suspend();
            form.ShowDialog();
        }
    }
}
