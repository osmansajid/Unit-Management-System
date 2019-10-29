using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Reporting.WinForms;
using Unit_Management.Core;

namespace Unit_Management.Reports
{
    public partial class frmTrainingCycle : Form
    {
        public frmTrainingCycle()
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
        private void frmTrainingCycle_Load(object sender, EventArgs e)
        {
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            this.reportViewer1.ZoomMode = ZoomMode.Percent;

            this.reportViewer1.ZoomPercent = 150;
            loadReport();
          
        }

        private void loadReport()
        {

            DataSets.DsJobDocument jobDocument = new DataSets.DsJobDocument();
            OracleDataAdapter DA_JobDocument = DB.selectAdapter("VW_ARMY_TRAINING_CYCLE", "*");
            DA_JobDocument.Fill(jobDocument, jobDocument.Tables[2].TableName);

            ReportDataSource RDSJobDocument = new ReportDataSource("DsTrainingPlan", jobDocument.Tables[2]);
            //ReportParameter[] Param = new ReportParameter[2];
            //Param[0] = new ReportParameter("CompanyName", DB.GetCompanyName(), false);
            //Param[1] = new ReportParameter("CompanyAddress", DB.GetCompanyAddress(), false);
            //this.reportViewer1.LocalReport.SetParameters(Param);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(RDSJobDocument);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
