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
    public partial class ManageEmployee : Form
    {
        public ManageEmployee()
        {
            InitializeComponent();
           
        }
        
        DataTable dt;
        SQLiteDataAdapter da;
        database db = new database();

        public void gridload()
        {
            try
            {

                string query = "SELECT tblemp.empid AS EmployeeID, tblemp.name AS Name, tblemp.address AS Address, tblemp.nic AS NIC, tblemp.age AS Age,tblemp.hiredate AS HireDate, tblemp.status AS Status, tblemp.contactNo AS ContactNo, tbldesignation.designation AS Designation, lbldept.deptname AS Section FROM tbldesignation INNER JOIN (lbldept INNER JOIN tblemp ON lbldept.deptid = tblemp.deptid) ON tbldesignation.desigid = tblemp.desigid;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                dt = new DataTable();
                da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns[0].Width = 45;
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[5].Width = 50;

                dataGridView1.Columns[6].Width = 50;
                dataGridView1.Columns[7].Width = 50;
                dataGridView1.Columns[8].Width = 95;
                dataGridView1.Columns[9].Width = 85;
                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //load data
        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            gridload();

        }
        int employeeID;
        int deptID;
        int desigID;
        public void editbboxEmployee()
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            employeeID = Convert.ToInt32(row.Cells[0].Value.ToString());
            editEmployee eEmployee = new editEmployee();
            eEmployee.employeeID = employeeID;

            try
            {
                string query = "SELECT name, address, nic, age, hiredate, status, deptid, desigid, contactNo, basicpay FROM tblemp WHERE empid=" + employeeID + ";";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                SQLiteDataReader result = myCommand.ExecuteReader();
                while (result.Read())
                {
                    eEmployee.textBox2.Text = result.GetString(0);   //name
                    eEmployee.textBox4.Text = result.GetString(1);    //address
                    eEmployee.textBox10.Text = result.GetString(2);    //nic
                    eEmployee.textBox3.Text = Convert.ToString(result.GetInt32(3));    //age
                    eEmployee.dateTimePicker1.Value = DateTime.Parse(result.GetString(4));   //hiredate
                    eEmployee.comboBox1.Text = result.GetString(5);    //status
                    deptID = result.GetInt32(6);    //deptid
                    desigID = result.GetInt32(7);    //desigid
                    eEmployee.textBox9.Text = Convert.ToString(result.GetInt32(8));    //contactNo
                    eEmployee.textBox7.Text = Convert.ToString(result.GetDouble(9));    //basicpay
                    eEmployee.textBox6.Text = departmentName(deptID);
                    eEmployee.textBox8.Text = designationName(desigID);
                }
                db.CloseConnection();
                eEmployee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexrow;
            indexrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            //MessageBox.Show(row.Cells[0].Value.ToString());
            employeeID = Convert.ToInt32(row.Cells[0].Value.ToString());

            editEmployee eEmployee = new editEmployee();
              eEmployee.employeeID = employeeID;

            try
            {
                string query = "SELECT name, address, nic, age, hiredate, status, deptid, desigid, contactNo, basicpay FROM tblemp WHERE empid="+employeeID+";";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                SQLiteDataReader result = myCommand.ExecuteReader();

                // if (result.HasRows)
                //{
                while (result.Read())
                {
                    //s=result["Name"];
                    eEmployee.textBox2.Text = result.GetString(0);   //name
                    eEmployee.textBox4.Text = result.GetString(1);    //address
                    eEmployee.textBox10.Text = result.GetString(2);    //nic
                    eEmployee.textBox3.Text = Convert.ToString(result.GetInt32(3));    //age
                    eEmployee.dateTimePicker1.Value = DateTime.Parse(result.GetString(4));   //hiredate
                    eEmployee.comboBox1.Text = result.GetString(5);    //status
                  deptID = result.GetInt32(6);    //deptid
                  desigID = result.GetInt32(7);    //desigid
                    
                    eEmployee.textBox9.Text = Convert.ToString(result.GetInt32(8));    //contactNo
                    eEmployee.textBox7.Text = Convert.ToString(result.GetDouble(9));    //basicpay

                    eEmployee.textBox6.Text = departmentName(deptID);
                    eEmployee.textBox8.Text = designationName(desigID);


                    //translatedBy = result.GetDouble(18);    //translatedBy


                    // MessageBox.Show(Convert.ToString(result.GetDouble(9)));
                }


                db.CloseConnection();
                 eEmployee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //get deptname
        private string departmentName(int departmentID)
        {

            try
            {
                database db = new database();

                string query = "SELECT deptname FROM lbldept where deptid='" + departmentID + "'";

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
        //get designname
        private string designationName(int designationID)
        {

            try
            {
                database db = new database();
                string query = "SELECT designation FROM tbldesignation where desigid='" + designationID + "'";

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




    }
}
