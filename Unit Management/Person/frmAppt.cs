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
using Oracle.ManagedDataAccess.Client;

namespace Unit_Management.Person
{
    public partial class frmAppt : Form
    {
        public frmAppt()
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
        private void frmAppt_Load(object sender, EventArgs e)
        {
            PopulateApptCombox();
            PopulateDataGridView();
            Permission();
        }

        private void PopulateApptCombox()
        {
            
            DataTable DT = DB.select("APPT_MASTER", "*");
            cmbAppt.DisplayMember = "NAME";
            cmbAppt.ValueMember = "CODE";
            DataRow topRow = DT.NewRow();
            topRow[0] = 0;
            topRow[1] = "-Select-";
            cmbAppt.DataSource = DT;
        }
        private void PopulateDataGridView()
        {

            try
            {
                DataTable DT = DB.select("ARMY_APPT_INFO", "*", "ARMY_NO='" + ARMY_CODE + "'", "CODE ASC");

                dataGridView1.DataSource = DT;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        
        private void CheckEmptyToDate(int index)
        {
            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
{
    if (rw.Index != index)
    {
        for (int i = 0; i < rw.Cells.Count; i++)
        {
            if (rw.Cells[5].Value == null)
            {
                MessageBox.Show("");
            }
        }
    }
}
        }
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Validate the CompanyName entry by disallowing empty strings.
            if (dataGridView1.Columns[e.ColumnIndex].Name == "txtAuthority")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText =
                        "Authority must not be empty";
                    e.Cancel = true;
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "cmbAppt")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText =
                        "Appoinment must not be empty";
                    e.Cancel = true;
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "txtFromDate")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {


                    dataGridView1.Rows[e.RowIndex].ErrorText =
                        "Appoinment must not be empty";
                    e.Cancel = true;
                }else if(!DB.CheckDate(e.FormattedValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText =
                        "Invalid Date.";
                    e.Cancel = true;
                }
            }
        }

        
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                Dictionary<string, string> APPT_INFO = new Dictionary<string, string>();
                APPT_INFO.Add("AUTHORITY", row.Cells["txtAuthority"].Value == DBNull.Value ? "" : row.Cells["txtAuthority"].Value.ToString());
                APPT_INFO.Add("ARMY_NO", ARMY_CODE);
                APPT_INFO.Add("APPT_NO", row.Cells["cmbAppt"].Value == DBNull.Value ? "" : row.Cells["cmbAppt"].Value.ToString());
                APPT_INFO.Add("FROM_DATE", row.Cells["txtFromDate"].FormattedValue == DBNull.Value ? "" : row.Cells["txtFromDate"].FormattedValue.ToString());
                APPT_INFO.Add("TO_DATE", row.Cells["txtToDate"].FormattedValue == DBNull.Value ? "" : row.Cells["txtToDate"].FormattedValue.ToString());


                if (row.Cells["txtAuthority"].FormattedValue != "" && row.Cells["cmbAppt"].FormattedValue != "" && row.Cells["txtFromDate"].FormattedValue != "")
                {
                if (row.Cells["txtCode"].Value == DBNull.Value) //Insert
                {


                    if (Convert.ToBoolean(DB.insert("ARMY_APPT_INFO", APPT_INFO, true)))
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
                        if (Convert.ToBoolean(DB.update("ARMY_APPT_INFO", APPT_INFO, "CODE='" + row.Cells["txtCode"].Value.ToString() + "'", true)))
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
            }
        }
        private void Permission()
        {

            if (userInfo[1] == "4")
            {

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.Enabled = false;
             
            }
        }
    }
}
