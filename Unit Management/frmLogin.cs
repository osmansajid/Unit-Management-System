using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unit_Management.Core;

namespace Unit_Management
{
    public partial class frmLogin : Form
    {
        DataOperations DB = new DataOperations();
        private string[] userInfo = new string[5];
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtUser.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {

                DataTable DT = DB.select("SYSTEM_USER", "*", "UNAME='" + txtUser.Text.Trim() + "' AND UPASS='" + DB.CreateMD5(txtPassword.Text.Trim()) + "'");

                foreach (DataRow row in DT.Rows)
                {
                    userInfo[0] = row["CODE"].ToString();
                    userInfo[1] = row["UROLE"].ToString();
                    userInfo[2] = row["UFULL_NAME"].ToString();
                }

                if (DT.Rows.Count > 0)
                {
                   
                    Dashboard dashboard = new Dashboard();
                    dashboard.setUserInfo(userInfo);
                    dashboard.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid User or Password");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
