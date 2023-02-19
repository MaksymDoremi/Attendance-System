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

namespace PSS_Final.Controls
{
    public partial class AttendanceControl : UserControl
    {
        private Attendance attendanceInstance;

        public Attendance AttendanceInstance { get => attendanceInstance; set => attendanceInstance = value; }
        public AttendanceControl(Attendance attendanceInstance)
        {
            InitializeComponent();
            this.attendanceInstance = attendanceInstance;
            IntiItems();
        }

        private void IntiItems()
        {
            this.nameLabel.Text = attendanceInstance.Name+" "+attendanceInstance.Surname;
            this.dateTimeLabel.Text = attendanceInstance.DateTime.ToString();
            this.comeOrLeaveLabel.Text = attendanceInstance.TypeString;
        }

        private void AttendanceControl_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(145, 145, 145);
        }

        private void AttendanceControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Control;
        }
    }
}
