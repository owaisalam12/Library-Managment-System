using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class ReportCupboardWise : Form
    {
        public ReportCupboardWise()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportCupboardWise_View_ cupView = new ReportCupboardWise_View_();
            cupView.combQuery = comboBox1.Text;
            //MessageBox.Show("" + athView.combQuery);
            this.Hide();
            cupView.ShowDialog();
        }

        private void ReportCupboardWise_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
