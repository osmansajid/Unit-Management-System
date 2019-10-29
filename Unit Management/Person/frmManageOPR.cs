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
    public partial class frmManageOPR : Form
    {
        
        public frmManageOPR()
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
        private void LoadOfficerList()
        {
            DataTable DT = DB.DBGetAllOfficers();

            
            cmbCO.DisplayMember = "NAME";
            cmbCO.ValueMember = "CODE";
            cmbCO.DataSource = DT;
            cmbCO.SelectedIndex = -1;

            
            cmbIO.DisplayMember = "NAME";
            cmbIO.ValueMember = "CODE";
            cmbIO.DataSource = DT.Copy();
            cmbIO.SelectedIndex = -1;
        }

        private void frmManageOPR_Load(object sender, EventArgs e)
        {
            LoadOfficerList();
            LoadAllOPRINFO();
            Permission();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadAllOPRINFO();
        }
        private void Save()
        {
            Dictionary<string, string> OPR_INFO = new Dictionary<string, string>();
            OPR_INFO.Add("YEAR", dtYear.Value.ToString("dd-MMM-y"));
            OPR_INFO.Add("MARKS", DB.validateTextBox(txtMarks));
            OPR_INFO.Add("GRADE_CD", DB.DBGetMarksGradeCode(txtMarks.Text.Trim()));
            OPR_INFO.Add("RECOM_RANK", chkRank.CheckState.ToString() == "Checked" ? "Yes" : "No");
            OPR_INFO.Add("RECOM_MISSION", chkMission.CheckState.ToString() == "Checked" ? "Yes" : "No");
            OPR_INFO.Add("DESCRIPTION", DB.validateTextBox(txtDescription));
            OPR_INFO.Add("IO_ID", DB.validateComBox(cmbIO));
            OPR_INFO.Add("CO_ID", DB.validateComBox(cmbCO));
            OPR_INFO.Add("ARMY_ID",ARMY_CODE);

            if (btnSave.Text == "Save")
            {
                MessageBox.Show(DB.insert("ARMY_OPR_INFO",OPR_INFO));
            }

        }
        private void LoadAllOPRINFO()
        {
            DataTable OPR = DB.select("VW_ARMY_OPR_INFO", "*", "ARMY_ID='" + ARMY_CODE + "'");
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (DataRow row in OPR.Rows)
            {

                ListViewItem listitem = new ListViewItem(row["CODE"].ToString());
                listitem.SubItems.Add(row["YEAR"].ToString()); //colICode
                listitem.SubItems.Add(row["MARKS"].ToString()); //colICode
                listitem.SubItems.Add(row["GRADE"].ToString()); //colICode
                listitem.SubItems.Add("RANK: " + row["RECOM_RANK"].ToString() + " MISSION: " + row["RECOM_MISSION"].ToString()); //colICode
                

                listView1.Items.Add(listitem);


            }
            listView1.EndUpdate();
            listView1.Refresh();
        }
        private void chkRank_CheckStateChanged(object sender, EventArgs e)
        {
            MessageBox.Show(chkRank.CheckState.ToString());
        }
        private void Permission()
        {

            if (userInfo[1] == "4")
            {

                btnSave.Enabled = false;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string code = listView1.SelectedItems[0].SubItems[colCode.Index].Text.ToString();
            string year = listView1.SelectedItems[0].SubItems[colYear.Index].Text.ToString();
            string marks = listView1.SelectedItems[0].SubItems[colMarks.Index].Text.ToString();
            string grade = listView1.SelectedItems[0].SubItems[colGrade.Index].Text.ToString();
            string recommandation = listView1.SelectedItems[0].SubItems[colRecom.Index].Text.ToString();


            //this.dtYear.Text = new DateTime(year);
            //this.txtMarks.Text = marks;
        }
    }
}

