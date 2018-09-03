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
    public partial class page : Form
    {
        public page()
        {
            InitializeComponent();
        }
        database db = new database();
        private void page_Load(object sender, EventArgs e)
        {
            try
            {

                string query = "SELECT tblbook.bookid AS ID , tblbook.oldaccessionno AS AccNo, tblbook.City AS CAN,tblbook.Typeid AS CallNo,tblbook.Regid AS CupboardNo, tblbook.Name AS Book_Name, tblauthor.name AS Author_Name, tblpublisher.name AS Publisher_Name, tblbook.Edition, tblcatagory.Desc AS Book_Catagory,tblbook.noofbooks AS Quantity, tblbook.Status FROM (((tblauthor INNER JOIN tblbook ON tblauthor.authorid = tblbook.authorid) INNER JOIN tblcatagory ON tblbook.catagoryid = tblcatagory.catagoryid) INNER JOIN tblpublisher ON tblbook.pubid = tblpublisher.pubid) LEFT JOIN tblissued ON tblbook.bookid = tblissued.bookid;";
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                db.OpenConnection();
                var result = myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(myCommand);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns[0].Width = 35;
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[5].Width = 200;
                dataGridView1.Columns[6].Width = 110;
                dataGridView1.Columns[7].Width = 110;
                dataGridView1.Columns[9].Width = 55;
                db.CloseConnection();
                //  MessageBox.Show("Rows Added: {0}", result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

