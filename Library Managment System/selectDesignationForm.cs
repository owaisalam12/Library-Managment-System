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
    public partial class selectDesignationForm : Form
    {
        public selectDesignationForm()
        {
            InitializeComponent();
        }
        public string designationPassingText;
        private void gridload()
        {
            try
            {

                string query = "SELECT desigid As DesignationID, designation As Designation, descreiption As Description FROM tbldesignation;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                
               // db.myConnection.Open();
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 130;
                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        database db = new database();
        //load data
        private void selectDesignationForm_Load(object sender, EventArgs e)
        {
            gridload();
        }
        //search
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT desigid As DesignationID, designation As Designation, descreiption As Description FROM tbldesignation WHERE designation like('%" + textBox1.Text + "%')";

                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 130;
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //addnew button
        private void button1_Click(object sender, EventArgs e)
        {
            AddNewDesignation aNd = new AddNewDesignation();
            aNd.ShowDialog();
        }
        //refresh
        private void button2_Click(object sender, EventArgs e)
        {
            gridload();
        }
        //to get value to main form
        int indexrow;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            designationPassingText = row.Cells[1].Value.ToString();
            //MessageBox.Show(designationPassingText);
            this.Close();
        }
    }
}
