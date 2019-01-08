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
    public partial class AdvancedBookSearch_Issued_ : Form
    {
        public AdvancedBookSearch_Issued_()
        {
            InitializeComponent();
        }
        database db = new database();

        //search button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query;
                if (comboBox1.SelectedIndex == 0)//issueId
                {
                    query = "SELECT tblissued.issuedid AS ID, tblissued.issueddaate AS IssueDate, tblissued.returndate AS ReturnDate, tblissued.qty AS Quantity, tblbook.city AS CAN, tblbook.Name AS BookName, tblbook.Edition AS Edition, tblemp.name AS Employee, lbldept.deptname AS Department, tblissued.status AS Status, tblcatagory.Desc AS Category, tblbook.oldaccessionno AS AccNo, tblbook.bookid AS BookID FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid WHERE tblissued.issuedid ";
                }
                else if (comboBox1.SelectedIndex == 1)//bookName
                {
                    query = "SELECT tblissued.issuedid AS ID, tblissued.issueddaate AS IssueDate, tblissued.returndate AS ReturnDate, tblissued.qty AS Quantity, tblbook.city AS CAN, tblbook.Name AS BookName, tblbook.Edition AS Edition, tblemp.name AS Employee, lbldept.deptname AS Department, tblissued.status AS Status, tblcatagory.Desc AS Category, tblbook.oldaccessionno AS AccNo, tblbook.bookid AS BookID FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid WHERE tblbook.Name ";

                }
                else if (comboBox1.SelectedIndex == 2)//accNo
                {
                    query = "SELECT tblissued.issuedid AS ID, tblissued.issueddaate AS IssueDate, tblissued.returndate AS ReturnDate, tblissued.qty AS Quantity, tblbook.city AS CAN, tblbook.Name AS BookName, tblbook.Edition AS Edition, tblemp.name AS Employee, lbldept.deptname AS Department, tblissued.status AS Status, tblcatagory.Desc AS Category, tblbook.oldaccessionno AS AccNo, tblbook.bookid AS BookID FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid WHERE tblbook.oldaccessionno ";

                }
                else if (comboBox1.SelectedIndex == 3)//can
                {
                    query = "SELECT tblissued.issuedid AS ID, tblissued.issueddaate AS IssueDate, tblissued.returndate AS ReturnDate, tblissued.qty AS Quantity, tblbook.city AS CAN, tblbook.Name AS BookName, tblbook.Edition AS Edition, tblemp.name AS Employee, lbldept.deptname AS Department, tblissued.status AS Status, tblcatagory.Desc AS Category, tblbook.oldaccessionno AS AccNo, tblbook.bookid AS BookID FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid WHERE tblbook.city ";
                }
                else if (comboBox1.SelectedIndex == 4)//employeeName
                {
                    query = "SELECT tblissued.issuedid AS ID, tblissued.issueddaate AS IssueDate, tblissued.returndate AS ReturnDate, tblissued.qty AS Quantity, tblbook.city AS CAN, tblbook.Name AS BookName, tblbook.Edition AS Edition, tblemp.name AS Employee, lbldept.deptname AS Department, tblissued.status AS Status, tblcatagory.Desc AS Category, tblbook.oldaccessionno AS AccNo, tblbook.bookid AS BookID FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid WHERE  tblemp.name ";
                }
                else //for 5 status
                {
                    query = "SELECT tblissued.issuedid AS ID, tblissued.issueddaate AS IssueDate, tblissued.returndate AS ReturnDate, tblissued.qty AS Quantity, tblbook.city AS CAN, tblbook.Name AS BookName, tblbook.Edition AS Edition, tblemp.name AS Employee, lbldept.deptname AS Department, tblissued.status AS Status, tblcatagory.Desc AS Category, tblbook.oldaccessionno AS AccNo, tblbook.bookid AS BookID FROM lbldept INNER JOIN ((tblemp INNER JOIN (tblbook INNER JOIN tblissued ON tblbook.bookid=tblissued.bookid) ON tblemp.empid=tblissued.empid) INNER JOIN tblcatagory ON tblbook.catagoryid=tblcatagory.catagoryid) ON lbldept.deptid=tblemp.deptid WHERE  tblissued.status ";
                }

                string filterString;
                switch (comboBox2.SelectedIndex)
                {

                    case 0: //contains
                        filterString = "like('%" + textBox1.Text + "%')";
                        break;
                    case 1://is equal to
                        filterString = "= '" + textBox1.Text + "'";
                        break;
                    case 2: //not equal to
                        filterString = "<> '" + textBox1.Text + "'";
                        break;
                    case 3: //is greater than
                        filterString = "> '" + textBox1.Text + "'";
                        break;
                    case 4: //is greater than or equal to
                        filterString = ">= '" + textBox1.Text + "'";
                        break;
                    case 5: //is less than
                        filterString = "< '" + textBox1.Text + "'";
                        break;

                    default: // 6  //is less than or equal to
                        filterString = "<= '" + textBox1.Text + "'";
                        break;
                }

                
                ManageIssue missue = (ManageIssue)Application.OpenForms["ManageIssue"];
                query = query + filterString;
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();
                //mbooks.dataGridView1.DataSource = null;
                // mbooks.dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    
                    missue.dataGridView1.DataSource = dt;
                    missue.recordText.Text = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No Records Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                db.CloseConnection();
                // MessageBox.Show(Convert.ToString(result));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdvancedBookSearch_Issued__Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;

        }
        //cancel button
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
