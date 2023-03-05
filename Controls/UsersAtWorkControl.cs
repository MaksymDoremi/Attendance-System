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
    public partial class UsersAtWorkControl : UserControl
    {
        private string userName;
        private bool atWork;

        public string UserName { get => userName; set => userName = value; }
        public UsersAtWorkControl(string userName, bool atWork)
        {
            InitializeComponent();
            this.UserName = userName;
            this.atWork = atWork;
            InitItems();
        }

        public void InitItems()
        {
            this.nameLabel.Text = userName;
            if (atWork)
            {
                UserAtWork();
            }
            else
            {
                UserLeft();
            }
        }

        public void UserAtWork()
        {
            this.typeLabel.Text = "✔";
            this.typeLabel.BackColor = System.Drawing.Color.Lime;
        }

        public void UserLeft()
        {
            this.typeLabel.Text = "✖";
            this.typeLabel.BackColor = System.Drawing.Color.Red;
        }
    }
}
