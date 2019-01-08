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
    public partial class AddNewEmployee : Form
    {
        public AddNewEmployee()
        {
            InitializeComponent();
        }
        database db = new database();
        //exit button
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
            if ( String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox10.Text) || String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Fields can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show("Fields can not be empty");
            }
            else
            {
                try
                {
                    database db = new database();

                    string query = "INSERT INTO tblemp ( name, address, nic, age, hiredate, status, deptid, desigid, contactNo, basicpay ) VALUES ( '"+textBox2.Text+ "', '" + textBox4.Text + "', '" + textBox10.Text + "', '" + textBox3.Text + "', '" + dateTimePicker1.Text + "', '" + comboBox1.Text + "', '" +depsecID(textBox6.Text) + "', '" +designationID(textBox8.Text) + "', '" + textBox9.Text + "', '" + textBox7.Text + "' );";
                    SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                    db.OpenConnection();
                    var result = myCommand.ExecuteNonQuery();
                    db.CloseConnection();
                    MessageBox.Show("Rows Added: {0}", result.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void AddNewEmployee_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
