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
    public partial class frmFgAssignment : Form
    {
        public frmFgAssignment()
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

        private void frmFgAssignment_Load(object sender, EventArgs e)
        {
            FillComBox();
            PopulateDataGridView();
        }
        private void FillComBox()
        {
            
            DataTable DT = DB.select("FOREIGN_ASSIGN_TYPE", "*");
            cmbFgType.DisplayMember = "NAME";
            cmbFgType.ValueMember = "CODE";

            cmbFgType.DataSource = DT;
            
            DT = null;
            DT = DB.select("ACCIDENT_TYPE", "*");
            cmbAccidentType.DisplayMember = "NAME";
            cmbAccidentType.ValueMember = "CODE";

            cmbAccidentType.DataSource = DT;
        }
        private void PopulateDataGridView()
        {

            try
            {
                DataTable DT = DB.select("ARMY_FOREGN_ASSIGN", "*", "ARMY_NO='" + ARMY_CODE + "'", "CODE ASC");

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
                TRG.Add("ARMY_NO", ARMY_CODE);

                TRG.Add("AUTHORITY", row.Cells["txtAuth"].Value == DBNull.Value ? "" : row.Cells["txtAuth"].Value.ToString());
                TRG.Add("FOREIGN_TYPE", row.Cells["cmbFgType"].Value == DBNull.Value ? "" : row.Cells["cmbFgType"].Value.ToString());
                TRG.Add("ACCEDIENT_TYPE", row.Cells["cmbAccidentType"].Value == DBNull.Value ? "" : row.Cells["cmbAccidentType"].Value.ToString());
                TRG.Add("ACHIVEMENT", row.Cells["txtAchivement"].FormattedValue == DBNull.Value ? "" : row.Cells["txtAchivement"].FormattedValue.ToString());
                TRG.Add("REASON", row.Cells["txtReason"].FormattedValue == DBNull.Value ? "" : row.Cells["txtReason"].FormattedValue.ToString());
                TRG.Add("FROM_DATE", row.Cells["txtFromDate"].FormattedValue == DBNull.Value ? "" : row.Cells["txtFromDate"].FormattedValue.ToString());
                TRG.Add("TO_DATE", row.Cells["txtToDate"].FormattedValue == DBNull.Value ? "" : row.Cells["txtToDate"].FormattedValue.ToString());




                if (ARMY_CODE != "" && row.Cells["txtAuth"].FormattedValue != DBNull.Value && row.Cells["cmbFgType"].Value != DBNull.Value && row.Cells["txtFromDate"].Value != DBNull.Value)
                {
                    if (row.Cells["txtCode"].Value == DBNull.Value) //Insert
                    {


                        if (Convert.ToBoolean(DB.insert("ARMY_FOREGN_ASSIGN", TRG, true)))
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
                        if (Convert.ToBoolean(DB.update("ARMY_FOREGN_ASSIGN", TRG, "CODE='" + row.Cells["txtCode"].Value.ToString() + "'", true)))
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


