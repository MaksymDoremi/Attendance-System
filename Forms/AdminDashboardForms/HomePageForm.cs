using PSS_Final.Controls;
using PSS_Final.Objects;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PSS_Final.Forms.AdminDashboardForms
{
    public partial class HomePageForm : Form
    {
        private string currentUserLogin;
        public HomePageForm(string currentUserLogin)
        {
            InitializeComponent();
            this.currentUserLogin = currentUserLogin;
            InitControls();
        }
        
        public void InitControls()
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();

            DataTable dt = bll.GetAttendanceType();
            List<UsersAtWorkControl> list = new List<UsersAtWorkControl>(); 


            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new UsersAtWorkControl((string)dr["Name"]+" " + (string)dr["Surname"], (bool)dr["Type"]));
            }

            var result = list.OrderBy(o => o.UserName);

            foreach(var element in result)
            {
                this.usersAtWorkFlowLayout.Controls.Add((UsersAtWorkControl)element);
            }
        }
    }
}
