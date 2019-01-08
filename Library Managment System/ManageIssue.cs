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
    public partial class ManageIssue : Form
    {
        database db = new database();
        public ManageIssue()
        {
            InitializeComponent();
            start = 0;
        }

        int start;
        DataTable dt;
        SQLiteDataAdapter da;

        public void gridload()
        {

            try
            {


                string query = "SELECT tblissued.issuedid AS ID, tblissued.issueddaate AS IssueDate, tblissued.returndate AS ReturnDate, tblissued.qty AS Quantity, tblbook.city AS CAN, tblbook.Name AS BookName, tblbook.Edition AS Edition, tblemp.name AS Employee, lbldept.deptname AS Department, tblissued.status AS Status, tblcatagory.Desc AS Category, tblbook.oldaccessionno AS AccNo, tblbook.bookid AS BookID FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                dt = new DataTable();
                da = new SQLiteDataAdapter(myCommand);

                da.Fill(start, 75, dt);
                dataGridView1.DataSource = dt;
                Back.Enabled = false;
                toolStripButton4.Enabled = false;
                recordText.Text = "Record " + (start + 1) + " - " + (start + 75) + " of " + rowsCount();

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns[0].Width = 30;


                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[3].Width = 30;
                dataGridView1.Columns[4].Width = 40;
                dataGridView1.Columns[5].Width = 150;

                dataGridView1.Columns[6].Width = 50;
                dataGridView1.Columns[7].Width = 100;
                dataGridView1.Columns[8].Width = 70;
                dataGridView1.Columns[9].Width = 70;
                dataGridView1.Columns[10].Width = 70;
                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //load data
        private void ManageIssue_Load(object sender, EventArgs e)
        {
            gridload();
        }

        public void editboxIssue()
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            issueID = Convert.ToInt32(row.Cells[0].Value.ToString());
            editIssue editIssue = new editIssue();
            editIssue.issueID = issueID;

            try
            {

                // string query = "SELECT bookid, issueddaate, empid, returndate, qty, status FROM tblissued WHERE issuedid ='"+issueID+"' ;";
                string query = "SELECT  tblbook.Name, tblemp.name, tblissued.issueddaate, tblissued.returndate, tblissued.qty, tblbook.city AS CAN, tblissued.status, tblbook.bookid FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid WHERE tblissued.issuedid='" + issueID + "';";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                SQLiteDataReader result = myCommand.ExecuteReader();

                // if (result.HasRows)
                //{
                while (result.Read())
                {
                    editIssue.textBox2.Text = result.GetString(0); //bookname
                    editIssue.textBox1.Text = result.GetString(1); //borrower
                    editIssue.dateTimePicker1.Value = DateTime.Parse(result.GetString(2));     //issueddaate
                    editIssue.dateTimePicker2.Value = DateTime.Parse(result.GetString(3));    //returndate
                    editIssue.textBox10.Text = Convert.ToString(result.GetInt32(4));  //qty  
                    editIssue.textBox3.Text = result.GetString(5);   //CAN
                    editIssue.comboBox1.Text = result.GetString(6);    //status
                    editIssue.bookId = Convert.ToString(result.GetInt32(7));  //bookid
                                                                              //MessageBox.Show(Convert.ToString(result.GetInt32(7)));

                    // MessageBox.Show(result.GetString(7));
                }


                db.CloseConnection();
                editIssue.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int issueID;
        int bookID;
        int empID;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexrow;
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            //MessageBox.Show(row.Cells[0].Value.ToString());
            issueID = Convert.ToInt32(row.Cells[0].Value.ToString());

            editIssue editIssue = new editIssue();
            editIssue.issueID = issueID;

            try
            {

                // string query = "SELECT bookid, issueddaate, empid, returndate, qty, status FROM tblissued WHERE issuedid ='"+issueID+"' ;";
                string query = "SELECT  tblbook.Name, tblemp.name, tblissued.issueddaate, tblissued.returndate, tblissued.qty, tblbook.city AS CAN, tblissued.status, tblbook.bookid FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid WHERE tblissued.issuedid='" + issueID + "';";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                SQLiteDataReader result = myCommand.ExecuteReader();

                // if (result.HasRows)
                //{
                while (result.Read())
                {
                    editIssue.textBox2.Text = result.GetString(0); //bookname
                    editIssue.textBox1.Text = result.GetString(1); //borrower
                    editIssue.dateTimePicker1.Value = DateTime.Parse(result.GetString(2));     //issueddaate
                    if (result.GetString(3) == "xxxxxx")
                    {
                        editIssue.dateTimePicker2.Value = DateTime.Now;
                            //DateTime.Parse(result.GetString(2));
                    }
                    else
                    {
                        editIssue.dateTimePicker2.Value = DateTime.Parse(result.GetString(3));    //returndate

                    }
                    editIssue.textBox10.Text = Convert.ToString(result.GetInt32(4));  //qty  
                    editIssue.textBox3.Text = result.GetString(5);   //CAN
                    editIssue.comboBox1.Text = result.GetString(6);    //status
                    editIssue.bookId = Convert.ToString(result.GetInt32(7));  //bookid
                     //MessageBox.Show(Convert.ToString(result.GetInt32(7)));

                    // MessageBox.Show(result.GetString(7));
                }


                db.CloseConnection();
                editIssue.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int rowsCount()
        {
            try
            {
                database db = new database();

                string query = "SELECT Count(*) FROM tblissued";

                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                int result = Convert.ToInt32(myCommand.ExecuteScalar());
                db.CloseConnection();
                //MessageBox.Show("Rows Added: {0}", result.ToString());
                return result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private void Next_Click(object sender, EventArgs e)
        {
            start = start + 75;
            Back.Enabled = true;
            toolStripButton4.Enabled = true;
            if (start > rowsCount())
            {
                start = rowsCount() - 75;
                Next.Enabled = false;
                SkipToEnd.Enabled = false;
            }
            dt.Clear();
            da.Fill(start, 75, dt);

            recordText.Text = "Record " + (start + 1) + " - " + (start + 75) + " of " + rowsCount();

        }

        private void Back_Click(object sender, EventArgs e)
        {
            start = start - 75;
            if (start < 0)
            {
                start = 0;
                Back.Enabled = false;
                toolStripButton4.Enabled = false;
            }
            Next.Enabled = true;
            SkipToEnd.Enabled = true;
            dt.Clear();
            da.Fill(start, 75, dt);
            recordText.Text = "Record " + (start + 1) + " - " + (start + 75) + " of " + rowsCount();
        }
        //skip to start
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            start = 0;
            Back.Enabled = false;
            toolStripButton4.Enabled = false;
            Next.Enabled = true;
            SkipToEnd.Enabled = true;
            dt.Clear();
            da.Fill(start, 75, dt);
            recordText.Text = "Record " + (start + 1) + " - " + (start + 75) + " of " + rowsCount();
        }
        //skip to end
        private void SkipToEnd_Click(object sender, EventArgs e)
        {
            start = rowsCount() - 75;
            Next.Enabled = false;
            SkipToEnd.Enabled = false;
            Back.Enabled = true;
            toolStripButton4.Enabled = true;
            dt.Clear();
            da.Fill(start, 75, dt);
            recordText.Text = "Record " + (start + 1) + " - " + (start + 75) + " of " + rowsCount();
        }
    }
}
