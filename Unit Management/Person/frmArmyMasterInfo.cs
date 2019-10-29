using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unit_Management.Core;


namespace Unit_Management.Person
{
    public partial class frmArmyMasterInfo : Form
    {
        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        DataTable RANKDATA, TRADEDATA, DIVISIONData, DISTRICTData, UPAZILAData, EXISTINGDATA, DT_UNIT;
        string PhotoBase64 = null;
        string PrimaryKey = null;

        public frmArmyMasterInfo()
        {
            InitializeComponent();
        }

        internal void setUserInfo(string[] userInfo)
        {
            this.userInfo = userInfo;
        }
        private void LoadRankList(string selectedID = null)
        {

            cmbRank.DisplayMember = "NAME";
            cmbRank.ValueMember = "CODE";
            cmbRank.DataSource = RANKDATA;
            if (selectedID == null)
            {
                cmbRank.SelectedIndex = -1;
            }
            else
            {
                cmbRank.SelectedValue = selectedID;
            }
        }
        private void LoadUnitList(string selectedID = null)
        {

            cmbUnitName.DisplayMember = "NAME";
            cmbUnitName.ValueMember = "CODE";
            cmbUnitName.DataSource = DT_UNIT;
            if (selectedID == null)
            {
                cmbUnitName.SelectedIndex = -1;
            }
            else
            {
                cmbUnitName.SelectedValue = selectedID;
            }
        }
        private void LoadTradeList(string selectedID = null)
        {

            cmbTradeName.DisplayMember = "NAME";
            cmbTradeName.ValueMember = "CODE";
            cmbTradeName.DataSource = TRADEDATA;
            if (selectedID == null)
            {
                cmbTradeName.SelectedIndex = -1;
            }
            else
            {
                cmbTradeName.SelectedValue = selectedID;
            }
        }
        private void LoadPERDivisionList(string selectedID = null)
        {
            

            cmbPerDivision.DisplayMember = "NAME";
            cmbPerDivision.ValueMember = "ID";
            cmbPerDivision.DataSource = DIVISIONData;
            if (selectedID == null)
            {
                cmbPerDivision.SelectedIndex = -1;
            }
            else
            {
                cmbPerDivision.SelectedValue = selectedID;
            }
        }
        private void LoadPRERDivisionList(string selectedID = null)
        {

            
            cmbPreDivision.DisplayMember = "NAME";
            cmbPreDivision.ValueMember = "ID";
            cmbPreDivision.DataSource = DIVISIONData.Copy();
            if (selectedID == null)
            {
                cmbPreDivision.SelectedIndex = -1;
            }
            else
            {
                cmbPreDivision.SelectedValue = selectedID;
            }
        }

        private void FromLoadList()
        {
            bwLoadData.RunWorkerAsync();
            LoadBloodGroup();
        }

        private void frmArmyMasterInfo_Load(object sender, EventArgs e)
        {
            FromLoadList();
            Permission();
        }

        private void bwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            //Load Rank Data
            RANKDATA=DB.DBGetRankList();
            TRADEDATA = DB.DBGetTradeList();
            DIVISIONData = DB.DBGetDivisialList();
            DISTRICTData=DB.DBGetDistrictList();
            UPAZILAData = DB.DBGetUpazilaList();
            DT_UNIT = DB.DBGetUnitList();

            if (PrimaryKey != null)
            {
                EXISTINGDATA = DB.select("VW_ARMY_MASTER_INFO", "*", "CODE=" + PrimaryKey);
            }
        }
        private void LoadBloodGroup()
        {
            DataTable DT_BLOOD_GROUP = new DataTable();
            // create fields

            DT_BLOOD_GROUP.Columns.Add("name", typeof(string));


            // insert row values
            DT_BLOOD_GROUP.Rows.Add(new Object[]{
               
                "A+"
           
           });
            DT_BLOOD_GROUP.Rows.Add(new Object[]{
               
                "A-"
           
           });
            DT_BLOOD_GROUP.Rows.Add(new Object[]{
               
                "B-"
           
           });
            DT_BLOOD_GROUP.Rows.Add(new Object[]{
               
                "B+"
           
           });


            cmbBloodGroup.DisplayMember = "name";
            cmbBloodGroup.ValueMember = "name";
            cmbBloodGroup.DataSource = DT_BLOOD_GROUP;
            cmbBloodGroup.SelectedValue = -1;

        }


        private void LoadDistrict(ComboBox cmb, string Division_ID)
        {



            if (Division_ID != null)
            {
                DataTable DT_DIV = DISTRICTData.Copy();
                if (DT_DIV.Rows.Count > 0)
                {
                    DT_DIV = DT_DIV.AsEnumerable()
              .Where(row => row.Field<Int64>("division_id") == Convert.ToInt64(Division_ID))

              .OrderBy(row => row.Field<String>("name"))
              .CopyToDataTable();
                }
                cmb.DisplayMember = "name";
                cmb.ValueMember = "id";
                cmb.DataSource = DT_DIV;
                cmb.SelectedIndex = -1;


            }
        }
        private void LoadUpazila(ComboBox cmb, string District_ID)
        {



            if (District_ID != null)
            {
                DataTable DT_Upazila = UPAZILAData.Copy();
                if (DT_Upazila.Rows.Count > 0)
                {
                    DT_Upazila = DT_Upazila.AsEnumerable()
              .Where(row => row.Field<Int64>("district_id") == Convert.ToInt64(District_ID))

              .OrderBy(row => row.Field<String>("name"))
              .CopyToDataTable();
                }
                cmb.DisplayMember = "name";
                cmb.ValueMember = "id";
                cmb.DataSource = DT_Upazila;
                cmb.SelectedIndex = -1;
            }


        }
        private void bwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadRankList();
            LoadUnitList();
            LoadTradeList();
            LoadPERDivisionList();
            LoadPRERDivisionList();
            //Hide DataLoad Progress
            pgLoadData.Hide();

            gbContactInformation.Enabled = true;
            gbPersonalInfo.Enabled = true;
            FillFormWithExistingData();


        }

        private void cmbPerDivision_Validated(object sender, EventArgs e)
        {
            LoadDistrict(cmbPerDistrict, cmbPerDivision.SelectedValue.ToString());
        }

        private void cmbPerDistrict_Validated(object sender, EventArgs e)
        {
            LoadUpazila(cmbPerUpazila, cmbPerDistrict.SelectedValue.ToString());
        }

        private void cmbPreDivision_Validated(object sender, EventArgs e)
        {
            LoadDistrict(cmbPreDistrict, cmbPreDivision.SelectedValue.ToString());
        }

        private void cmbPreDistrict_Validated(object sender, EventArgs e)
        {
            LoadUpazila(cmbPreUpazila, cmbPreDistrict.SelectedValue.ToString());
        }

        private void SaveData()
        {
            try
            {
                Dictionary<string, string> ARMY_MASTER_INFO = new Dictionary<string, string>();
                ARMY_MASTER_INFO.Add("ARMY_NO", DB.validateTextBox(txtArmyNo));
                ARMY_MASTER_INFO.Add("FIRST_NAME", DB.validateTextBox(txtFirstName));
                ARMY_MASTER_INFO.Add("LAST_NAME", DB.validateTextBox(txtLastName));
                ARMY_MASTER_INFO.Add("DOB", dtDateofBirth.Value.ToString("dd-MMM-y"));
                ARMY_MASTER_INFO.Add("BLOOD_GROUP", DB.validateComBox(cmbBloodGroup));
                ARMY_MASTER_INFO.Add("MOBILE_NO", DB.validateTextBox(txtMobileNo));
                ARMY_MASTER_INFO.Add("TRADE", DB.validateComBox(cmbTradeName));
                ARMY_MASTER_INFO.Add("RANK", DB.validateComBox(cmbRank));
                ARMY_MASTER_INFO.Add("PER_UPAZILLA_CODE", DB.validateComBox(cmbPerUpazila));
                ARMY_MASTER_INFO.Add("PER_ADDRESS", DB.validateTextBox(txtPermanentAddress));
                ARMY_MASTER_INFO.Add("PRE_UPZILLA_CODE", DB.validateComBox(cmbPreUpazila));
                ARMY_MASTER_INFO.Add("PRE_ADDRESS", DB.validateTextBox(txtPresentAddress));
                if (PhotoBase64 != null || PhotoBase64 != "")
                {
                    ARMY_MASTER_INFO.Add("PHOTO", PhotoBase64);
                }
                if (btnSave.Text == "Save")
                {

                    
                   

                    if (Convert.ToBoolean(DB.insert("ARMY_MASTER_INFO", ARMY_MASTER_INFO, true)))
                    {
                        PrimaryKey = DB.DBGetArmyMasterInfoIDByArmyNo(DB.validateTextBox(txtArmyNo));
                        if (PrimaryKey != null)
                        {
                            MessageBox.Show("Recoed Saved!");
                            btnSave.Text = "Update";
                        }
                    }

                }
                else
                {
                    MessageBox.Show(DB.update("ARMY_MASTER_INFO", ARMY_MASTER_INFO, "CODE='" + PrimaryKey + "'"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void OpenPhoto()
        {
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Image File";
            theDialog.Filter = "JPEG files|*.jpg";
            theDialog.InitialDirectory = @"C:\";
            theDialog.RestoreDirectory = true;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            PhotoBase64 = DB.base64ImageEncode(theDialog.FileName);
                            pbPhoto.Image = DB.DBLoadImage(PhotoBase64);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenPhoto();
        }

        internal void setPrimaryKey(string p)
        {
            PrimaryKey = p;
        }
        private void FillFormWithExistingData()
        {
            if (EXISTINGDATA != null && EXISTINGDATA.Rows.Count > 0)
            {
                foreach (DataRow row in EXISTINGDATA.Rows)
                {
                    txtArmyNo.Text = row["ARMY_NO"].ToString();
                    txtMobileNo.Text = row["MOBILE_NO"].ToString();
                    txtFirstName.Text = row["FIRST_NAME"].ToString();
                    txtLastName.Text = row["LAST_NAME"].ToString();
                    dtDateofBirth.Value = DateTime.Parse(row["DOB"].ToString());
                    cmbBloodGroup.SelectedValue = row["BLOOD_GROUP"].ToString();
                    cmbRank.SelectedValue = row["RANK"].ToString();
                    cmbTradeName.SelectedValue = row["TRADE"].ToString();

                    //Contact Information

                    //Permanent Address
                    cmbPerDivision.SelectedValue = row["PER_DIVISION_CODE"].ToString();
                    cmbPerDivision_Validated(null, null);
                    cmbPerDistrict.SelectedValue = row["PER_DISTRICT_CODE"].ToString();
                    cmbPerDistrict_Validated(null, null);
                    cmbPerUpazila.SelectedValue = row["PER_UPAZILLA_CODE"].ToString();
                    txtPermanentAddress.Text = row["PER_ADDRESS"].ToString();

                    //Present Address

                    cmbPreDivision.SelectedValue = row["PRE_DIVISION_CODE"].ToString();
                    cmbPreDivision_Validated(null, null);
                    cmbPreDistrict.SelectedValue = row["PRE_DISTRICT_CODE"].ToString();
                    cmbPreDistrict_Validated(null, null);
                    cmbPreUpazila.SelectedValue = row["PRE_UPZILLA_CODE"].ToString();

                    txtPresentAddress.Text = row["PRE_ADDRESS"].ToString();
                    PhotoBase64 = row["PHOTO"].ToString();
                    pbPhoto.Image = DB.DBLoadImage(PhotoBase64);
                  
                }
                btnSave.Text = "Update";
            }
        }

        private void btnOPR_Click(object sender, EventArgs e)
        {
            Person.frmManageOPR frmManageOPR = new Person.frmManageOPR();
            frmManageOPR.setUserInfo(userInfo);
            frmManageOPR.setArmyCode(PrimaryKey);
            frmManageOPR.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person.frmArmyFamilyDetails frmArmyFamilyDetails = new Person.frmArmyFamilyDetails();
            frmArmyFamilyDetails.setUserInfo(userInfo);
            frmArmyFamilyDetails.setArmyCode(PrimaryKey);
            frmArmyFamilyDetails.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person.frmIPFT frmIPFT = new Person.frmIPFT();
            frmIPFT.setUserInfo(userInfo);
            frmIPFT.setArmyCode(PrimaryKey);
            frmIPFT.ShowDialog();
        }

        private void btnPunishment_Click(object sender, EventArgs e)
        {
            Person.frmPunishment frmPunishment = new Person.frmPunishment();
            frmPunishment.setUserInfo(userInfo);
            frmPunishment.setArmyCode(PrimaryKey);
            frmPunishment.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Person.frmAppt frmAppt = new Person.frmAppt();
            frmAppt.setUserInfo(userInfo);
            frmAppt.setArmyCode(PrimaryKey);
            frmAppt.ShowDialog();
        }

        private void Permission()
        {

            if (userInfo[1] == "4")
            {
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Person.frmTrgPlan frmTrgPlan = new frmTrgPlan();
            frmTrgPlan.setUserInfo(userInfo);
            frmTrgPlan.setArmyCode(PrimaryKey);
            frmTrgPlan.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Person.frmLeave frmLeave = new frmLeave();
            frmLeave.setUserInfo(userInfo);
            frmLeave.setArmyCode(PrimaryKey);
            frmLeave.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Person.frmFgAssignment frmFgAssignment = new frmFgAssignment();
            frmFgAssignment.setUserInfo(userInfo);
            frmFgAssignment.setArmyCode(PrimaryKey);
            frmFgAssignment.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Person.frmEducation frmEducation = new frmEducation();
            frmEducation.setUserInfo(userInfo);
            frmEducation.setArmyCode(PrimaryKey);
            frmEducation.ShowDialog();
        }
    }
}
