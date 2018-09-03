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
    public partial class selectCategoryForm : Form
    {
        public string CategoryPassingText;
        public selectCategoryForm()
        {
            InitializeComponent();
        }
        database db = new database();
        //load data
        private void selectCategoryForm_Load(object sender, EventArgs e)
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
                string query = "SELECT catagoryid AS CategoryID, Desc AS Category FROM tblcatagory WHERE Desc like('%" + textBox1.Text + "%')";

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
            AddNewCategory add = new AddNewCategory();
            add.Show();
        }
        //refresh
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT catagoryid AS CategoryID, Desc AS Category FROM tblcatagory WHERE Desc like('%" + textBox1.Text + "%')";

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
            
            CategoryPassingText = row.Cells[1].Value.ToString();
            // MessageBox.Show(CategoryPassingText);
            this.Close();
        }
    }
}
