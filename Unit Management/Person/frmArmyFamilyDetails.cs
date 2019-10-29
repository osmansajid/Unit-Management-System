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
    public partial class frmArmyFamilyDetails : Form
    {
        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        string ARMY_CODE = null;
        public frmArmyFamilyDetails()
        {
            InitializeComponent();
        }
        internal void setUserInfo(string[] userInfo)
        {
            this.userInfo = userInfo;
        }
        internal void setArmyCode(string armyCode)
        {
            this.ARMY_CODE = armyCode;
        }

        private void LoadRelation(string selectedID = null)
        {
            DataTable DT_RELATION = DB.select("RELATIONS_MASTER", "*", null, "NAME ASC");

            cmbRelation.DisplayMember = "NAME";
            cmbRelation.ValueMember = "CODE";
            cmbRelation.DataSource = DT_RELATION;
            if (selectedID == null)
            {
                cmbRelation.SelectedIndex = -1;
            }
            else
            {
                cmbRelation.SelectedValue = selectedID;
            }
        }
        private void LoadOccupatiion(string selectedID = null)
        {
            DataTable DT_Occupatiion = DB.select("OCCUPATION_MASTER", "*", null, "NAME ASC");
            
            cmbOccupation.DisplayMember = "NAME";
            cmbOccupation.ValueMember = "CODE";
            cmbOccupation.DataSource = DT_Occupatiion;
            if (selectedID == null)
            {
                cmbOccupation.SelectedIndex = -1;
            }
            else
            {
                cmbOccupation.SelectedValue = selectedID;
            }
        }
        private void LoadEmergency()
        {
            DataTable DT_EMERGENCY = new DataTable();
            // create fields

            DT_EMERGENCY.Columns.Add("code", typeof(int));
            DT_EMERGENCY.Columns.Add("name", typeof(string));


            // insert row values
            DT_EMERGENCY.Rows.Add(new Object[]{
               1,
                "Yes"
           
           });
            DT_EMERGENCY.Rows.Add(new Object[]{
               0,
                "No"
           
           });
           


            cmbEmergency.DisplayMember = "name";
            cmbEmergency.ValueMember = "code";
            cmbEmergency.DataSource = DT_EMERGENCY;
            cmbEmergency.SelectedValue = -1;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();

        }
        private void Save()
        {
            try
            {
                Dictionary<string, string> ARMY_FAMILY_INFO = new Dictionary<string, string>();
                ARMY_FAMILY_INFO.Add("ARMY_ID", ARMY_CODE);
                ARMY_FAMILY_INFO.Add("NAME", DB.validateTextBox(txtName));
                ARMY_FAMILY_INFO.Add("RELATION_ID", DB.validateComBox(cmbRelation));
                ARMY_FAMILY_INFO.Add("DOB", dtDOB.Value.ToString("dd-MMM-y"));
                ARMY_FAMILY_INFO.Add("OCUPATION_ID", DB.validateComBox(cmbOccupation));
                ARMY_FAMILY_INFO.Add("DESCRIPTION", DB.validateTextBox(txtRemarks));
                ARMY_FAMILY_INFO.Add("ADDRESS", DB.validateTextBox(txtAddress));
                ARMY_FAMILY_INFO.Add("PHONE_NO", DB.validateTextBox(txtPhone));
                ARMY_FAMILY_INFO.Add("EMERGENCY", DB.validateComBox(cmbEmergency));


                if (btnSave.Text == "Save")
                {



                    MessageBox.Show(DB.insert("ARMY_FAMILY_DETAIL", ARMY_FAMILY_INFO));
                    LoadAllFamily();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void frmArmyFamilyDetails_Load(object sender, EventArgs e)
        {
            LoadRelation();
            LoadOccupatiion();
            LoadEmergency();
            LoadAllFamily();
            Permission();
        }
        private void LoadAllFamily()
        {
            DataTable OPR = DB.select("VW_ARMY_FAMILY_DETAIL", "*", "ARMY_ID='" + ARMY_CODE + "'");
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (DataRow row in OPR.Rows)
            {

                ListViewItem listitem = new ListViewItem(row["CODE"].ToString());
                listitem.SubItems.Add(row["NAME"].ToString()); //colICode
                listitem.SubItems.Add(row["RELATION_NAME"].ToString()); //colICode
                listitem.SubItems.Add(row["EMERGENCY_VALUE"].ToString()); //colICode



                listView1.Items.Add(listitem);


            }
            listView1.EndUpdate();
            listView1.Refresh();
        }

        private void Permission()
        {

            if (userInfo[1] == "4")
            {
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
        }
    }
}
