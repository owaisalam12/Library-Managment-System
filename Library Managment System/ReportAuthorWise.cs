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
    public partial class ReportAuthorWise : Form
    {
        public ReportAuthorWise()
        {
            InitializeComponent();
        }
        public string authorwiseParameter;
        private void ReportAuthorWise_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.tblauthor' table. You can move, or remove it, as needed.
            this.tblauthorTableAdapter.Fill(this.databaseDataSet.tblauthor);
            try
            {
                database db = new database();
                string query = "SELECT name FROM tblauthor";
                db.OpenConnection();
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                SQLiteDataReader rdr = myCommand.ExecuteReader();
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr.GetValue(0).ToString());
                }
                db.CloseConnection();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            comboBox1.SelectedIndex=0;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //authorwiseParameter = comboBox1.Text.ToString();
            //authorwiseParameter = textBox1.Text;
            
            // this.Close();
            ReportAuthorWise_View_ athView = new ReportAuthorWise_View_();
            athView.combQuery = comboBox1.Text;
            //MessageBox.Show("" + athView.combQuery);
            this.Hide();
            athView.ShowDialog();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
