namespace Unit_Management.Person
{
    partial class frmAppt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAuthority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArmyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbAppt = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.txtAuthority,
            this.txtArmyCode,
            this.cmbAppt,
            this.txtFromDate,
            this.txtToDate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 388);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            // 
            // txtCode
            // 
            this.txtCode.DataPropertyName = "CODE";
            this.txtCode.HeaderText = "Code";
            this.txtCode.Name = "txtCode";
            this.txtCode.Visible = false;
            // 
            // txtAuthority
            // 
            this.txtAuthority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtAuthority.DataPropertyName = "AUTHORITY";
            this.txtAuthority.HeaderText = "Authority";
            this.txtAuthority.Name = "txtAuthority";
            // 
            // txtArmyCode
            // 
            this.txtArmyCode.DataPropertyName = "ARMY_NO";
            this.txtArmyCode.HeaderText = "ArmyCode";
            this.txtArmyCode.Name = "txtArmyCode";
            this.txtArmyCode.Visible = false;
            // 
            // cmbAppt
            // 
            this.cmbAppt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbAppt.DataPropertyName = "APPT_NO";
            this.cmbAppt.HeaderText = "Appoinment";
            this.cmbAppt.Name = "cmbAppt";
            // 
            // txtFromDate
            // 
            this.txtFromDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtFromDate.DataPropertyName = "FROM_DATE";
            dataGridViewCellStyle5.Format = "dd-MMM-y";
            dataGridViewCellStyle5.NullValue = null;
            this.txtFromDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtFromDate.HeaderText = "From";
            this.txtFromDate.Name = "txtFromDate";
            // 
            // txtToDate
            // 
            this.txtToDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtToDate.DataPropertyName = "TO_DATE";
            dataGridViewCellStyle6.Format = "dd-MMM-y";
            this.txtToDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtToDate.HeaderText = "To";
            this.txtToDate.Name = "txtToDate";
            // 
            // frmAppt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 388);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appoinment Manager";
            this.Load += new System.EventHandler(this.frmAppt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAuthority;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArmyCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbAppt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtToDate;
    }
}