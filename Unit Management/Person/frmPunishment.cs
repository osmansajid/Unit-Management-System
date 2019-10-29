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
    public partial class frmPunishment : Form
    {
        public frmPunishment()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            Dictionary<string, string> PUNISHMENT_DATA = new Dictionary<string, string>();
            PUNISHMENT_DATA.Add("AUTHORITY", DB.validateTextBox(txtAuthNo));
            PUNISHMENT_DATA.Add("ARMY_NO", ARMY_CODE);
            PUNISHMENT_DATA.Add("PUNIS_TYPE", DB.validateComBox(cmbPunishmentType));
            PUNISHMENT_DATA.Add("PUNISH_LOCATION", DB.validateTextBox(txtLocation));
            PUNISHMENT_DATA.Add("SECTION", DB.validateTextBox(txtSection));
            PUNISHMENT_DATA.Add("PUNISH_DATE", dtPunishmentDate.Value.ToString("dd-MMM-y"));
            PUNISHMENT_DATA.Add("OFFENCE_DATE", dtOffenceDate.Value.ToString("dd-MMM-y"));
            PUNISHMENT_DATA.Add("WITNESS", DB.validateTextBox(txtWitNess));
            PUNISHMENT_DATA.Add("GIVEN_BY", DB.validateComBox(cmbGivenBy));
            PUNISHMENT_DATA.Add("DESCRIPTION", DB.validateTextBox(txtRemarks));



            if (btnSave.Text == "Save")
            {
                MessageBox.Show(DB.insert("ARMY_PUNISHMENT_DETAIL", PUNISHMENT_DATA));
            }
            LoadResult();
        }
        private void LoadOfficerList()
        {
            DataTable DT = DB.DBGetAllOfficers();


            cmbGivenBy.DisplayMember = "NAME";
            cmbGivenBy.ValueMember = "CODE";
            cmbGivenBy.DataSource = DT;
            cmbGivenBy.SelectedIndex = -1;


        }
        private void LoadResult()
        {
            DataTable DT = DB.select("ARMY_PUNISHMENT_DETAIL", "*", "ARMY_NO='" + ARMY_CODE + "'");


            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (DataRow row in DT.Rows)
            {

                ListViewItem listitem = new ListViewItem(row["CODE"].ToString());
                
                listitem.SubItems.Add(row["AUTHORITY"].ToString()); //colICode
                listitem.SubItems.Add(row["PUNIS_TYPE"].ToString()); //colICode
                listitem.SubItems.Add(row["SECTION"].ToString()); //colICode
                listitem.SubItems.Add(DateTime.Parse(row["PUNISH_DATE"].ToString()).ToString("dd-MMM-y")); //colICode


                listView1.Items.Add(listitem);


            }
            listView1.EndUpdate();
            listView1.Refresh();
        }
        private void LoadPunishmentType()
        {
            DataTable DT_PUNISHMENT = DB.select("PUNISHMENT_TYPE","*",null, "NAME ASC");

           
                cmbPunishmentType.DisplayMember = "NAME";
                cmbPunishmentType.ValueMember = "CODE";
                cmbPunishmentType.DataSource = DT_PUNISHMENT;
                cmbPunishmentType.SelectedIndex = -1;


            
        }
        private void frmPunishment_Load(object sender, EventArgs e)
        {
            LoadOfficerList();
            LoadPunishmentType();
            LoadResult();
            if (userInfo[1] == "4")
            {
                btnSave.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reports.frmPunishmentReport frmPunishmentReport = new Reports.frmPunishmentReport();
            frmPunishmentReport.setUserInfo(userInfo);
            frmPunishmentReport.setArmyCode(ARMY_CODE);
            frmPunishmentReport.ShowDialog();

        }
    }
}
