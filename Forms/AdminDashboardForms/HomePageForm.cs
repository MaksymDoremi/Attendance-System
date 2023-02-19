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
    public partial class HomePageForm : Form
    {
        private string currentUserLogin;
        public HomePageForm(string currentUserLogin)
        {
            InitializeComponent();
            this.currentUserLogin = currentUserLogin;
        }
        
        public void InitControls()
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();

            DataTable dt = bll.GetUsers(currentUserLogin);
        }
    }
}
