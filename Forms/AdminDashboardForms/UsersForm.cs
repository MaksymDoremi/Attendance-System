using PSS_Final.Controls;
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

namespace PSS_Final.Forms.DashboardForms
{
    public partial class UsersForm : Form
    {
        private string currentUserLogin;
        private List<User> userList;
        private BusinessLogicLayer bll;
        public UsersForm(string currentUserLogin)
        {
            InitializeComponent();
            userList= new List<User>();
            bll = new BusinessLogicLayer();
            this.currentUserLogin = currentUserLogin;

            InitUserList();
            InitControls();
        }

        public void InitControls()
        {
            User[] users = userList.ToArray();

            foreach (User user in users)
            {
                this.flowLayoutPanel1.Controls.Add(new UsersControl(user));
            }
        }

        public void InitUserList()
        {
            DataTable dt = bll.GetUsers(currentUserLogin);

            foreach (DataRow dr in dt.Rows)
            {
                userList.Add(new User((int)dr["ID"], dr["RFID_Tag"].GetType() == typeof(DBNull) ? "" : (string)dr["RFID_Tag"], (string)dr["Role"], (string)dr["Login"], (string)dr["Name"], (string)dr["Surname"], dr["Photo"].GetType() == typeof(DBNull) ? null : (byte[])dr["Photo"], (string)dr["Email"], (string)dr["Phone"]));
            }
        }
    }
}
