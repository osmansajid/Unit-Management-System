namespace Unit_Management.Person
{
    partial class frmTrgPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArmyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCycle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbCourse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtFromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCode,
            this.txtArmyNo,
            this.cmbCycle,
            this.cmbCourse,
            this.txtFromDate,
            this.txtToDate,
            this.txtRemarks});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(948, 423);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // txtCode
            // 
            this.txtCode.DataPropertyName = "CODE";
            this.txtCode.HeaderText = "Code";
            this.txtCode.Name = "txtCode";
            this.txtCode.Visible = false;
            // 
            // txtArmyNo
            // 
            this.txtArmyNo.DataPropertyName = "TRAIN_ARMY_NO";
            this.txtArmyNo.HeaderText = "Army No";
            this.txtArmyNo.Name = "txtArmyNo";
            this.txtArmyNo.Visible = false;
            // 
            // cmbCycle
            // 
            this.cmbCycle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbCycle.DataPropertyName = "TRAIN_CYCLE";
            this.cmbCycle.HeaderText = "Cycle";
            this.cmbCycle.Name = "cmbCycle";
            // 
            // cmbCourse
            // 
            this.cmbCourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbCourse.DataPropertyName = "TRAIN_COURSE";
            this.cmbCourse.HeaderText = "Course";
            this.cmbCourse.Name = "cmbCourse";
            // 
            // txtFromDate
            // 
            this.txtFromDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtFromDate.DataPropertyName = "FROM_DATE";
            dataGridViewCellStyle1.Format = "dd-MMM-y";
            this.txtFromDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtFromDate.HeaderText = "From Date";
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtFromDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtToDate
            // 
            this.txtToDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtToDate.DataPropertyName = "TO_DATE";
            dataGridViewCellStyle2.Format = "dd-MMM-y";
            this.txtToDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtToDate.HeaderText = "To Date";
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtToDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtRemarks
            // 
            this.txtRemarks.DataPropertyName = "REMARKS";
            this.txtRemarks.HeaderText = "Remarks";
            this.txtRemarks.Name = "txtRemarks";
            // 
            // frmTrgPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 423);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmTrgPlan";
            this.Text = "frmTrgPlan";
            this.Load += new System.EventHandler(this.frmTrgPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArmyNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbCycle;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtToDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRemarks;
    }
}