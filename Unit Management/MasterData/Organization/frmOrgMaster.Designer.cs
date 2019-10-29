namespace Unit_Management.MasterData.Organization
{
    partial class frmOrgMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbOrganization = new System.Windows.Forms.GroupBox();
            this.cmbOrgType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbTree = new System.Windows.Forms.GroupBox();
            this.tvLocation = new System.Windows.Forms.TreeView();
            this.btnDeleteTree = new System.Windows.Forms.Button();
            this.gbOrganization.SuspendLayout();
            this.gbTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOrganization
            // 
            this.gbOrganization.Controls.Add(this.cmbOrgType);
            this.gbOrganization.Controls.Add(this.label3);
            this.gbOrganization.Controls.Add(this.txtLevel);
            this.gbOrganization.Controls.Add(this.label8);
            this.gbOrganization.Controls.Add(this.txtParentCode);
            this.gbOrganization.Controls.Add(this.label2);
            this.gbOrganization.Controls.Add(this.btnSave);
            this.gbOrganization.Controls.Add(this.btnCancle);
            this.gbOrganization.Controls.Add(this.btnDelete);
            this.gbOrganization.Controls.Add(this.txtName);
            this.gbOrganization.Controls.Add(this.label1);
            this.gbOrganization.Controls.Add(this.listView1);
            this.gbOrganization.Enabled = false;
            this.gbOrganization.Location = new System.Drawing.Point(254, 12);
            this.gbOrganization.Name = "gbOrganization";
            this.gbOrganization.Size = new System.Drawing.Size(383, 410);
            this.gbOrganization.TabIndex = 2;
            this.gbOrganization.TabStop = false;
            this.gbOrganization.Text = "Organization";
            // 
            // cmbOrgType
            // 
            this.cmbOrgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrgType.FormattingEnabled = true;
            this.cmbOrgType.Location = new System.Drawing.Point(6, 40);
            this.cmbOrgType.Name = "cmbOrgType";
            this.cmbOrgType.Size = new System.Drawing.Size(223, 21);
            this.cmbOrgType.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Organization Type";
            // 
            // txtLevel
            // 
            this.txtLevel.Enabled = false;
            this.txtLevel.Location = new System.Drawing.Point(312, 41);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(65, 20);
            this.txtLevel.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Level";
            // 
            // txtParentCode
            // 
            this.txtParentCode.Enabled = false;
            this.txtParentCode.Location = new System.Drawing.Point(235, 41);
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.ReadOnly = true;
            this.txtParentCode.Size = new System.Drawing.Size(71, 20);
            this.txtParentCode.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parent";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(302, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(87, 110);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 6;
            this.btnCancle.Text = "Cancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 110);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 82);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(371, 20);
            this.txtName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colName,
            this.colType});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 138);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(371, 266);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 180;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 80;
            // 
            // gbTree
            // 
            this.gbTree.Controls.Add(this.btnDeleteTree);
            this.gbTree.Controls.Add(this.tvLocation);
            this.gbTree.Location = new System.Drawing.Point(12, 12);
            this.gbTree.Name = "gbTree";
            this.gbTree.Size = new System.Drawing.Size(236, 410);
            this.gbTree.TabIndex = 3;
            this.gbTree.TabStop = false;
            this.gbTree.Text = "Organization Tree";
            // 
            // tvLocation
            // 
            this.tvLocation.Location = new System.Drawing.Point(3, 19);
            this.tvLocation.Name = "tvLocation";
            this.tvLocation.Size = new System.Drawing.Size(230, 356);
            this.tvLocation.TabIndex = 1;
            this.tvLocation.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLocation_AfterSelect);
            // 
            // btnDeleteTree
            // 
            this.btnDeleteTree.Location = new System.Drawing.Point(3, 380);
            this.btnDeleteTree.Name = "btnDeleteTree";
            this.btnDeleteTree.Size = new System.Drawing.Size(230, 23);
            this.btnDeleteTree.TabIndex = 14;
            this.btnDeleteTree.Text = "Delete";
            this.btnDeleteTree.UseVisualStyleBackColor = true;
            this.btnDeleteTree.Click += new System.EventHandler(this.btnDeleteTree_Click);
            // 
            // frmOrgMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 427);
            this.Controls.Add(this.gbTree);
            this.Controls.Add(this.gbOrganization);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrgMaster";
            this.Text = "frmOrgMaster";
            this.Load += new System.EventHandler(this.frmOrgMaster_Load);
            this.gbOrganization.ResumeLayout(false);
            this.gbOrganization.PerformLayout();
            this.gbTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrganization;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.GroupBox gbTree;
        private System.Windows.Forms.TreeView tvLocation;
        private System.Windows.Forms.TextBox txtParentCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOrgType;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.Button btnDeleteTree;
    }
}