namespace Unit_Management.Person
{
    partial class frmLeave
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAuth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArmyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbLeaveType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbFormD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLeaveAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbNearBase = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCode,
            this.txtAuth,
            this.txtArmyNo,
            this.cmbLeaveType,
            this.cmbFormD,
            this.txtFromDate,
            this.txtToDate,
            this.txtLeaveAddress,
            this.cmbNearBase,
            this.txtDescription});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1071, 369);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // txtCode
            // 
            this.txtCode.DataPropertyName = "CODE";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.txtCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtCode.HeaderText = "Code";
            this.txtCode.Name = "txtCode";
            this.txtCode.Visible = false;
            // 
            // txtAuth
            // 
            this.txtAuth.DataPropertyName = "LV_AUTHORITY";
            this.txtAuth.HeaderText = "Authority";
            this.txtAuth.Name = "txtAuth";
            // 
            // txtArmyNo
            // 
            this.txtArmyNo.DataPropertyName = "LV_ARMY_NO";
            this.txtArmyNo.HeaderText = "Army No";
            this.txtArmyNo.Name = "txtArmyNo";
            this.txtArmyNo.Visible = false;
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.DataPropertyName = "LV_TYPE";
            this.cmbLeaveType.HeaderText = "Leave Type";
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbLeaveType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cmbFormD
            // 
            this.cmbFormD.DataPropertyName = "FORM_D";
            this.cmbFormD.HeaderText = "Form D";
            this.cmbFormD.Name = "cmbFormD";
            this.cmbFormD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbFormD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtFromDate
            // 
            this.txtFromDate.DataPropertyName = "FROM_DATE";
            this.txtFromDate.HeaderText = "From Date";
            this.txtFromDate.Name = "txtFromDate";
            // 
            // txtToDate
            // 
            this.txtToDate.DataPropertyName = "TO_DATE";
            this.txtToDate.HeaderText = "To Date";
            this.txtToDate.Name = "txtToDate";
            // 
            // txtLeaveAddress
            // 
            this.txtLeaveAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtLeaveAddress.DataPropertyName = "LEAVE_ADDRESS";
            this.txtLeaveAddress.HeaderText = "Leave Address";
            this.txtLeaveAddress.Name = "txtLeaveAddress";
            // 
            // cmbNearBase
            // 
            this.cmbNearBase.DataPropertyName = "NEAR_CANTONMENT";
            this.cmbNearBase.HeaderText = "Near Cantonment";
            this.cmbNearBase.Name = "cmbNearBase";
            // 
            // txtDescription
            // 
            this.txtDescription.DataPropertyName = "DESCRIPTION";
            this.txtDescription.HeaderText = "Description";
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 369);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmLeave";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "frmLeave";
            this.Load += new System.EventHandler(this.frmLeave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAuth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArmyNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbLeaveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmbFormD;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtToDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLeaveAddress;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbNearBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDescription;
    }
}