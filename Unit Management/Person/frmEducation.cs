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
    public partial class frmEducation : Form
    {
        public frmEducation()
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
        private void PopulateArmyDataGridView()
        {

            try
            {
                DataTable DT = DB.select("ARMY_COURSE_DETAIL", "*", "ARMY_NO='" + ARMY_CODE + "'", "CODE ASC");

                dataGridView1.DataSource = DT;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void PopulateCivilDataGridView()
        {

            try
            {
                DataTable DT = DB.select("ARMY_EDUCATION_INFO", "*", "ARMY_ID='" + ARMY_CODE + "'", "CODE ASC");

                dataGridView2.DataSource = DT;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void frmEducation_Load(object sender, EventArgs e)
        {
            PopulateCombox();
            PopulateArmyDataGridView();
            PopulateCivilDataGridView();
        }
        private void PopulateCombox()
        {

            DataTable DT = DB.select("COURSE_MASTER", "*");
            cmbCourse.DisplayMember = "NAME";
            cmbCourse.ValueMember = "CODE";
           
            cmbCourse.DataSource = DT;
            
            DT = null;
            DT = DB.select("UNIVERSITY_BOARD", "*");
            cmbUniversity.DisplayMember = "NAME";
            cmbUniversity.ValueMember = "CODE";

            cmbUniversity.DataSource = DT;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                
                Dictionary<string, string> APPT_INFO = new Dictionary<string, string>();
                APPT_INFO.Add("AUTHORITY", row.Cells["txtAuth"].Value == DBNull.Value ? "" : row.Cells["txtAuth"].Value.ToString());
                APPT_INFO.Add("ARMY_NO", ARMY_CODE);
                APPT_INFO.Add("INSTITUTION", row.Cells["txtInst"].Value == DBNull.Value ? "" : row.Cells["txtInst"].Value.ToString());
                APPT_INFO.Add("COURSE_CODE", row.Cells["cmbCourse"].Value == DBNull.Value ? "" : row.Cells["cmbCourse"].Value.ToString());
                APPT_INFO.Add("GRADING", row.Cells["txtGrade"].FormattedValue == DBNull.Value ? "" : row.Cells["txtGrade"].FormattedValue.ToString());
                APPT_INFO.Add("DESCRIPTION", row.Cells["txtDesc"].FormattedValue == DBNull.Value ? "" : row.Cells["txtDesc"].FormattedValue.ToString());


                if (row.Cells["txtAuth"].FormattedValue != "")
                {
                    if (row.Cells["txtCode"].Value == DBNull.Value) //Insert
                    {


                        if (Convert.ToBoolean(DB.insert("ARMY_COURSE_DETAIL", APPT_INFO, true)))
                        {
                            this.BeginInvoke(new MethodInvoker(() =>
                            {
                                PopulateArmyDataGridView();
                            }));

                        }
                        else
                        {
                            MessageBox.Show("Invalid Operation");
                            PopulateArmyDataGridView();
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(DB.update("ARMY_COURSE_DETAIL", APPT_INFO, "CODE='" + row.Cells["txtCode"].Value.ToString() + "'", true)))
                        {
                            //PopulateDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Operation");
                            PopulateArmyDataGridView();
                        }
                    }

                }
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView2.CurrentRow;
                
                Dictionary<string, string> APPT_INFO = new Dictionary<string, string>();
                APPT_INFO.Add("RESULT", row.Cells["txtResult"].Value == DBNull.Value ? "" : row.Cells["txtResult"].Value.ToString());
                APPT_INFO.Add("ARMY_ID", ARMY_CODE);
                APPT_INFO.Add("UNI_BOARD", row.Cells["cmbUniversity"].Value == DBNull.Value ? "" : row.Cells["cmbUniversity"].Value.ToString());
                APPT_INFO.Add("PASS_YEAR", row.Cells["txtPassYear"].Value == DBNull.Value ? "" : row.Cells["txtPassYear"].Value.ToString());
                APPT_INFO.Add("ROLL_NO", row.Cells["txtRollNo"].FormattedValue == DBNull.Value ? "" : row.Cells["txtRollNo"].FormattedValue.ToString());
                APPT_INFO.Add("DESCRIPTION", row.Cells["txtDescription"].FormattedValue == DBNull.Value ? "" : row.Cells["txtDescription"].FormattedValue.ToString());
                APPT_INFO.Add("EXAM", row.Cells["txtExam"].FormattedValue == DBNull.Value ? "" : row.Cells["txtExam"].FormattedValue.ToString());


                if (row.Cells["txtResult"].FormattedValue != "" && row.Cells["cmbUniversity"].Value !=DBNull.Value)
                {
                    if (row.Cells["txtCCode"].Value == DBNull.Value) //Insert
                    {


                        if (Convert.ToBoolean(DB.insert("ARMY_EDUCATION_INFO", APPT_INFO, true)))
                        {
                            this.BeginInvoke(new MethodInvoker(() =>
                            {
                                PopulateCivilDataGridView();
                            }));

                        }
                        else
                        {
                            MessageBox.Show("Invalid Operation");
                            PopulateCivilDataGridView();
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(DB.update("ARMY_EDUCATION_INFO", APPT_INFO, "CODE='" + row.Cells["txtCCode"].Value.ToString() + "'", true)))
                        {
                            //PopulateDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Operation");
                            PopulateCivilDataGridView();
                        }
                    }

                }
            }
        }
    }
}
