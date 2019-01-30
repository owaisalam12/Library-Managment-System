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
	public partial class IssueBook : Form
	{
		public IssueBook()
		{
			InitializeComponent();
		}
		public string bookId;
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
		private void IssueBook_Load(object sender, EventArgs e)
		{
			comboBox1.SelectedIndex = 0;
			dateTimePicker2.MinDate = DateTime.Parse(dateTimePicker1.Text);
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
        }
		//get bookid
		private string bookID(string bookText)
		{
			try
			{
				database db = new database();
				string query = "SELECT bookid FROM tblbook where Name='" + bookText + "'";
				SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
				db.OpenConnection();
				string result = Convert.ToString(myCommand.ExecuteNonQuery());
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
		SelectBook sbook = new SelectBook();

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
                    string query;
                    string returnedDate = "xxxxxx";
                    if (checkBox1.Checked)
                    {
                        query = "INSERT INTO tblissued ( bookid, issueddaate, empid, returndate, qty, status ) VALUES ( '" + bookId + "', '" + dateTimePicker1.Text + "', '" + EmployeeID(textBox1.Text) + "', '" + returnedDate + "', '" + textBox10.Text + "', '" + comboBox1.Text + "' );";
                        
                    }
                    else
                    {
                       query = "INSERT INTO tblissued ( bookid, issueddaate, empid, returndate, qty, status ) VALUES ( '" + bookId + "', '" + dateTimePicker1.Text + "', '" + EmployeeID(textBox1.Text) + "', '" + dateTimePicker2.Text + "', '" + textBox10.Text + "', '" + comboBox1.Text + "' );";

                    }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("You are in the CheckBox.CheckedChanged event.");
            if (checkBox1.Checked)
            {
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker2.Enabled = true;

            }


        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
