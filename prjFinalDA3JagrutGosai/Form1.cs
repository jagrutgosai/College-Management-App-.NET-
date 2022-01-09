using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFinalDA3JagrutGosai
{
    public partial class frmMain : Form
    {
        public static frmMain fm;
        public frmMain()
        {
            InitializeComponent();
            fm = this;
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent st = new frmStudent();
            st.MdiParent = this;
            st.Show();
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourse crs = new frmCourse();
            crs.MdiParent = this;
            crs.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchcs src = new frmSearchcs();
            src.MdiParent = this;
            src.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
