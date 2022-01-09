
namespace prjFinalDA3JagrutGosai
{
    partial class frmSearchcs
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkGender = new System.Windows.Forms.CheckBox();
            this.checkCourse = new System.Windows.Forms.CheckBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.cboCourses = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 29);
            this.label1.TabIndex = 40;
            this.label1.Text = "SEARCH FOR STUDENTS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.cboCourses);
            this.groupBox1.Controls.Add(this.cboGender);
            this.groupBox1.Controls.Add(this.checkCourse);
            this.groupBox1.Controls.Add(this.checkGender);
            this.groupBox1.Location = new System.Drawing.Point(37, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 131);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterias";
            // 
            // checkGender
            // 
            this.checkGender.AutoSize = true;
            this.checkGender.Location = new System.Drawing.Point(23, 36);
            this.checkGender.Name = "checkGender";
            this.checkGender.Size = new System.Drawing.Size(111, 24);
            this.checkGender.TabIndex = 0;
            this.checkGender.Text = "By Gender";
            this.checkGender.UseVisualStyleBackColor = true;
            // 
            // checkCourse
            // 
            this.checkCourse.AutoSize = true;
            this.checkCourse.Location = new System.Drawing.Point(23, 78);
            this.checkCourse.Name = "checkCourse";
            this.checkCourse.Size = new System.Drawing.Size(108, 24);
            this.checkCourse.TabIndex = 1;
            this.checkCourse.Text = "By Course";
            this.checkCourse.UseVisualStyleBackColor = true;
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(141, 36);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(358, 28);
            this.cboGender.TabIndex = 2;
            // 
            // cboCourses
            // 
            this.cboCourses.FormattingEnabled = true;
            this.cboCourses.Location = new System.Drawing.Point(141, 76);
            this.cboCourses.Name = "cboCourses";
            this.cboCourses.Size = new System.Drawing.Size(358, 28);
            this.cboCourses.TabIndex = 3;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(587, 36);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(120, 68);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // gridView
            // 
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Location = new System.Drawing.Point(37, 205);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersWidth = 62;
            this.gridView.RowTemplate.Height = 28;
            this.gridView.Size = new System.Drawing.Size(722, 233);
            this.gridView.TabIndex = 42;
            // 
            // frmSearchcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmSearchcs";
            this.Text = "frmSearchcs";
            this.Load += new System.EventHandler(this.frmSearchcs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cboCourses;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.CheckBox checkCourse;
        private System.Windows.Forms.CheckBox checkGender;
        private System.Windows.Forms.DataGridView gridView;
    }
}