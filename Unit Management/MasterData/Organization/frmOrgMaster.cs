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

namespace Unit_Management.MasterData.Organization
{
    public partial class frmOrgMaster : Form
    {
        private string[] userInfo = new string[5];
        DataOperations DB = new DataOperations();
        string SeelctedNodeCode = null;
        public frmOrgMaster()
        {
            InitializeComponent();
        }
        internal void setUserInfo(string[] userInfo)
        {
            this.userInfo = userInfo;
        }
        private void BindTreeview()
        {
            tvLocation.Nodes.Clear();
           DataTable parentRow = DB.query("SELECT * FROM ORG_MASTER WHERE PARENT IS NULL"); // # Get all root nodes

           foreach (DataRow row in parentRow.Rows) // # Add all root nodes to treeview and call for child nodes
            {
                TreeNode node = new TreeNode();
                node.Text = row["NAME"].ToString();
                node.Tag = row["CODE"].ToString();

                tvLocation.Nodes.Add(node);
                AddChildNodes(row["CODE"].ToString(), node);
            }
        }
        private void AddChildNodes(string code, TreeNode node) // # Recursive method to add child nodes and call for child nodes of each child node
        {
            DataTable childRows = DB.query("SELECT * FROM ORG_MASTER WHERE PARENT ="+code); // # Get all child nodes of given node

            if (childRows.Rows.Count == 0) { return; } // # Recursion base case; if given node has no child nodes no more action is taken

            foreach (DataRow row in childRows.Rows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Text = row["NAME"].ToString();
                childNode.Tag = row["CODE"].ToString();
                node.Nodes.Add(childNode);
                AddChildNodes(row["CODE"].ToString(), childNode);
            }
        }

        private void frmOrgMaster_Load(object sender, EventArgs e)
        {
            BindTreeview();
            LoadBloodGroup();
        }

        private void tvLocation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            gbOrganization.Enabled = true;
            txtParentCode.Text = e.Node.Tag.ToString();
            txtLevel.Text = (Convert.ToInt32(e.Node.Level)+2).ToString();
            SeelctedNodeCode = e.Node.Tag.ToString();
            LoadChildRecordToListView(e.Node.Tag.ToString());
            
        }
        private void LoadChildRecordToListView(string CODE)
        {

            DataTable DT = DB.select("ORG_MASTER", "CODE,NAME,PARENT,DECODE(TYPE,0,'Root',1,'DIV',2,'BDE',3,'UNIT',4,'COY') TYPE", "PARENT=" + CODE, "TYPE,NAME ASC");

            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (DataRow row in DT.Rows)
            {

                ListViewItem listitem = new ListViewItem(row["CODE"].ToString());
                listitem.SubItems.Add(row["NAME"].ToString());
                listitem.SubItems.Add(row["TYPE"].ToString());
               
                listView1.Items.Add(listitem);


            }
            listView1.EndUpdate();
            listView1.Refresh();
            
        }

        private void Save()
        {

            Dictionary<string, string> ORG_MASTER_DATA = new Dictionary<string, string>();
          
            ORG_MASTER_DATA.Add("NAME", DB.validateTextBox(txtName));
            ORG_MASTER_DATA.Add("LEV", DB.validateTextBox(txtLevel));
            ORG_MASTER_DATA.Add("TYPE", DB.validateComBox(cmbOrgType));
            ORG_MASTER_DATA.Add("PARENT", DB.validateTextBox(txtParentCode));

            if (btnSave.Text == "Save")
            {
                MessageBox.Show(DB.insert("ORG_MASTER",ORG_MASTER_DATA));
            }

            BindTreeview();
            txtLevel.Clear();
            txtParentCode.Clear();
            txtName.Clear();
            cmbOrgType.SelectedIndex = -1;
            gbOrganization.Enabled = false;
        }
        private void LoadBloodGroup()
        {
            DataTable DT_TYPE = new DataTable();
            // create fields

            DT_TYPE.Columns.Add("CODE", typeof(int));
            DT_TYPE.Columns.Add("NAME", typeof(string));


            // insert row values
           // DT_TYPE.Rows.Add(new Object[]{
               
           //     1,"DIV"
           
           //});
           // DT_TYPE.Rows.Add(new Object[]{
               
           //     2,"BDE"
           
           //});
            DT_TYPE.Rows.Add(new Object[]{
               
                3,"UNIT"
           
           });
            DT_TYPE.Rows.Add(new Object[]{
               
                4,"COY"
           
           });

            cmbOrgType.DisplayMember = "NAME";
            cmbOrgType.ValueMember = "CODE";
            cmbOrgType.DataSource = DT_TYPE;
            cmbOrgType.SelectedValue = -1;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
          
        }

        private void btnDeleteTree_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DB.deleteData("ORG_MASTER", "CODE=" + SeelctedNodeCode));
            BindTreeview();
        }
    }
}
