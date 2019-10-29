using Microsoft.Reporting.WinForms;
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
namespace Unit_Management.Reports
{
    public partial class frmJobDocument : Form
    {

        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        string ARMY_CODE = "21";
        public frmJobDocument()
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
        private void frmJobDocument_Load(object sender, EventArgs e)
        {
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            
            this.reportViewer1.ZoomMode = ZoomMode.Percent;

            this.reportViewer1.ZoomPercent = 150;
            loadReport();
        }

        private void loadReport()
        {

            DataSets.DsJobDocument jobDocument = new DataSets.DsJobDocument();
            OracleDataAdapter DA_JobDocument = DB.selectAdapter("VW_ARMY_MASTER_INFO", "*", "CODE='" + ARMY_CODE + "'");
            DA_JobDocument.Fill(jobDocument, jobDocument.Tables[0].TableName);

            ReportDataSource RDSJobDocument = new ReportDataSource("DsJobDocument", jobDocument.Tables[0]);
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
