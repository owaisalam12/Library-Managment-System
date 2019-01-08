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
    public partial class editIssue : Form
    {
        database db = new database();
        public int issueID;
        public string bookId;
        public editIssue()
        {
            InitializeComponent();
        }
        //exit
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //select book
        private void button6_Click(object sender, EventArgs e)
        {
            SelectBook sBook = new SelectBook();
            sBook.ShowDialog();
            textBox2.Text = sBook.bookPassingText;
            bookId = sBook.bookIDpassing;
        }
        //borrower
        private void button2_Click(object sender, EventArgs e)
        {
            selectBorrower sBorrower = new selectBorrower();
            sBorrower.ShowDialog();
            textBox1.Text = sBorrower.employeePassingText;
        }

        //get bookid
        private string bookID(string bookCAN)
        {
            try
            {
                database db = new database();
                string query = "SELECT bookid FROM tblbook where City='" + bookCAN + "'";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                string result = Convert.ToString(myCommand.ExecuteScalar());
                db.CloseConnection();
                //MessageBox.Show("Rows Added: {0}", result.ToString());
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get EmployeeID
        private string EmployeeID(string employeeText)
        {
            try
            {
                database db = new database();
                string query = "SELECT empid FROM tblemp where name='" + employeeText + "'";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                string result = Convert.ToString(myCommand.ExecuteScalar());
                db.CloseConnection();
                //MessageBox.Show("Rows Added: {0}", result.ToString());
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //save
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox10.Text) || String.IsNullOrEmpty(dateTimePicker1.Text) || String.IsNullOrEmpty(dateTimePicker2.Text) || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Fields can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show("Fields can not be empty");
            }
            else
            {
                try
                {
                    database db = new database();
                    //string query = "UPDATE tblissued SET( bookid, issueddaate, empid, returndate, qty, status ) VALUES ( '" + bookId + "', '" + dateTimePicker1.Text + "', '" + EmployeeID(textBox1.Text) + "', '" + dateTimePicker2.Text + "', '" + textBox10.Text + "', '" + comboBox1.Text + "' );";
                    string query = "UPDATE tblissued SET bookid = '" + bookId+ "', issueddaate = '" + dateTimePicker1.Text + "', empid = '" + EmployeeID(textBox1.Text) + "', returndate = '" + dateTimePicker2.Text + "', qty = '" + textBox10.Text + "', status = '" + comboBox1.Text + "' WHERE issuedid = '"+issueID+"';";
                    SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                    db.OpenConnection();
                    var result = myCommand.ExecuteNonQuery();
                    db.CloseConnection();
                    MessageBox.Show("Succesfull!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editIssue_Load(object sender, EventArgs e)
        {
            //dateTimePicker2.MinDate = DateTime.Parse(dateTimePicker1.Text);
        }
    }

}
