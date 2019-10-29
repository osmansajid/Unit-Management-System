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
    public partial class frmArmyMasterInfoManage : Form
    {
        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        public frmArmyMasterInfoManage()
        {
            InitializeComponent();
        }
        internal void setUserInfo(string[] userInfo)
        {
            this.userInfo = userInfo;
        }
        private void LoadSearchBy()
        {
            DataTable DT_LoadBySearch = new DataTable();
            // create fields

           
            DT_LoadBySearch.Columns.Add("field", typeof(string));
            DT_LoadBySearch.Columns.Add("name", typeof(string));
          


            // insert row values
            DT_LoadBySearch.Rows.Add(new Object[]{
                "ARMY_NO",
                "Army No"
           
           });
            DT_LoadBySearch.Rows.Add(new Object[]{
                "MOBILE_NO",
                "Mobile Number"
           
           });
            DT_LoadBySearch.Rows.Add(new Object[]{
                "FIRST_NAME",
                "First Name"
           
           });


            cmbSearchBy.DisplayMember = "name";
            cmbSearchBy.ValueMember = "field";
            cmbSearchBy.DataSource = DT_LoadBySearch;
            cmbSearchBy.SelectedValue = -1;

        }

        private void frmArmyMasterInfoManage_Load(object sender, EventArgs e)
        {
            LoadSearchBy();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            DataTable DT = DB.select("VW_ARMY_MASTER_INFO", "*", cmbSearchBy.SelectedValue.ToString() + " LIKE('%" + txtKeyword.Text.Trim() + "%')");

            if (DT.Rows.Count > 0)
            {
                listView1.Enabled = true;

            }
            else
            {
                listView1.Enabled = false;
            }
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (DataRow row in DT.Rows)
            {

                ListViewItem listitem = new ListViewItem(row["CODE"].ToString());
                listitem.SubItems.Add(row["ARMY_NO"].ToString()); //colICode
                listitem.SubItems.Add(row["FIRST_NAME"].ToString() + " " + row["LAST_NAME"].ToString()); //colICode
                listitem.SubItems.Add(row["RANK_NAME"].ToString()); //colICode
                listitem.SubItems.Add(row["TRADE_NAME"].ToString()); //colICode
                listitem.SubItems.Add(row["MOBILE_NO"].ToString()); //colICode

                listView1.Items.Add(listitem);
               

            }
            listView1.EndUpdate();
            listView1.Refresh();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            Person.frmArmyMasterInfo frmArmyMasterInfo = new Person.frmArmyMasterInfo();
            frmArmyMasterInfo.setUserInfo(userInfo);
            frmArmyMasterInfo.setPrimaryKey(listView1.SelectedItems[0].SubItems[colCode.Index].Text.ToString());
            frmArmyMasterInfo.ShowDialog();
           
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count >0)
            {
                Reports.frmJobDocument frmJobDocument = new Reports.frmJobDocument();
                frmJobDocument.setUserInfo(userInfo);
                frmJobDocument.setArmyCode(listView1.SelectedItems[0].SubItems[colCode.Index].Text.ToString());
                frmJobDocument.ShowDialog();
            }
        }
    }
}
