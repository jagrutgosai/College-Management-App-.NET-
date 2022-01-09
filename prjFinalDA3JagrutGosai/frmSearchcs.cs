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
    public partial class frmSearchcs : Form
    {
        // form global variables
        DataSet mySet;
        DataTable tabCourses, tabStudents;
        OleDbConnection myCon;
       
        OleDbDataAdapter myAdpCourse,  myAdpStudents;

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(checkCourse.Checked && !checkGender.Checked)
            {
                var AllStuds = from DataRow myRows in tabStudents.Rows
                               where myRows.Field<int>("ReferCourse") == Convert.ToInt32(cboCourses.SelectedValue)
                               select new { Names = myRows.Field<String>("FullName"), Birthdates = myRows.Field<DateTime>("BirthDate"), Genders = myRows.Field<String>("Gender"), Averages = myRows.Field<int>("Average") };

                if (AllStuds.Count() != 0)
                {
                    gridView.DataSource = AllStuds.ToList();

                }
                else
                {
                    gridView.DataSource = null;
                }
            }
            else if (!checkCourse.Checked && checkGender.Checked)
            {
                var AllStuds = from DataRow myRows in tabStudents.Rows
                               where myRows.Field<string>("Gender") == cboGender.Text
                               select new { Names = myRows.Field<String>("FullName"), Birthdates = myRows.Field<DateTime>("BirthDate"), Genders = myRows.Field<String>("Gender"), Averages = myRows.Field<int>("Average") };

                if (AllStuds.Count() != 0)
                {
                    gridView.DataSource = AllStuds.ToList();

                }
                else
                {
                    gridView.DataSource = null;
                }
            }
            else
            {
                var AllStuds = from DataRow myRows in tabStudents.Rows
                               select new { Names = myRows.Field<String>("FullName"), Birthdates = myRows.Field<DateTime>("BirthDate"), Genders = myRows.Field<String>("Gender"), Averages = myRows.Field<int>("Average") };
                gridView.DataSource = AllStuds.ToList();
            }
        }

        public frmSearchcs()
        {
            InitializeComponent();
        }

        private void frmSearchcs_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\jagua\source\repos\420-DA3-AS\prjFinalDA3JagrutGosai\prjFinalDA3JagrutGosai\Database\DB_College.mdb");
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Students", myCon);
            myAdpStudents = new OleDbDataAdapter(myCmd);
            myAdpStudents.Fill(mySet, "Students");
            tabStudents = mySet.Tables["Students"];


            var allGenders = from DataRow myRows in tabStudents.Rows
                             select myRows.Field<string>("Gender");
            cboGender.DataSource = allGenders.Distinct().ToList();

            OleDbCommand myCmd2 = new OleDbCommand("SELECT * FROM Courses", myCon);
            myAdpCourse = new OleDbDataAdapter(myCmd2);
            myAdpCourse.Fill(mySet, "Courses");
            tabCourses = mySet.Tables["Courses"];
            cboCourses.DisplayMember = "Title";
            cboCourses.ValueMember = "RefCourse";
            cboCourses.DataSource = tabCourses;

           // gridView.DataSource = tabStudents;
        }
    }
}
