namespace Unit_Management.Person
{
    partial class frmFgAssignment
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
            this.txtAuth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArmyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbFgType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbAccidentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtAchivement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cmbFgType,
            this.cmbAccidentType,
            this.txtAchivement,
            this.txtReason,
            this.txtFromDate,
            this.txtToDate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1127, 434);
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
            // txtAuth
            // 
            this.txtAuth.DataPropertyName = "AUTHORITY";
            this.txtAuth.HeaderText = "Auth.";
            this.txtAuth.Name = "txtAuth";
            // 
            // txtArmyNo
            // 
            this.txtArmyNo.DataPropertyName = "ARMY_NO";
            this.txtArmyNo.HeaderText = "Army No";
            this.txtArmyNo.Name = "txtArmyNo";
            this.txtArmyNo.Visible = false;
            // 
            // cmbFgType
            // 
            this.cmbFgType.DataPropertyName = "FOREIGN_TYPE";
            this.cmbFgType.HeaderText = "Assignment Type";
            this.cmbFgType.Name = "cmbFgType";
            // 
            // cmbAccidentType
            // 
            this.cmbAccidentType.DataPropertyName = "ACCEDIENT_TYPE";
            this.cmbAccidentType.HeaderText = "Accident Type";
            this.cmbAccidentType.Name = "cmbAccidentType";
            // 
            // txtAchivement
            // 
            this.txtAchivement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtAchivement.DataPropertyName = "ACHIVEMENT";
            this.txtAchivement.HeaderText = "Achivement";
            this.txtAchivement.Name = "txtAchivement";
            this.txtAchivement.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtAchivement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtReason
            // 
            this.txtReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtReason.DataPropertyName = "REASON";
            this.txtReason.HeaderText = "Accident Reason";
            this.txtReason.Name = "txtReason";
            // 
            // txtFromDate
            // 
            this.txtFromDate.DataPropertyName = "FROM_DATE";
            dataGridViewCellStyle1.Format = "dd-MMM-y";
            this.txtFromDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtFromDate.HeaderText = "From Date";
            this.txtFromDate.Name = "txtFromDate";
            // 
            // txtToDate
            // 
            this.txtToDate.DataPropertyName = "TO_DATE";
            dataGridViewCellStyle2.Format = "dd-MMM-y";
            this.txtToDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtToDate.HeaderText = "To Date";
            this.txtToDate.Name = "txtToDate";
            // 
            // frmFgAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 434);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmFgAssignment";
            this.Text = "frmFgAssignment";
            this.Load += new System.EventHandler(this.frmFgAssignment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAuth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArmyNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbFgType;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbAccidentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAchivement;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtToDate;
    }
}