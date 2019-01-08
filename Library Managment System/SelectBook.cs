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
    public partial class SelectBook : Form
    {
        public SelectBook()
        {
            InitializeComponent();
        }
        public string bookPassingText;
        public string bookIDpassing;
        database db = new database();
        private void gridload()
        {
            try
            {

                string query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns[0].Width = 35;
                dataGridView1.Columns[1].Width = 40;
                dataGridView1.Columns[2].Width = 40;
                dataGridView1.Columns[3].Width = 40;
                dataGridView1.Columns[4].Width = 45;
                dataGridView1.Columns[5].Width = 180;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 100;
                dataGridView1.Columns[9].Width = 55;
                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SelectBook_Load(object sender, EventArgs e)
        {
            gridload();
        }

        //refresh
        private void button2_Click(object sender, EventArgs e)
        {
            gridload();
        }
        //addnew
        private void button1_Click(object sender, EventArgs e)
        {
            Add_New_Book addBook = new Add_New_Book();
            addBook.ShowDialog();
        }
        //search
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.Name like ('%" + textBox1.Text + "%')";

                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int indexrow;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];

            bookPassingText = row.Cells[5].Value.ToString();
            bookIDpassing = row.Cells[0].Value.ToString();
             //MessageBox.Show(row.Cells[0].Value.ToString());
            this.Close();
        }
    }
}
