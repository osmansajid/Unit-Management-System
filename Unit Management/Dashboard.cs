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

namespace Unit_Management
{
    public partial class Dashboard : Form
    {
        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        
        public Dashboard()
        {
            InitializeComponent();
        }
        internal void setUserInfo(string[] userInfo)
        {
            this.userInfo = userInfo;
        }
        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterData.frmOrgStracture frmOrgStracture = new MasterData.frmOrgStracture();
            frmOrgStracture.setUserInfo(userInfo);
            frmOrgStracture.ShowDialog();
        }

        private void addNewSoldierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person.frmArmyMasterInfo frmArmyMasterInfo = new Person.frmArmyMasterInfo();
            frmArmyMasterInfo.setUserInfo(userInfo);
            frmArmyMasterInfo.ShowDialog();
        }

        private void manageSoldierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person.frmArmyMasterInfoManage frmArmyMasterInfoManage = new Person.frmArmyMasterInfoManage();
            frmArmyMasterInfoManage.setUserInfo(userInfo);
            frmArmyMasterInfoManage.ShowDialog();
        }

        private void dIVBDEUNITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterData.Organization.frmOrgMaster frmOrgMaster = new MasterData.Organization.frmOrgMaster();
            frmOrgMaster.setUserInfo(userInfo);
            frmOrgMaster.ShowDialog();
        }

        private void mdicaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterData.frmMedicalType frmMedicalType = new MasterData.frmMedicalType();
            frmMedicalType.setUserInfo(userInfo);
            frmMedicalType.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reports.frmJobDocument frmJobDocument = new Reports.frmJobDocument();
            frmJobDocument.setUserInfo(userInfo);
            frmJobDocument.setArmyCode("21");
            frmJobDocument.ShowDialog();
        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Admin.frmManageUser frmManageUser = new Admin.frmManageUser();
            frmManageUser.setUserInfo(userInfo);
         
            frmManageUser.ShowDialog();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (userInfo[1] == "1")
            {
                menuAdmin.Enabled = true;
            }
        }

        private void trainingPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmTrainingCycle frmTrainingCycle = new Reports.frmTrainingCycle();
            frmTrainingCycle.setUserInfo(userInfo);

            frmTrainingCycle.ShowDialog();
        }
    }
}
