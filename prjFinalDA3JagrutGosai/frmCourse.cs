using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFinalDA3JagrutGosai
{
    public partial class frmCourse : Form
    {
        // form global variables
        DataSet mySet;
        DataTable tabTeachers,tabCourses,tabStudents;
        OleDbConnection myCon;
        DataRow myRow;
        OleDbDataAdapter myAdpCourse,myAdpTeachers,myAdpStudents;
        int currpos;
        string mode;
        public frmCourse()
        {
            InitializeComponent();
        }

        private void frmCourse_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\jagua\source\repos\420-DA3-AS\prjFinalDA3JagrutGosai\prjFinalDA3JagrutGosai\Database\DB_College.mdb");
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Teachers", myCon);
            myAdpTeachers = new OleDbDataAdapter(myCmd);
            myAdpTeachers.Fill(mySet, "Teachers");
            tabTeachers = mySet.Tables["Teachers"];
            cboTeacher.DisplayMember = "FullName";
            cboTeacher.ValueMember = "RefTeacher";
            cboTeacher.DataSource = tabTeachers;
            OleDbCommand myCmd2 = new OleDbCommand("SELECT * FROM Courses", myCon);
            myAdpCourse = new OleDbDataAdapter(myCmd2);
            myAdpCourse.Fill(mySet, "Courses");
            tabCourses = mySet.Tables["Courses"];
            currpos = 0;
            myRow = tabCourses.Rows[currpos];

            OleDbCommand myCmd3 = new OleDbCommand("SELECT * FROM Students", myCon);
            myAdpStudents = new OleDbDataAdapter(myCmd3);
            myAdpStudents.Fill(mySet, "Students");
            tabStudents = mySet.Tables["Students"];

            DisplayData();
            ActivateButtons(true, false, true);
            btnPrev.Enabled = false;
            DisplayGridView();
        }

        private void DisplayGridView()
        {
            

            var AllStuds = from DataRow myRows in tabStudents.Rows
                           where myRows.Field<int>("ReferCourse") == Convert.ToInt32(myRow["RefCourse"])
                           select myRows;

            if (AllStuds.Count() != 0)
            {
                gridView.DataSource = AllStuds.CopyToDataTable();

            }
            else
            {
                gridView.DataSource = null;
            }
        }

        private void DisplayData()
        {
            txtName.Text = myRow["Title"].ToString();
            txtNum.Text = myRow["Number"].ToString();
            txtDuration.Text = myRow["Duration"].ToString();
            cboTeacher.SelectedValue = Convert.ToInt32( myRow["ReferTeacher"]);
            lblLabel.Text = "Showing the course " + (currpos + 1) + " out of " + tabCourses.Rows.Count + " Courses.";
        }
        private void ActivateButtons(bool AdEdDel, bool SavCanc, bool Navig)
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = AdEdDel;
            btnSave.Enabled = btnCancel.Enabled = SavCanc;
            btnNext.Enabled = btnLast.Enabled = btnPrev.Enabled = btnLast.Enabled = Navig;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currpos = 0;
            myRow = tabCourses.Rows[currpos];
            DisplayData();
            DisplayGridView();
            btnNext.Enabled = true;
            btnPrev.Enabled = false;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currpos > 0)
            {
                currpos -= 1;
                btnPrev.Enabled = true;
                btnNext.Enabled = true;
            }
            else
            {
                btnPrev.Enabled = false;
                btnNext.Enabled = true;
            }

            myRow = tabCourses.Rows[currpos];
            DisplayData();
            DisplayGridView();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currpos < (tabCourses.Rows.Count - 1))
            {
                currpos += 1;
                btnNext.Enabled = true;
                btnPrev.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
                btnPrev.Enabled = true;
            }

            myRow = tabCourses.Rows[currpos];
            DisplayData();
            DisplayGridView();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currpos = tabCourses.Rows.Count - 1;
            myRow = tabCourses.Rows[currpos];
            DisplayData();
            DisplayGridView();
            btnPrev.Enabled = true;
            btnNext.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtDuration.Text = txtNum.Text = txtName.Text = "";
            txtNum.Focus();
            lblLabel.Text = "----Adding Mode----";
            ActivateButtons(false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtName.Focus();
            lblLabel.Text = "----Editing mode----";
            ActivateButtons(false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure to delete this Course?";
            string title = "Warning : Course deletion";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                tabCourses.Rows[currpos].Delete();
                RefreshData();
                currpos = 0;
                DisplayData();
                DisplayGridView();


            }
        }
        public void RefreshData()
        {
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdpCourse);
            // Now we need to update to the database or synchronise to the database
            myAdpCourse.Update(mySet, "Courses");
            // Update the contents of the dataset with fresh contents from database
            mySet.Tables.Remove("Courses");
            myAdpCourse.Fill(mySet, "Courses");
            tabCourses = mySet.Tables["Courses"];
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string num = txtNum.Text.Trim();
            int duration = Convert.ToInt32(txtDuration.Text.Trim());
            int reftc = Convert.ToInt32(cboTeacher.SelectedValue);




            if (mode == "add")
            {
                myRow = tabCourses.NewRow();
                myRow["Title"] = name;
                myRow["Number"] = num;
                myRow["Duration"] = duration;
                myRow["ReferTeacher"] = reftc;

                tabCourses.Rows.Add(myRow);


                currpos = tabCourses.Rows.Count - 1;

            }
            else if (mode == "edit")
            {
                myRow = tabCourses.Rows[currpos];
                myRow["Title"] = name;
                myRow["Number"] = num;
                myRow["Duration"] = duration;
                myRow["ReferTeacher"] = reftc;

            }
            RefreshData();
            DisplayData();
            DisplayGridView();

            ActivateButtons(true, false, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ActivateButtons(true, false, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnNewTeacher_Click(object sender, EventArgs e)
        {
            frmTeacher tc = new frmTeacher();
            tc.MdiParent = frmMain.fm;
            tc.Show();
        }
    }
}
