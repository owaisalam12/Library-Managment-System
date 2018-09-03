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
        }
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
        //load data
        private void ManageBooks_Load(object sender, EventArgs e)
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


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             int indexrow;                  
             indexrow = e.RowIndex;
             DataGridViewRow row = dataGridView1.Rows[indexrow];
            //MessageBox.Show(row.Cells[0].Value.ToString());
            bookId = Convert.ToInt32(row.Cells[0].Value.ToString());

             editEntry eEntry = new editEntry();
            eEntry.bookId2 = bookId;
            // eEntry.textBox2.Text = row.Cells[1].Value.ToString();
            // eEntry.textBox1.Text = row.Cells[2].Value.ToString();
            // eEntry.textBox15.Text = row.Cells[4].Value.ToString();
            // eEntry.textBox4.Text = row.Cells[3].Value.ToString();
            // eEntry.textBox9.Text = row.Cells[5].Value.ToString();
            // eEntry.textBox16.Text = row.Cells[6].Value.ToString();
            // eEntry.textBox8.Text = row.Cells[7].Value.ToString();
            // eEntry.textBox3.Text = row.Cells[8].Value.ToString();
            // eEntry.textBox6.Text = row.Cells[9].Value.ToString();
            // eEntry.textBox5.Text = row.Cells[10].Value.ToString();

            //// passingStatus = row.Cells[11].Value.ToString();
            // eEntry.ShowDialog();

            
          
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
    }
    }

