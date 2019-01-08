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
    public partial class ReportBorrowerWise : Form
    {
        public ReportBorrowerWise()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReportBorrowerWise_Load(object sender, EventArgs e)
        {
            try
            {
                database db = new database();
                string query = "SELECT name FROM tblemp;";
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
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportBorrowerWise_View_ borView = new ReportBorrowerWise_View_();
            borView.combQuery = comboBox1.Text;
            //MessageBox.Show("" + athView.combQuery);
            this.Hide();
            borView.ShowDialog();
        }
    }
}
