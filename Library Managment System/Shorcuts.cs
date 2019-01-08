using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class Shorcuts : Form
    {
        public Shorcuts()
        {
            InitializeComponent();
            this.ControlBox = false;
      
        }

        private void Shorcuts_Load(object sender, EventArgs e)
        {

        }
        public int idShortcut;
   
       public ManageBooks mbooks;
        //manage books
        mdi_userParent parentform = new mdi_userParent();
        private void button1_Click(object sender, EventArgs e)
        {
            if (mbooks == null)
            {
                mbooks = new ManageBooks();
                mbooks.MdiParent = this.MdiParent;
                mbooks.WindowState = FormWindowState.Maximized;
                mbooks.FormClosed += Mbooks_FormClosed;
                mbooks.Show();
                //advanceBookSearchToolStripMenuItem.Enabled = true;
                //idShortcut = mbooks.delBookID;

            }
            else
            {
                mbooks.Activate();
            }
        }


        private void Mbooks_FormClosed(object sender, FormClosedEventArgs e)
        {
            mbooks = null;
            //throw new NotImplementedException();
        }
        public ManageEmployee mEmployee;
        //manage employee
        private void button2_Click(object sender, EventArgs e)
        {
            if (mEmployee == null)
            {
                mEmployee = new ManageEmployee();
                mEmployee.MdiParent = this.MdiParent;
                mEmployee.WindowState = FormWindowState.Maximized;
                mEmployee.FormClosed += MEmployee_FormClosed;
                mEmployee.Show();
                //advanceBookSearchToolStripMenuItem.Enabled = true;
                //idShortcut = mbooks.delBookID;

            }
            else
            {
                mEmployee.Activate();
            }

        }
        private void MEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            mEmployee = null;
            //throw new NotImplementedException();
        }
        //manage book issuance
        public ManageIssue mIssue;
        private void MIssue_FormClosed(object sender, FormClosedEventArgs e)
        {
            mIssue = null;
            //throw new NotImplementedException();
        }
        fastBookSearch fastBookSearch;
        private void FastBookSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            fastBookSearch = null;
            //throw new NotImplementedException();
        }

        //manage book issuance
        private void button4_Click(object sender, EventArgs e)
        {
            if (mIssue == null)
            {
                mIssue = new ManageIssue();
                mIssue.MdiParent = this.MdiParent;
                mIssue.WindowState = FormWindowState.Maximized;
                mIssue.FormClosed += MIssue_FormClosed;
                mIssue.Show();
                //advanceBookSearchToolStripMenuItem.Enabled = true;
                //idShortcut = mbooks.delBookID;

            }
            else
            {
                mIssue.Activate();
            }

        }
        //fastbook search
        private void button3_Click(object sender, EventArgs e)
        {
            if (fastBookSearch == null)
            {
                fastBookSearch = new fastBookSearch();
                fastBookSearch.MdiParent = this.MdiParent;
                fastBookSearch.WindowState = FormWindowState.Maximized;
                fastBookSearch.FormClosed += FastBookSearch_FormClosed;
                fastBookSearch.Show();
                //advanceBookSearchToolStripMenuItem.Enabled = true;
                //idShortcut = mbooks.delBookID;

            }
            else
            {
                fastBookSearch.Activate();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
