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
    public partial class AddNewDesignation : Form
    {
        public AddNewDesignation()
        {
            InitializeComponent();
        }
        database db = new database();
        private void gridload()
        {
            try
            {

                string query = "SELECT desigid As DesignationID, designation As Designation, descreiption As Description FROM tbldesignation;";
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

        private void AddNewDesignation_Load(object sender, EventArgs e)
        {
            gridload();
        }
        //search
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT desigid As DesignationID, designation As Designation, descreiption As Description FROM tbldesignation WHERE designation like('%" + textBox3.Text + "%')";

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
                    string query = "INSERT INTO tbldesignation (designation, descreiption ) VALUES ( '" + textBox1.Text + "','" + textBox2.Text + "' )";

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
        int indexrow;
        int desgid;
        //to get values on textfield at runtime
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            desgid = Convert.ToInt32(row.Cells[0].Value.ToString());
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
           
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
                    string query = "UPDATE tbldesignation SET designation = '" + textBox1.Text + "', descreiption = '" + textBox2.Text + "' WHERE desigid = '" + desgid + "'";

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
                string query = "DELETE FROM tbldesignation WHERE desigid = '" + desgid + "'";

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
