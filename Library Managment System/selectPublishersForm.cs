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
    public partial class selectPublishersForm : Form
    {
        public string publisherPassingText;
        public selectPublishersForm()
        {
            InitializeComponent();
        }
        database db = new database();
        //load data
        private void selectPublishersForm_Load(object sender, EventArgs e)
        {
            try
            {

                string query = "SELECT pubid AS PublisherID, name AS Name, country AS Country FROM tblpublisher;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //search
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT pubid AS PublisherID, name AS Name, country AS Country FROM tblpublisher WHERE name like('%" + textBox1.Text + "%')";

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

        private void button1_Click(object sender, EventArgs e)
        {
            //database db = new database();

            
        }
        //addnew button
        private void button1_Click_1(object sender, EventArgs e)
        {
            AddNewPublisher add = new AddNewPublisher();
            add.ShowDialog();
        }
        //refresh
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT pubid AS PublisherID, name AS Name, country AS Country FROM tblpublisher;";
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
        //to get value to main form
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            publisherPassingText = row.Cells[1].Value.ToString();
            // MessageBox.Show(publisherPassingText);
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
