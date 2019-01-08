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
    public partial class ReportDateWise : Form
    {
        public ReportDateWise()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportDateWise_Load(object sender, EventArgs e)
        {
            try
            {
                database db = new database();
                string query = "SELECT issueddaate,returndate FROM tblissued;";
                db.OpenConnection();
                SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
                SQLiteDataReader rdr = myCommand.ExecuteReader();
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr.GetValue(0).ToString());
                    comboBox2.Items.Add(rdr.GetValue(1).ToString());
                }
                db.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDateWise_View_ borView = new ReportDateWise_View_();
            borView.combQuery = comboBox1.Text;
            borView.combQuery2 = comboBox2.Text;

            //MessageBox.Show("" + athView.combQuery);
            this.Hide();
            borView.ShowDialog();
        }
    }
}
