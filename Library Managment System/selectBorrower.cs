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
    public partial class selectBorrower : Form
    {
        public selectBorrower()
        {
            InitializeComponent();
        }
        database db = new database();
        public string employeePassingText;
        private void gridload()
        {
            try
            {

                string query = "SELECT tblemp.empid AS EmpID, tblemp.name AS Employee_Name, lbldept.deptname AS Department,tbldesignation.designation AS Designation FROM tbldesignation INNER JOIN (lbldept INNER JOIN tblemp ON lbldept.deptid = tblemp.deptid) ON tbldesignation.desigid = tblemp.desigid;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns[0].Width = 10;
                dataGridView1.Columns[1].Width = 25;
                dataGridView1.Columns[2].Width = 15;
                dataGridView1.Columns[3].Width = 80;
                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void selectBorrower_Load(object sender, EventArgs e)
        {
            gridload();
        }
        //search
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string query = "SELECT tblemp.empid AS EmpID, tblemp.name AS Employee_Name, lbldept.deptname AS Department,tbldesignation.designation AS Designation FROM tbldesignation INNER JOIN (lbldept INNER JOIN tblemp ON lbldept.deptid = tblemp.deptid) ON tbldesignation.desigid = tblemp.desigid WHERE tblemp.name like ('%" + textBox1.Text + "%')";

                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns[0].Width = 10;
                dataGridView1.Columns[1].Width = 25;
                dataGridView1.Columns[2].Width = 15;
                dataGridView1.Columns[3].Width = 80;
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //refresh
        private void button2_Click(object sender, EventArgs e)
        {
            gridload();
        }
        //add new
        private void button1_Click(object sender, EventArgs e)
        {
            AddNewEmployee newEmp = new AddNewEmployee();
            newEmp.ShowDialog();
        }
        int indexrow;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];

            employeePassingText = row.Cells[1].Value.ToString();
            //MessageBox.Show(employeePassingText);
            this.Close();
        }
    }
}
