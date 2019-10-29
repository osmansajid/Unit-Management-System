namespace Unit_Management.Person
{
    partial class frmEducation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAuth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArmyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCourse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtCCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARMY_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbUniversity = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtExam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPassYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRollNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1138, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Army Course";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCode,
            this.txtAuth,
            this.txtArmyNo,
            this.txtInst,
            this.cmbCourse,
            this.txtGrade,
            this.txtDesc});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1132, 212);
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
            this.txtAuth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            // txtInst
            // 
            this.txtInst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtInst.DataPropertyName = "INSTITUTION";
            this.txtInst.HeaderText = "Institution";
            this.txtInst.Name = "txtInst";
            // 
            // cmbCourse
            // 
            this.cmbCourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbCourse.DataPropertyName = "COURSE_CODE";
            this.cmbCourse.HeaderText = "Course";
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbCourse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtGrade
            // 
            this.txtGrade.DataPropertyName = "GRADING";
            this.txtGrade.HeaderText = "Grade";
            this.txtGrade.Name = "txtGrade";
            // 
            // txtDesc
            // 
            this.txtDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtDesc.DataPropertyName = "DESCRIPTION";
            this.txtDesc.HeaderText = "Description";
            this.txtDesc.Name = "txtDesc";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(12, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1138, 231);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Civil Education";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCCode,
            this.ARMY_ID,
            this.cmbUniversity,
            this.txtExam,
            this.txtResult,
            this.txtLevel,
            this.txtPassYear,
            this.txtRollNo,
            this.txtDescription});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1132, 212);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellValueChanged);
            // 
            // txtCCode
            // 
            this.txtCCode.DataPropertyName = "CODE";
            this.txtCCode.HeaderText = "Code";
            this.txtCCode.Name = "txtCCode";
            this.txtCCode.Visible = false;
            // 
            // ARMY_ID
            // 
            this.ARMY_ID.HeaderText = "Army No";
            this.ARMY_ID.Name = "ARMY_ID";
            this.ARMY_ID.Visible = false;
            // 
            // cmbUniversity
            // 
            this.cmbUniversity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbUniversity.DataPropertyName = "UNI_BOARD";
            this.cmbUniversity.HeaderText = "University";
            this.cmbUniversity.Name = "cmbUniversity";
            // 
            // txtExam
            // 
            this.txtExam.DataPropertyName = "EXAM";
            this.txtExam.HeaderText = "Exam";
            this.txtExam.Name = "txtExam";
            this.txtExam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtExam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtResult
            // 
            this.txtResult.DataPropertyName = "RESULT";
            this.txtResult.HeaderText = "Result";
            this.txtResult.Name = "txtResult";
            this.txtResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtLevel
            // 
            this.txtLevel.DataPropertyName = "LEVEL_";
            this.txtLevel.HeaderText = "Level";
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txtLevel.Visible = false;
            // 
            // txtPassYear
            // 
            this.txtPassYear.DataPropertyName = "PASS_YEAR";
            this.txtPassYear.HeaderText = "Pass Year";
            this.txtPassYear.Name = "txtPassYear";
            // 
            // txtRollNo
            // 
            this.txtRollNo.DataPropertyName = "ROLL_NO";
            this.txtRollNo.HeaderText = "Roll No";
            this.txtRollNo.Name = "txtRollNo";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtDescription.DataPropertyName = "DESCRIPTION";
            this.txtDescription.HeaderText = "Description";
            this.txtDescription.Name = "txtDescription";
            // 
            // frmEducation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEducation";
            this.Text = "frmEducation";
            this.Load += new System.EventHandler(this.frmEducation_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAuth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArmyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInst;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARMY_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbUniversity;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtExam;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPassYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRollNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDescription;
    }
}