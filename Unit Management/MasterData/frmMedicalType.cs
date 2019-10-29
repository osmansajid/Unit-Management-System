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

namespace Unit_Management.MasterData
{
    public partial class frmMedicalType : Form
    {
        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        public frmMedicalType()
        {
            InitializeComponent();
        }
        internal void setUserInfo(string[] userInfo)
        {
            this.userInfo = userInfo;
        }

        private void LoadTypeList()
        {
            DataTable DT_TYPES = DB.select("MEDICAL_TYPE","*",null,"NAME ASC");
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (DataRow row in DT_TYPES.Rows)
            {
                ListViewItem listItem = new ListViewItem(row["CODE"].ToString());
                listItem.SubItems.Add(row["NAME"].ToString());
                listItem.SubItems.Add(row["DESCRIPTION"].ToString());
                
                listView1.Items.Add(listItem);
            }
            listView1.EndUpdate();
            listView1.Refresh();
        }

        private void frmMedicalType_Load(object sender, EventArgs e)
        {
            LoadTypeList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            Dictionary<string, string> TYPE_DATA = new Dictionary<string, string>();

            TYPE_DATA.Add("NAME", DB.validateTextBox(txtName));
            TYPE_DATA.Add("DESCRIPTION", DB.validateTextBox(txtRemarks));


            if (btnSave.Text == "Save")
            {
              MessageBox.Show(  DB.insert("MEDICAL_TYPE", TYPE_DATA));
            }


            LoadTypeList();
            txtName.Clear();
            txtRemarks.Clear();
        }
    }
}

