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
    public partial class frmTrgPlan : Form
    {

        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        string ARMY_CODE = null;


        public frmTrgPlan()
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
        private void frmTrgPlan_Load(object sender, EventArgs e)
        {
            FillCourse();
            PopulateDataGridView();
            
        }

        private void PopulateDataGridView()
        {

            try
            {
                DataTable DT = DB.select("ARMY_TRAINING_CYCLE", "*", "TRAIN_ARMY_NO='" + ARMY_CODE + "'", "CODE ASC");

                dataGridView1.DataSource = DT;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                Dictionary<string, string> TRG = new Dictionary<string, string>();
                TRG.Add("TRAIN_ARMY_NO", ARMY_CODE);
                TRG.Add("TRAIN_CYCLE", row.Cells["cmbCycle"].Value == DBNull.Value ? "" : row.Cells["cmbCycle"].Value.ToString());
                TRG.Add("TRAIN_COURSE", row.Cells["cmbCourse"].Value == DBNull.Value ? "" : row.Cells["cmbCourse"].Value.ToString());
                TRG.Add("FROM_DATE", row.Cells["txtFromDate"].FormattedValue == DBNull.Value ? "" : row.Cells["txtFromDate"].FormattedValue.ToString());
                TRG.Add("TO_DATE", row.Cells["txtToDate"].FormattedValue == DBNull.Value ? "" : row.Cells["txtToDate"].FormattedValue.ToString());
                TRG.Add("REMARKS", row.Cells["txtRemarks"].FormattedValue == DBNull.Value ? "" : row.Cells["txtRemarks"].FormattedValue.ToString());




                if (ARMY_CODE != "" && row.Cells["cmbCycle"].FormattedValue != "" && row.Cells["txtFromDate"].FormattedValue != "")
                {
                    if (row.Cells["txtCode"].Value == DBNull.Value) //Insert
                    {


                        if (Convert.ToBoolean(DB.insert("ARMY_TRAINING_CYCLE", TRG, true)))
                        {
                            this.BeginInvoke(new MethodInvoker(() =>
                            {
                                PopulateDataGridView();
                            }));

                        }
                        else
                        {
                            MessageBox.Show("Invalid Operation");
                            PopulateDataGridView();
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(DB.update("ARMY_TRAINING_CYCLE", TRG, "CODE='" + row.Cells["txtCode"].Value.ToString() + "'", true)))
                        {
                            //PopulateDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Operation");
                            PopulateDataGridView();
                        }
                    }

                }
                else
                {
                    
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Authority must not be empty";
                      
                   
                }
            }
        }


        private void FillCourse()
        {

            DataTable DT = DB.select("COURSE_MASTER", "*");
            cmbCourse.DisplayMember = "NAME";
            cmbCourse.ValueMember = "CODE";
           
            cmbCourse.DataSource = DT;

            DT = null;
            DT = DB.select("TRAINING_CYCLE", "*");
            cmbCycle.DisplayMember = "NAME";
            cmbCycle.ValueMember = "CODE";

            cmbCycle.DataSource = DT;
        }
    }
}
