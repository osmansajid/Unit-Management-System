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
    public partial class frmLeave : Form
    {
        public frmLeave()
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
        private void frmLeave_Load(object sender, EventArgs e)
        {
            PopulateApptCombox();
            PopulateDataGridView();
           
        }

        private void PopulateApptCombox()
        {

            DataTable DT = DB.select("ORG_MASTER", "*", "TYPE !=0", "NAME ASC");
            cmbNearBase.DisplayMember = "NAME";
            cmbNearBase.ValueMember = "CODE";

            cmbNearBase.DataSource = DT;

            DT = null;

            DT = DB.select("LEAVE_TYPE", "*",null ,"NAME ASC");
            cmbLeaveType.DisplayMember = "NAME";
            cmbLeaveType.ValueMember = "CODE";

            cmbLeaveType.DataSource = DT;

           
        }
        private void PopulateDataGridView()
        {

            try
            {
                DataTable DT = DB.select("ARMY_LEAVE_DETAIL", "CODE,LV_AUTHORITY,LV_ARMY_NO,LV_TYPE,FORM_D,FROM_DATE,TO_DATE,LEAVE_ADDRESS,NEAR_CANTONMENT,DESCRIPTION", "LV_ARMY_NO='" + ARMY_CODE + "'", "CODE ASC");

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
                
                Dictionary<string, string> LEAVE = new Dictionary<string, string>();
                
                LEAVE.Add("LV_AUTHORITY", row.Cells["txtAuth"].Value == DBNull.Value ? "" : row.Cells["txtAuth"].Value.ToString());
                LEAVE.Add("LV_ARMY_NO", ARMY_CODE);
                LEAVE.Add("LV_TYPE", row.Cells["cmbLeaveType"].Value == DBNull.Value ? "" : row.Cells["cmbLeaveType"].Value.ToString());
                LEAVE.Add("FORM_D", row.Cells["cmbFormD"].Value == DBNull.Value ? "" : row.Cells["cmbFormD"].Value.ToString());
                LEAVE.Add("FROM_DATE", row.Cells["txtFromDate"].FormattedValue == DBNull.Value ? "" : row.Cells["txtFromDate"].FormattedValue.ToString());
                LEAVE.Add("TO_DATE", row.Cells["txtToDate"].FormattedValue == DBNull.Value ? "" : row.Cells["txtToDate"].FormattedValue.ToString());
                LEAVE.Add("LEAVE_ADDRESS", row.Cells["txtLeaveAddress"].FormattedValue == DBNull.Value ? "" : row.Cells["txtLeaveAddress"].FormattedValue.ToString());
                LEAVE.Add("NEAR_CANTONMENT", row.Cells["cmbNearBase"].Value == DBNull.Value ? "" : row.Cells["cmbNearBase"].Value.ToString());
                LEAVE.Add("DESCRIPTION", row.Cells["txtDescription"].FormattedValue == DBNull.Value ? "" : row.Cells["txtDescription"].FormattedValue.ToString());




                if (ARMY_CODE != "" && row.Cells["txtAuth"].FormattedValue != "" && row.Cells["cmbLeaveType"].FormattedValue != "" && row.Cells["txtFromDate"].FormattedValue != "" && row.Cells["txtToDate"].FormattedValue != "")
                {
                    if (row.Cells["txtCode"].Value == null) //Insert
                    {


                        if (Convert.ToBoolean(DB.insert("ARMY_LEAVE_DETAIL", LEAVE, true)))
                        {
                            
                           
                                PopulateDataGridView();
                           

                        }
                        else
                        {
                            MessageBox.Show("Invalid Operation");
                            PopulateDataGridView();
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(DB.update("ARMY_LEAVE_DETAIL", LEAVE, "CODE='" + row.Cells["txtCode"].Value.ToString() + "'", true)))
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
    }
}
