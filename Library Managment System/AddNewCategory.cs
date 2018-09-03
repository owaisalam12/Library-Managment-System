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
    public partial class AddNewCategory : Form
    {
        public AddNewCategory()
        {
            InitializeComponent();
        }
        database db = new database();
        private void grid_load()
        {
            try
            {
                string query = "SELECT catagoryid AS CategoryID, Desc AS Category FROM tblcatagory;";
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
        //load data
        private void AddNewCategory_Load(object sender, EventArgs e)
        {
            grid_load();
        }
        //search
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT catagoryid AS CategoryID, Desc AS Category FROM tblcatagory WHERE Desc like('%" + textBox3.Text + "%')";

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
        //add new
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Fields can not be empty");
            }
            else
            {
                try
                {
                     
                    string query = "INSERT INTO tblcatagory ( Desc ) VALUES ( '"+ textBox1.Text + "' );";
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
        int catid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            //MessageBox.Show(row.Cells[1].Value.ToString());
            textBox1.Text = row.Cells[1].Value.ToString();
           
            catid = Convert.ToInt32(row.Cells[0].Value.ToString());
        }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Fields can not be empty");
            }
            else
            {
                try
                {
                    string query = "UPDATE tblcatagory SET Desc = '" + textBox1.Text + "' WHERE catagoryid = '" + catid + "'";

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM tblcatagory WHERE catagoryid = '" + catid + "'";

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
}
