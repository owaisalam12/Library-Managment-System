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
    public partial class AdvancedBookSearch : Form
    {
        public AdvancedBookSearch()
        {
            InitializeComponent();
        }
        database db = new database();
        private void AdvancedBookSearch_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;

        }
        //cancel
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //search
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query;
                if (comboBox1.SelectedIndex == 0)//bookId
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.bookid  ";
                }
                else if (comboBox1.SelectedIndex == 1)//bookName
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.Name ";
                }
                else if (comboBox1.SelectedIndex == 2)//accNo
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.oldaccessionno  ";
                }
                else if (comboBox1.SelectedIndex == 3)//can
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.City  ";
                }
                else if (comboBox1.SelectedIndex == 4)//callNo
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.Typeid  ";
                }
                else if (comboBox1.SelectedIndex == 5)//cupboard
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.Regid  ";
                }
                else if (comboBox1.SelectedIndex == 6)//author
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblauthor.name  ";
                }
                else if (comboBox1.SelectedIndex == 7)//publisher
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblpublisher.name  ";
                }
                else if (comboBox1.SelectedIndex == 8)//edition
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.Edition  ";
                }
                else if (comboBox1.SelectedIndex == 9)//category
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblcatagory.Desc  ";
                }
                else if (comboBox1.SelectedIndex == 10)//quantity
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.noofbooks  ";
                }
                else //for 11 status
                {
                    query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM ((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid WHERE tblbook.Status  ";
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

                ManageBooks mbooks = (ManageBooks)Application.OpenForms["ManageBooks"];
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
                    mbooks.dataGridView1.DataSource = dt;
                    mbooks.recordText.Text = "";
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
    }
}
