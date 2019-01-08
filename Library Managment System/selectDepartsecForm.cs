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
    public partial class selectDepartsecForm : Form
    {
        public selectDepartsecForm()
        {
            InitializeComponent();
        }
        public string departsecPassingText;
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
        private void selectDepartsecForm_Load(object sender, EventArgs e)
        {
            gridload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //search
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT deptid AS DepartSecID, deptname AS DepartmentSection, description AS Description FROM lbldept WHERE deptname like('%" + textBox1.Text + "%')";

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
            AddNewDepartsec ads = new AddNewDepartsec();
            ads.ShowDialog();
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
            departsecPassingText = row.Cells[1].Value.ToString();
            //MessageBox.Show(designationPassingText);
            this.Close();
        }
    }
}
