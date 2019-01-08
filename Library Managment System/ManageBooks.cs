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
    public partial class ManageBooks : Form
    {
        public ManageBooks()
        {
            InitializeComponent();
            start = 0;
        }
        int start;
        database db = new database();
        public string passingBookID;
        public string passingCAN;
        public string passingAccNo;
        public string passingCupboadNo;
        public string passingCallNo;
        public string passingBookName;
        public string passingAuthorName;
        public string passingPublisher;
        public string passingEdition;
        public string passingBookCategory;
        public string passingQuantity;
        public string passingStatus;


        int pubId;
        int categoryId;
        int authorId;
        public int bookId;
        DataTable dt;
        SQLiteDataAdapter da;

        public void gridload()
        {

            try
            {

                string query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                dt = new DataTable();
                da = new SQLiteDataAdapter(myCommand);
                // da.Fill(dt);
                da.Fill(start, 75, dt);
                dataGridView1.DataSource = dt;
                
                Back.Enabled = false;
                toolStripButton4.Enabled = false;
                recordText.Text = "Record " + (start + 1) + " - " + (start + 75) + " of " + rowsCount();
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns[0].Width = 35;
                dataGridView1.Columns[1].Width = 40;
                dataGridView1.Columns[2].Width = 40;
                dataGridView1.Columns[3].Width = 40;
                dataGridView1.Columns[4].Width = 45;
                dataGridView1.Columns[5].Width = 200;
                dataGridView1.Columns[6].Width = 110;
                dataGridView1.Columns[7].Width = 110;
                dataGridView1.Columns[9].Width = 55;

                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //load data
        private void ManageBooks_Load(object sender, EventArgs e)
        {

            gridload();
        }

        public int editBookid;
        public void editbox(){
            
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            editBookid = Convert.ToInt32(row.Cells[0].Value.ToString());
            
            editEntry eEntry = new editEntry();
            eEntry.bookId2 = editBookid;

            try
            {
                string query = "SELECT Name, Edition, City, Country, Typeid, pubid, catagoryid, authorid, Regid, noofbooks, purchasedate, oldaccessionno, language, Publishedyear, volume, pages, price, currancy, translatdby FROM tblbook WHERE bookid=" + editBookid + ";";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                SQLiteDataReader result = myCommand.ExecuteReader();

                // if (result.HasRows)
                //{
                while (result.Read())
                {
                    //s=result["Name"];
                    eEntry.textBox9.Text = result.GetString(0);    //bookName
                    eEntry.textBox3.Text = result.GetString(1);    //edition
                    eEntry.textBox1.Text = result.GetString(2);    //CAN
                    eEntry.comboBox3.Text = result.GetString(3);    //country
                    eEntry.textBox4.Text = Convert.ToString(result.GetInt32(4));    //callNo
                    pubId = result.GetInt32(5);    //pubId
                    categoryId = result.GetInt32(6);    //catagoryId
                    authorId = result.GetInt32(7);    //authorId
                    eEntry.textBox15.Text = Convert.ToString(result.GetInt32(8));    //cupboardNo
                    eEntry.textBox5.Text = Convert.ToString(result.GetInt32(9));    //quantity

                    //textBox1.Text = Convert.ToString(result.GetDouble(18));
                    //purchaseDate = result["purchasedate"].ToString();    //quantity
                    // string date=  result["purchasedate"].ToString();
                    // string date = result.GetString(10);

                    eEntry.dateTimePicker1.Value = DateTime.Parse(result.GetString(10));

                    eEntry.textBox2.Text = result.GetString(11);    //AccNo
                    eEntry.comboBox2.Text = result.GetString(12);    //language
                    eEntry.textBox7.Text = Convert.ToString(result.GetInt32(13));    //publishedYear
                    eEntry.textBox18.Text = result.GetString(14);    //volume
                    eEntry.textBox13.Text = Convert.ToString(result.GetInt32(15));    //pages
                    eEntry.textBox11.Text = Convert.ToString(result.GetDouble(16));    //price
                    eEntry.comboBox1.Text = result.GetString(17);    //currency
                    eEntry.textBox12.Text = result.GetString(18);    // translatedBy
                    eEntry.textBox16.Text = authorName(authorId);
                    eEntry.textBox6.Text = categoryname(categoryId);
                    eEntry.textBox8.Text = publisherName(pubId);

                    //translatedBy = result.GetDouble(18);    //translatedBy
                    //string asd= result["translatdby"].ToString();

                    //  MessageBox.Show(asd);
                }


                db.CloseConnection();
                eEntry.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexrow;
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            //row.DefaultCellStyle.BackColor= Color.Red;
            //row.DefaultCellStyle.ForeColor = Color.White;
            bookId = Convert.ToInt32(row.Cells[0].Value.ToString());

            editEntry eEntry = new editEntry();
            eEntry.bookId2 = bookId;


            try
            {
                string query = "SELECT Name, Edition, City, Country, Typeid, pubid, catagoryid, authorid, Regid, noofbooks, purchasedate, oldaccessionno, language, Publishedyear, volume, pages, price, currancy, translatdby FROM tblbook WHERE bookid=" + bookId + ";";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                SQLiteDataReader result = myCommand.ExecuteReader();

                // if (result.HasRows)
                //{
                while (result.Read())
                {
                    //s=result["Name"];
                    eEntry.textBox9.Text = result.GetString(0);    //bookName
                    eEntry.textBox3.Text = result.GetString(1);    //edition
                    eEntry.textBox1.Text = result.GetString(2);    //CAN
                    eEntry.comboBox3.Text = result.GetString(3);    //country
                   // eEntry.textBox4.Text = Convert.ToString(result.GetInt32(4));    //callNo
                   
                    pubId = result.GetInt32(5);    //pubId
                    categoryId = result.GetInt32(6);    //catagoryId
                    authorId = result.GetInt32(7);    //authorId
                    eEntry.textBox15.Text = Convert.ToString(result.GetInt32(8));    //cupboardNo
                    eEntry.textBox5.Text = Convert.ToString(result.GetInt32(9));    //quantity

                    //textBox1.Text = Convert.ToString(result.GetDouble(18));
                    //purchaseDate = result["purchasedate"].ToString();    //quantity
                    // string date=  result["purchasedate"].ToString();
                    // string date = result.GetString(10);

                    eEntry.dateTimePicker1.Value = DateTime.Parse(result.GetString(10));

                    eEntry.textBox2.Text = result.GetString(11);    //AccNo
                    eEntry.comboBox2.Text = result.GetString(12);    //language
                    eEntry.textBox7.Text = Convert.ToString(result.GetInt32(13));    //publishedYear
                    eEntry.textBox18.Text = result.GetString(14);    //volume
                    eEntry.textBox13.Text = Convert.ToString(result.GetInt32(15));    //pages
                    eEntry.textBox11.Text = Convert.ToString(result.GetDouble(16));    //price
                    eEntry.comboBox1.Text = result.GetString(17);    //currency
                    eEntry.textBox12.Text = result.GetString(18);    // translatedBy
                    eEntry.textBox16.Text = authorName(authorId);
                    eEntry.textBox6.Text = categoryname(categoryId);
                    eEntry.textBox8.Text = publisherName(pubId);

                    //translatedBy = result.GetDouble(18);    //translatedBy
                    //string asd= result["translatdby"].ToString();

                    //  MessageBox.Show(asd);
                }


                db.CloseConnection();
                eEntry.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //get authname
        private string authorName(int authorID)
        {

            try
            {
                database db = new database();

                string query = "SELECT name FROM tblauthor where authorid='" + authorID + "'";

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
        //get catgname
        private string categoryname(int categoryID)
        {

            try
            {
                database db = new database();

                string query = "SELECT Desc FROM tblcatagory where catagoryid='" + categoryID + "'";

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

        //get pubname
        private string publisherName(int publisherID)
        {

            try
            {
                database db = new database();

                string query = "SELECT name FROM tblpublisher where pubid='" + publisherID + "'";

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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }


        private int rowsCount()
        {
            try
            {
                database db = new database();

                string query = "SELECT Count(*) FROM tblbook";

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
        //find borrower
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            string name=null;
            string date = null;
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            bookId = Convert.ToInt32(row.Cells[0].Value.ToString());
            try
            {
                database db = new database();
                string query = "SELECT name,issueddaate FROM issue1 where bookid='" + bookId + "' and Status=\"Issued\"";
                db.OpenConnection();
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                SQLiteDataReader rdr = myCommand.ExecuteReader();
                while (rdr.Read())
                {

                    name = (rdr.GetValue(0).ToString());
                    date = (rdr.GetValue(1).ToString());
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            if (name != null && date != null)
            {
                MessageBox.Show("This Book has been issued to "+name+" on "+date,"Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This Book has not been issued and it is available for issuance.","Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public int delBookID;
        DataGridViewRow row2;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexrow;
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            delBookID = Convert.ToInt32(row.Cells[0].Value.ToString());
            row2 = row;

        }
        int bidIssue;
        public void check()
        {
            try
            {
                database db = new database();
                string status = "\"Issued\"";
                string query = "SELECT tblbook.bookid FROM tblbook,issue1 where issue1.bookid=tblbook.bookid and issue1.Status="+status+"";
                db.OpenConnection();
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                SQLiteDataReader rdr = myCommand.ExecuteReader();
                while (rdr.Read())
                {
                    bidIssue = Convert.ToInt32((rdr.GetValue(0).ToString()));

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        //DataGridViewRow row = dataGridView1.SelectedRows[0];
                        bookId = Convert.ToInt32(row.Cells[0].Value.ToString());
                        if (bidIssue == bookId)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }

                    }

                    
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //row2.DefaultCellStyle.BackColor = Color.Red;  
            //check();

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            //check();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           check();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           // check();
        }
    }
}

