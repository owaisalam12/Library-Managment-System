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
    public partial class ReportLanguageWise : Form
    {
        public ReportLanguageWise()
        {
            InitializeComponent();
        }

        private void ReportLanguageWise_Load(object sender, EventArgs e)
        {
            
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportLanguageWise_View_ lanView = new ReportLanguageWise_View_();
            lanView.combQuery = comboBox1.Text;
            //MessageBox.Show("" + athView.combQuery);
            this.Hide();
            lanView.ShowDialog();
        }
    }
}
