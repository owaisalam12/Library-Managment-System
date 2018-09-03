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
    public partial class AddNewPublisher : Form
    {
      
        public AddNewPublisher()
        {
            InitializeComponent();
        }
        database db = new database();
        private void AddNewPublisher_Load(object sender, EventArgs e)
        {
            //string query = "SELECT pubid AS PublisherID, name AS Name, country AS Country FROM tblpublisher;";
            //SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
            //db.OpenConnection();
            //var result = myCommand.ExecuteNonQuery();

            //DataTable dt = new DataTable();
            //SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //db.CloseConnection();

            grid_load();
        }
        private void grid_load()
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
        //search
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT pubid AS PublisherID, name AS Name, country AS Country FROM tblpublisher WHERE name like('%" + textBox3.Text + "%')";

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
        //addnew
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("Fields can not be empty");
            }
            else
            {
                try
                {
                    string query = "INSERT INTO tblpublisher (name, country ) VALUES ( '" + textBox1.Text + "','" + textBox2.Text + "' )";

                    SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                    db.OpenConnection();
                    var result = myCommand.ExecuteNonQuery();

                    db.CloseConnection();
                    grid_load();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        int indexrow;
        int pubid;
        //to get values on textfield at runtime
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            //MessageBox.Show(row.Cells[1].Value.ToString());
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            pubid = Convert.ToInt32(row.Cells[0].Value.ToString());
        }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("Fields can not be empty");
            }
            else
            {
                try
                {
                    string query = "UPDATE tblpublisher SET name = '" + textBox1.Text + "', country = '" + textBox2.Text + "' WHERE pubid = '" + pubid + "'";

                    SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                    db.OpenConnection();
                    var result = myCommand.ExecuteNonQuery();

                    db.CloseConnection();
                    grid_load();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM tblpublisher WHERE pubid = '"+pubid+"'";

                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                db.CloseConnection();
                grid_load();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //refresh
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                grid_load();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
