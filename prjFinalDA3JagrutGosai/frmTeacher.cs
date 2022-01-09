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
    public partial class frmTeacher : Form
    {
        // form global variables
        DataSet mySet;
        DataTable tabTeachers;
        OleDbConnection myCon;
        DataRow myRow;
        OleDbDataAdapter myAdapter;
        int currpos;
        string mode;
        public frmTeacher()
        {
            InitializeComponent();
        }
        private void DisplayData()
        {
            txtName.Text = myRow["FullName"].ToString();
            txtEmail.Text = myRow["Email"].ToString();
            txtSalary.Text = myRow["Salary"].ToString();
          
            lblLabel.Text = "Showing the teacher " + (currpos + 1) + " out of " + tabTeachers.Rows.Count + " Teachers.";
        }
        private void ActivateButtons(bool AdEdDel, bool SavCanc, bool Navig)
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = AdEdDel;
            btnSave.Enabled = btnCancel.Enabled = SavCanc;
            btnNext.Enabled = btnLast.Enabled = btnPrev.Enabled = btnLast.Enabled = Navig;
        }
        private void frmTeacher_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\jagua\source\repos\420-DA3-AS\prjFinalDA3JagrutGosai\prjFinalDA3JagrutGosai\Database\DB_College.mdb");
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Teachers", myCon);
            myAdapter = new OleDbDataAdapter(myCmd);
            myAdapter.Fill(mySet, "Teachers");
            tabTeachers = mySet.Tables["Teachers"];
            currpos = 0;
            myRow = tabTeachers.Rows[currpos];
            DisplayData();
            ActivateButtons(true, false, true);
            btnPrev.Enabled = false;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currpos = 0;
            myRow = tabTeachers.Rows[currpos];
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

            myRow = tabTeachers.Rows[currpos];
            DisplayData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currpos < (tabTeachers.Rows.Count - 1))
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

            myRow = tabTeachers.Rows[currpos];
            DisplayData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currpos = tabTeachers.Rows.Count - 1;
            myRow = tabTeachers.Rows[currpos];
            DisplayData();
            btnPrev.Enabled = true;
            btnNext.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtSalary.Text = txtEmail.Text = txtName.Text =  "";
            txtName.Focus();
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
            string msg = "Are you sure to delete this teacher?";
            string title = "Warning : Teacher deletion";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                tabTeachers.Rows[currpos].Delete();
                RefreshData();
                currpos = 0;
                DisplayData();


            }
        }
        public void RefreshData()
        {
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdapter);
            // Now we need to update to the database or synchronise to the database
            myAdapter.Update(mySet, "Teachers");
            // Update the contents of the dataset with fresh contents from database
            mySet.Tables.Remove("Teachers");
            myAdapter.Fill(mySet, "Teachers");
            tabTeachers = mySet.Tables["Teachers"];
        }

            private void btnSave_Click(object sender, EventArgs e)
        {

            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            Double salary = Convert.ToDouble( txtSalary.Text.Trim());
           



            if (mode == "add")
            {
                myRow = tabTeachers.NewRow();
                myRow["FullName"] = name;
                myRow["Email"] = email;
                myRow["Salary"] = salary;
               
                tabTeachers.Rows.Add(myRow);
                

                currpos = tabTeachers.Rows.Count - 1;

            }
            else if (mode == "edit")
            {
                myRow = tabTeachers.Rows[currpos];
                myRow["FullName"] = name;
                myRow["Email"] = email;
                myRow["Salary"] = salary;

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
