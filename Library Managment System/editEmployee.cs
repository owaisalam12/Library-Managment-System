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
    public partial class editEmployee : Form
    {
        database db = new database();
        public editEmployee()
        {
            InitializeComponent();
        }
        public int employeeID;
        //exit
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //designation dot
        private void button3_Click(object sender, EventArgs e)
        {
            selectDesignationForm sdf = new selectDesignationForm();
            sdf.ShowDialog();
            textBox8.Text = sdf.designationPassingText;
        }
        //get desgid
        private string designationID(string designationText)
        {

            try
            {
                database db = new database();

                string query = "SELECT desigid FROM tbldesignation where designation='" + designationText + "'";

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
        //deptsec dot
        private void button4_Click(object sender, EventArgs e)
        {
            selectDepartsecForm sdsf = new selectDepartsecForm();
            sdsf.ShowDialog();
            textBox6.Text = sdsf.departsecPassingText;
        }
        //get deptsecid
        private string depsecID(string depsecText)
        {

            try
            {
                database db = new database();

                string query = "SELECT deptid FROM lbldept where deptname='" + depsecText + "'";

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
        //save
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox10.Text) || String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Fields can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show("Fields can not be empty");
            }
            else
            {
                try
                {
                    database db = new database();
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd-MMM-yy";
               
                    string query = "UPDATE tblemp SET name = '" + textBox2.Text + "', address = '" + textBox4.Text + "', nic = '" + textBox10.Text + "', age = '" + textBox3.Text + "', hiredate = '" + dateTimePicker1.Text + "', status = '" + comboBox1.Text + "', deptid = '" + depsecID(textBox6.Text) + "', desigid = '" + designationID(textBox8.Text) + "', contactNo = '" + textBox9.Text + "', basicpay = '" + textBox7.Text + "' WHERE empid = '"+employeeID+"';";
                    SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                    db.OpenConnection();
                    var result = myCommand.ExecuteNonQuery();
                    db.CloseConnection();
                    MessageBox.Show("Succesfull!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();

            }
        }
    }
}
