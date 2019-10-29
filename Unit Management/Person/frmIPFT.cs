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

namespace Unit_Management.Person
{
    public partial class frmIPFT : Form
    {
        public frmIPFT()
        {
            InitializeComponent();
        }
        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        string ARMY_CODE = null;

        internal void setUserInfo(string[] userInfo)
        {
            this.userInfo = userInfo;
        }
        internal void setArmyCode(string armyCode)
        {
            this.ARMY_CODE = armyCode;
        }
        private void frmIPFT_Load(object sender, EventArgs e)
        {
            LoadBiAnnual();
            LoadResult();
            Permission();
        }
        private void LoadBiAnnual()
        {
            DataTable DT_EMERGENCY = new DataTable();
            // create fields

            DT_EMERGENCY.Columns.Add("code", typeof(int));
            DT_EMERGENCY.Columns.Add("name", typeof(string));


            // insert row values
            DT_EMERGENCY.Rows.Add(new Object[]{
               1,
                "First"
           
           });
            DT_EMERGENCY.Rows.Add(new Object[]{
               2,
                "Second"
           
           });



            cmbBiAnnual.DisplayMember = "name";
            cmbBiAnnual.ValueMember = "code";
            cmbBiAnnual.DataSource = DT_EMERGENCY;
            cmbBiAnnual.SelectedValue = -1;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            Dictionary<string, string> IPFT_DATA = new Dictionary<string, string>();
            IPFT_DATA.Add("IPFT_AUTHO", DB.validateTextBox(txtAuth));
            IPFT_DATA.Add("ARMY_ID", ARMY_CODE);
            IPFT_DATA.Add("IPFT_TYPE",DB.validateComBox(cmbBiAnnual));
            IPFT_DATA.Add("IPFT_RESULT", DB.validateTextBox(txtResult));
            IPFT_DATA.Add("IPFT_DATE", dtDate.Value.ToString("dd-MMM-y"));
            IPFT_DATA.Add("DESCRIPTION", DB.validateTextBox(txtRemarks));


            if (btnSave.Text == "Save")
            {
                MessageBox.Show(DB.insert("ARMY_IPFT_INFO", IPFT_DATA));
            }
            LoadResult();
        }

        private void LoadResult()
        {
            DataTable DT = DB.select("ARMY_IPFT_INFO", "*", "ARMY_ID='"+ARMY_CODE+"'");

           
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (DataRow row in DT.Rows)
            {

                ListViewItem listitem = new ListViewItem(row["CODE"].ToString());
                listitem.SubItems.Add(DateTime.Parse(row["IPFT_DATE"].ToString()).ToString("dd-MMM-y")); //colICode
                listitem.SubItems.Add(row["IPFT_AUTHO"].ToString()); //colICode
                listitem.SubItems.Add(row["IPFT_TYPE"].ToString()); //colICode
                listitem.SubItems.Add(row["IPFT_RESULT"].ToString()); //colICode
                

                listView1.Items.Add(listitem);


            }
            listView1.EndUpdate();
            listView1.Refresh();
        }
        private void Permission()
        {

            if (userInfo[1] == "4")
            {
               
                btnSave.Enabled = false;
            }
        }
    }
}
