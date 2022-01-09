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
    public partial class frmStudent : Form
    {
        // form global variables
        DataSet mySet;
        DataTable  tabCourses, tabStudents;
        OleDbConnection myCon;
        DataRow myRow;
        OleDbDataAdapter myAdpCourse,  myAdpStudents;
        int currpos;
        string mode;
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\jagua\source\repos\420-DA3-AS\prjFinalDA3JagrutGosai\prjFinalDA3JagrutGosai\Database\DB_College.mdb");
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Students", myCon);
            myAdpStudents = new OleDbDataAdapter(myCmd);
            myAdpStudents.Fill(mySet, "Students");
            tabStudents = mySet.Tables["Students"];
            OleDbCommand myCmd2 = new OleDbCommand("SELECT * FROM Courses", myCon);
            myAdpCourse = new OleDbDataAdapter(myCmd2);
            myAdpCourse.Fill(mySet, "Courses");
            tabCourses = mySet.Tables["Courses"];
            currpos = 0;
            myRow = tabStudents.Rows[currpos];
            cmoCourses.DisplayMember = "Title";
            cmoCourses.ValueMember = "RefCourse";
            cmoCourses.DataSource = tabCourses;
            DisplayData();
            ActivateButtons(true, false, true);
            btnPrev.Enabled = false;
        }
        private void DisplayData()
        {
            txtName.Text = myRow["FullName"].ToString();
            txtGender.Text = myRow["Gender"].ToString();
            txtAvg.Text = myRow["Average"].ToString();
            dtpBdate.Value = Convert.ToDateTime( myRow["Birthdate"]);
            cmoCourses.SelectedValue = Convert.ToInt32(myRow["ReferCourse"]);
            lblLabel.Text = "Showing the student " + (currpos + 1) + " out of " + tabStudents.Rows.Count + " Students.";
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
            myRow = tabStudents.Rows[currpos];
            DisplayData();
            
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

            myRow = tabStudents.Rows[currpos];
            DisplayData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currpos < (tabStudents.Rows.Count - 1))
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

            myRow = tabStudents.Rows[currpos];
            DisplayData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currpos = tabStudents.Rows.Count - 1;
            myRow = tabStudents.Rows[currpos];
            DisplayData();
            
            btnPrev.Enabled = true;
            btnNext.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtGender.Text = txtName.Text = "";
            txtName.Focus();
            cmoCourses.SelectedItem = null;
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
            string msg = "Are you sure to delete this Student?";
            string title = "Warning : Student deletion";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                tabStudents.Rows[currpos].Delete();
                RefreshData();
                currpos = 0;
                DisplayData();
               


            }
        }
        public void RefreshData()
        {
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdpStudents);
            // Now we need to update to the database or synchronise to the database
            myAdpStudents.Update(mySet, "Students");
            // Update the contents of the dataset with fresh contents from database
            mySet.Tables.Remove("Students");
            myAdpStudents.Fill(mySet, "Students");
            tabStudents = mySet.Tables["Students"];
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string gender = txtGender.Text.Trim();
            DateTime bdate = dtpBdate.Value;
            int refc = Convert.ToInt32( cmoCourses.SelectedValue);
            int avg = Convert.ToInt32(txtAvg.Text.Trim());




            if (mode == "add")
            {
                myRow = tabStudents.NewRow();
                myRow["FullName"] = name;
                myRow["Birthdate"] = bdate;
                myRow["Gender"] = gender;
                myRow["ReferCourse"] = refc;
                myRow["Average"] = avg;

                tabStudents.Rows.Add(myRow);


                currpos = tabStudents.Rows.Count - 1;

            }
            else if (mode == "edit")
            {
                myRow = tabStudents.Rows[currpos];
                myRow["FullName"] = name;
                myRow["Birthdate"] = bdate;
                myRow["Gender"] = gender;
                myRow["ReferCourse"] = refc;
                myRow["Average"] = avg;
            }
            RefreshData();
            DisplayData();
           

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
    }
}
