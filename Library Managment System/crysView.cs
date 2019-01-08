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
    public partial class crysView : Form
    {
        public crysView()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void crysView_Load(object sender, EventArgs e)
        {
            SQLiteConnection con;
            con = new SQLiteConnection("Data Source=database.sqlite;datetimeformat = CurrentCulture;");

            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * from test3", con);
            ReportDocument cr = new ReportDocument();
            //CrystalReport4 cr = new CrystalReport4();

           cr.Load(Application.StartupPath + "\\Report\\CrystalReportas.rpt");
            //string appPath = Application.StartupPath;
            //string reportPath = @"Report\CrystalReportas.rpt";
            //cr.Load(appPath + reportPath);
            viewDataSet ds = new viewDataSet();
            try
            {
                da.Fill(ds.test3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex); 
            }
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void CrystalReport41_InitReport(object sender, EventArgs e)
        {

        }
    }
}
