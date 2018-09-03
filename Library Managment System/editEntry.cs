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
    public partial class editEntry : Form
    {
        public int bookId2;
        public editEntry()
        {
            InitializeComponent();
        }
        //exit button
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editEntry_Load(object sender, EventArgs e)
        {
           // comboBox1.SelectedIndex = 0;
          //  comboBox2.SelectedIndex = 0;
          //  comboBox3.SelectedIndex = 0;

        }
        //get pubid
        private string publisherID(string publisherText)
        {

            try
            {
                database db = new database();

                string query = "SELECT pubid FROM tblpublisher where name='" + publisherText + "'";

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
        //publisher dot
        private void button3_Click(object sender, EventArgs e)
        {
            selectPublishersForm spf = new selectPublishersForm();
            spf.ShowDialog();
            textBox8.Text = spf.publisherPassingText;
        }
        //category dot
        private void button4_Click(object sender, EventArgs e)
        {
            selectCategoryForm scf = new selectCategoryForm();
            scf.ShowDialog();
            textBox6.Text = scf.CategoryPassingText;
        }
        //get catgid
        private string categoryID(string categoryText)
        {

            try
            {
                database db = new database();

                string query = "SELECT catagoryid FROM tblcatagory where Desc='" + categoryText + "'";

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
        //author dot
        private void button2_Click(object sender, EventArgs e)
        {
            selectAuthorForm saf = new selectAuthorForm();
            saf.ShowDialog();
            textBox16.Text = saf.authorPassingText;
        }

        //get authid
        private string authorID(string authorText)
        {

            try
            {
                database db = new database();

                string query = "SELECT authorid FROM tblauthor where name='" + authorText + "'";

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

        //save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox11.Text) || String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox18.Text) || String.IsNullOrEmpty(textBox16.Text) || String.IsNullOrEmpty(textBox12.Text) || String.IsNullOrEmpty(textBox13.Text) || String.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show("Fields can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show("Fields can not be empty");
            }
            else
            {
                try
                {
                    database db = new database();

                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd-MMM-yy";
                    string query = "UPDATE tblbook SET Name = '" + textBox9.Text + "', Edition = '" + textBox3.Text + "', City = '" + textBox1.Text + "', Country = '" + comboBox3.Text + "', Typeid = '" + textBox4.Text + "', pubid = '" + publisherID(textBox8.Text) + "', catagoryid = '" + categoryID(textBox6.Text) + "', authorid = '" + authorID(textBox16.Text) + "', Regid = '" + textBox15.Text + "', noofbooks = '" + textBox5.Text + "', purchasedate = '" + dateTimePicker1.Text + "', oldaccessionno = '" + textBox2.Text + "', language = '" + comboBox2.Text + "', Publishedyear = '" + textBox7.Text + "', volume = '" + textBox18.Text + "', pages = '" + textBox13.Text + "', price = '" + textBox11.Text + "', currancy = '" + comboBox1.Text + "', translatdby = '" + textBox12.Text + "' WHERE bookid = '" + bookId2 + "';";
                    SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                    db.OpenConnection();
                    var result = myCommand.ExecuteNonQuery();
                    db.CloseConnection();
                    MessageBox.Show("Rows Added: {0}", result.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }



        }
    }
}
