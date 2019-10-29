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


namespace Unit_Management.Admin
{
    public partial class frmManageUser : Form
    {
        public frmManageUser()
        {
            InitializeComponent();
        }
        private string SelectedUser = null;
        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        internal void setUserInfo(string[] userInfo)
        {
            this.userInfo = userInfo;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> USER = new Dictionary<string, string>();
            USER.Add("UNAME", DB.validateTextBox(txtUserName));
            if (!String.IsNullOrEmpty(txtPassword.Text))
            {
                USER.Add("UPASS", DB.CreateMD5(DB.validateTextBox(txtPassword)));
            }
           
            USER.Add("UEMAIL", DB.validateTextBox(txtEmail));
            USER.Add("UFULL_NAME", DB.validateTextBox(txtFullname));
            USER.Add("UROLE", DB.validateComBox(cmbRole));

            if (btnSave.Text == "Save")
            {
                MessageBox.Show(DB.insert("SYSTEM_USER", USER));
                Clear();
            }
            else
            {
                //Update

                MessageBox.Show(DB.update("SYSTEM_USER", USER, "CODE='"+SelectedUser+"'"));
                btnSave.Text = "Save";
                Clear();
            }
            LoadListView();
        }



        private void Clear()
        {
            txtEmail.Clear();
            txtFullname.Clear();
            txtPassword.Clear();
            txtUserName.Clear();
            SelectedUser = null;
            btnSave.Text = "Save";
            cmbRole.SelectedIndex = -1;
        }
        private void frmManageUser_Load(object sender, EventArgs e)
        {
            LoadRoleBox();
            LoadListView();
        }

        private void LoadRoleBox()
        {
            DataTable DT = DB.select("SYSTEM_ROLE", "*");

            cmbRole.DisplayMember = "NAME";
            cmbRole.ValueMember = "CODE";
            cmbRole.DataSource = DT;
            cmbRole.SelectedIndex = -1;
        }

        private void LoadListView()
        {
            DataTable DT = DB.select("VW_SYSTEM_USER", "*");


            if (DT.Rows.Count > 0)
            {

                listView1.BeginUpdate();
                listView1.Items.Clear();

                foreach (DataRow row in DT.Rows)
                {
                    ListViewItem item = new ListViewItem(row["CODE"].ToString());
                    item.SubItems.Add(row["UFULL_NAME"].ToString());
                    item.SubItems.Add(row["UNAME"].ToString());
                    item.SubItems.Add(row["UEMAIL"].ToString());
                    item.SubItems.Add(row["R_CODE"].ToString());
                    item.SubItems.Add(row["NAME"].ToString());
                    listView1.Items.Add(item);

                }
                listView1.EndUpdate();
                listView1.Refresh();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtEmail.Text = item.SubItems[colEmail.Index].Text;
                txtFullname.Text = item.SubItems[colFullName.Index].Text;
                txtUserName.Text = item.SubItems[colUserName.Index].Text;
                SelectedUser = item.SubItems[colCode.Index].Text;
                cmbRole.SelectedValue = item.SubItems[colRoleID.Index].Text;
                btnSave.Text = "Update";
            }
        }
    }
}
