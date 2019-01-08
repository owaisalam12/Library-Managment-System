using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Library_Managment_System
{
    public partial class mdi_userParent : Form
    {
        private int childFormNumber = 0;

        public mdi_userParent()
        {
            InitializeComponent();
            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        Shorcuts shortcutsForm;
        private void mdi_userParent_Load(object sender, EventArgs e)
        {

            advanceBookSearchToolStripMenuItem.Enabled = false;
            manageBookIssuanseToolStripMenuItem.Enabled = false;
            manageBooksToolStripMenuItem.Enabled = false;
            manageEmployeToolStripMenuItem.Enabled = false;
            fastSearchToolStripMenuItem.Enabled = false;

            if (shortcutsForm == null)
            {
                shortcutsForm = new Shorcuts();
                shortcutsForm.MdiParent = this;
                shortcutsForm.FormClosed += shortuts_FormClosed;
                shortcutsForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                shortcutsForm.Show();

            }
            else
            {
                shortcutsForm.Activate();
            }


        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Add_New_Book addNewBook = new Add_New_Book();
            //  addNewBook.Show();
        }

        private void manageBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ManageBooks mbooks = new ManageBooks();
            //  mbooks.MdiParent = this;
            // mbooks.WindowState = FormWindowState.Maximized;
            // mbooks.Show();


        }

        private void addNewBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_New_Book addNewBook = new Add_New_Book();
            addNewBook.ShowDialog();
        }
        ManageBooks mbooks;
        private void bookRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mbooks == null)
            {
                mbooks = new ManageBooks();
                mbooks.MdiParent = this;
                mbooks.WindowState = FormWindowState.Maximized;
                mbooks.FormClosed += Mbooks_FormClosed;
                mbooks.Show();
              //  advanceBookSearchToolStripMenuItem.Enabled = true;

            }
            else
            {
                mbooks.Activate();
            }


        }
        private void shortuts_FormClosed(object sender, FormClosedEventArgs e)
        {
            shortcutsForm = null;
            //throw new NotImplementedException();
        }

        private void Mbooks_FormClosed(object sender, FormClosedEventArgs e)
        {
            mbooks = null;
            //throw new NotImplementedException();
        }

        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewEmployee addEmployee = new AddNewEmployee();
            addEmployee.ShowDialog();
        }
        ManageEmployee mEmployee;
        private void employeeRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mEmployee == null)
            {
                mEmployee = new ManageEmployee();
                mEmployee.MdiParent = this;
                mEmployee.FormClosed += MEmployee_FormClosed;
                mEmployee.WindowState = FormWindowState.Maximized;
                mEmployee.Show();

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

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook issueBook = new IssueBook();
            issueBook.ShowDialog();
        }
        ManageIssue mIssue;
        private void issuanceRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mIssue == null)
            {
                mIssue = new ManageIssue();
                mIssue.MdiParent = this;
                mIssue.FormClosed += MIssue_FormClosed;
                mIssue.WindowState = FormWindowState.Maximized;
                mIssue.Show();
            }
            else
            {
                mIssue.Activate();
            }

        }

        private void MIssue_FormClosed(object sender, FormClosedEventArgs e)
        {
            mIssue = null;
            //throw new NotImplementedException();
        }
        fastBookSearch fastBookSearch;
        private void fastSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fastBookSearch == null)
            {
                fastBookSearch = new fastBookSearch();
                fastBookSearch.MdiParent = this;
                fastBookSearch.FormClosed += FastBookSearch_FormClosed;
                fastBookSearch.WindowState = FormWindowState.Maximized;

                fastBookSearch.Show();
            }
            else
            {
                fastBookSearch.Activate();
            }

        }

        private void FastBookSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            fastBookSearch = null;
            //throw new NotImplementedException();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public AdvancedBookSearch advbooksearch;
        private void advanceBookSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (advbooksearch == null)
            {
                advbooksearch = new AdvancedBookSearch();
                advbooksearch.FormClosed += Advbooksearch_FormClosed;
                advbooksearch.Show();
            }
            else
            {
                advbooksearch.Activate();
            }


        }

        private void Advbooksearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            advbooksearch = null;
            //throw new NotImplementedException();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //report entire list of book
        private void entireListOfBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entirelistofbooks listbooks = new entirelistofbooks();
            listbooks.ShowDialog();


        }

        private void authorWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportAuthorWise athwise = new ReportAuthorWise();
            athwise.ShowDialog();
        }

        private void publisherWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPublisherWise pubwise = new ReportPublisherWise();
            pubwise.ShowDialog();
        }

        private void categoryWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportCategoryWise catwise = new ReportCategoryWise();
            catwise.ShowDialog();
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportLanguageWise lanwise = new ReportLanguageWise();
            lanwise.ShowDialog();
        }

        private void cupboardWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportCupboardWise cupwise = new ReportCupboardWise();
            cupwise.ShowDialog();
        }

        private void countryWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportCountryWise couwise = new ReportCountryWise();
            couwise.ShowDialog();
        }

        private void sectionWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSectionWise secwise = new ReportSectionWise();
            secwise.ShowDialog();
        }

        private void borrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportBorrowerWise borwise = new ReportBorrowerWise();
            borwise.ShowDialog();
        }

        private void dateWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDateWise datwise = new ReportDateWise();
            datwise.ShowDialog();
        }

        //close button
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if ((Application.OpenForms[i].Name != "Form1") && (Application.OpenForms[i].Name != "Shorcuts") && (Application.OpenForms[i].Name != "mdi_userParent"))
                {
                    Application.OpenForms[i].Close();

                }
            }

        }
        //shortcut button
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if ((Application.OpenForms[i].Name != "Form1") && (Application.OpenForms[i].Name != "Shorcuts") && (Application.OpenForms[i].Name != "mdi_userParent"))
                {
                    Application.OpenForms[i].Close();

                }
            }

            //if (shortcutsForm == null)
            //{
            //    shortcutsForm = new Shorcuts();
            //    shortcutsForm.MdiParent = this;
            //    shortcutsForm.FormClosed += MEmployee_FormClosed;
            //    shortcutsForm.WindowState = FormWindowState.Maximized;
            //    shortcutsForm.Show();

            //}
            //else
            //{
            //    shortcutsForm.Activate();
            //}
        }
        //new button
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ManageBooks mb = new ManageBooks();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if ((Application.OpenForms[i].Name == "ManageBooks"))
                {
                    // if(Form.ActiveForm == "ManageBooks");
                    Add_New_Book addbook = new Add_New_Book();
                    addbook.ShowDialog();

                }
                else if ((Application.OpenForms[i].Name == "ManageEmployee"))
                {

                    AddNewEmployee addemployee = new AddNewEmployee();
                    addemployee.ShowDialog();
                }
                else if ((Application.OpenForms[i].Name == "ManageIssue"))
                {

                    IssueBook issueBook = new IssueBook();
                    issueBook.ShowDialog();
                }


                else
                {

                }
            }
        }
        bool check = false;
        Shorcuts shortcutform;
        //edit button
        private void toolStripButton11_Click(object sender, EventArgs e)
        {

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if ((Application.OpenForms[i].Name == "ManageBooks"))
                {

                    shortcutsForm.mbooks.editbox();
                    check = true;
                }
                else if ((Application.OpenForms[i].Name == "ManageEmployee"))
                {
                    shortcutsForm.mEmployee.editbboxEmployee();

                }
                else if ((Application.OpenForms[i].Name == "ManageIssue"))
                {
                    shortcutsForm.mIssue.editboxIssue();

                }
                else
                {

                }
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void advbooksearchISSUED_FormClosed(object sender, FormClosedEventArgs e)
        {
            advbooksearchISSUED = null;
            //throw new NotImplementedException();
        }

        AdvancedBookSearch_Issued_ advbooksearchISSUED;
        //search button
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if ((Application.OpenForms[i].Name == "ManageBooks"))
                {

                    if (advbooksearch == null)
                    {
                        advbooksearch = new AdvancedBookSearch();
                        advbooksearch.FormClosed += Advbooksearch_FormClosed;
                        advbooksearch.ShowDialog();
                    }
                    else
                    {
                        advbooksearch.Activate();
                    }
                }
                else if ((Application.OpenForms[i].Name == "ManageIssue"))
                {
                    if (advbooksearchISSUED == null)
                    {
                        advbooksearchISSUED = new AdvancedBookSearch_Issued_();
                        advbooksearchISSUED.FormClosed += advbooksearchISSUED_FormClosed;
                        advbooksearchISSUED.ShowDialog();
                    }
                    else
                    {
                        advbooksearchISSUED.Activate();
                    }

                }
                else
                {

                }
            }


        }
        //refresh button
        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            //ManageBooks mbooksrf = new ManageBooks();
            //mbooksrf.Show();
            //this.Close();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if ((Application.OpenForms[i].Name == "ManageBooks"))
                {
                    shortcutsForm.mbooks.gridload();
                    //mbooks.gridload();
                }
                else if ((Application.OpenForms[i].Name == "ManageEmployee"))
                {
                    shortcutsForm.mEmployee.gridload();
                }
                else if ((Application.OpenForms[i].Name == "ManageIssue"))
                {
                    shortcutsForm.mIssue.gridload();
                }
                else
                {

                }
            }

        }
        //delete button
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if ((Application.OpenForms[i].Name == "ManageBooks"))
                {
                    deletePassword delpassword = new deletePassword();
                    delpassword.ShowDialog();
                    if (delpassword.passcheck)
                    {

                        if (shortcutsForm.mbooks.delBookID > 0)
                        {
                            int shId = shortcutsForm.mbooks.delBookID;
                            //int id = mbooks.delBookID;
                            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected record?\n\nWARNING: You can not undo this operation.", "Confirm Record Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            if (result == DialogResult.OK)
                            {
                                //MessageBox.Show(""+ shId, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                deleteBook(shId);
                                // mbooks.gridload();
                            }
                            else { }

                        }
                    }

                }
                
                else
                {
                    //MessageBox.Show("Only books can be deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void deleteBook(int bookID)
        {


            try
            {
                database db = new database();

                string query = "delete from tblbook where bookid='" + bookID + "'";

                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                // string result = Convert.ToString(myCommand.ExecuteScalar());
                myCommand.ExecuteScalar();
                db.CloseConnection();
                //MessageBox.Show("Rows Added: {0}", result.ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void mdi_userParent_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }
    }
}