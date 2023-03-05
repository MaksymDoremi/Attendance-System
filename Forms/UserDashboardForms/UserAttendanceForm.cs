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

namespace PSS_Final.Forms.UserDashboardForms
{
    public partial class UserAttendanceForm : Form
    {
        private BusinessLogicLayer bll;
        private int userID;
        public UserAttendanceForm(int useID)
        {
            InitializeComponent();
            bll = new BusinessLogicLayer();
            this.userID = useID;

            InitAttendanceControls();
        }

        private void InitAttendanceControls()
        {
            DataTable dt = bll.GetAttendanceByUser(userID);
            this.attendanceFlowLayout.Controls.Clear();
            List<AttendanceControl> attendanceList = new List<AttendanceControl>();
            foreach (DataRow dr in dt.Rows)
            {
                //this.attendanceFlowLayout.Controls.Add(new AttendanceControl(new Attendance((int)dr["ID"], (string)dr["Name"], (string)dr["Surname"], (DateTime)dr["DateTime"], (bool)dr["Type"])));
                attendanceList.Add(new AttendanceControl(new Attendance((int)dr["ID"], (string)dr["Name"], (string)dr["Surname"], (DateTime)dr["DateTime"], (bool)dr["Type"])));
            }

            var sortedAttendanceList = attendanceList.OrderByDescending(a => a.AttendanceInstance.DateTime);

            AttendanceControl[] finalList = (AttendanceControl[])sortedAttendanceList.ToArray();

            foreach( AttendanceControl a in finalList)
            {
                this.attendanceFlowLayout.Controls.Add(a);
            }
            
        }
    }
}
