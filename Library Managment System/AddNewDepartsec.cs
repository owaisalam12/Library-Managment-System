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
    public partial class AddNewDepartsec : Form
    {
        public AddNewDepartsec()
        {
            InitializeComponent();
        }
        database db = new database();
        private void gridload()
        {
            try
            {

                string query = "SELECT deptid AS DepartSecID, deptname AS DepartmentSection, description AS Description FROM lbldept;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 120;
                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddNewDepartsec_Load(object sender, EventArgs e)
        {
            gridload();
        }
        //search
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT deptid AS DepartSecID, deptname AS DepartmentSection, description AS Description FROM lbldept WHERE deptname like('%" + textBox3.Text + "%')";

                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 120;
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
                    string query = "INSERT INTO lbldept (deptname, description ) VALUES ( '" + textBox1.Text + "','" + textBox2.Text + "' )";

                    SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                    db.OpenConnection();
                    var result = myCommand.ExecuteNonQuery();

                    db.CloseConnection();
                    gridload();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        //to show values on textbox
        int indexrow;
        int depsecId;
      private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            //MessageBox.Show(row.Cells[1].Value.ToString());
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            depsecId = Convert.ToInt32(row.Cells[0].Value.ToString());
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
                    string query = "UPDATE lbldept SET deptname = '" + textBox1.Text + "', description = '" + textBox2.Text + "' WHERE deptid = '" + depsecId + "'";

                    SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                    db.OpenConnection();
                    var result = myCommand.ExecuteNonQuery();

                    db.CloseConnection();
                    gridload();
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
                string query = "DELETE FROM lbldept WHERE deptid = '" + depsecId + "'";

                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                db.CloseConnection();
                gridload();
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
                gridload();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
