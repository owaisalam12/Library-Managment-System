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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Library_Managment_System
{
    public partial class entirelistofbooks : Form
    {
        public entirelistofbooks()
        {
            InitializeComponent();
        }

        private void entirelistofbooks_Load(object sender, EventArgs e)
        {
            SQLiteConnection con;
            con = new SQLiteConnection("Data Source=./database/database.sqlite;datetimeformat = CurrentCulture;");

            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * from querybook", con);
            ReportDocument cr = new ReportDocument();
            cr.Load(Application.StartupPath + "\\Report\\listofbooks.rpt");
            viewDataSet ds = new viewDataSet();
            try
            {
                da.Fill(ds.querybook);
                cr.SetDataSource(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
