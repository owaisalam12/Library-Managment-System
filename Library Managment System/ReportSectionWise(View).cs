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
    public partial class ReportSectionWise_View_ : Form
    {
        public ReportSectionWise_View_()
        {
            InitializeComponent();
        }
        public string combQuery;
        private void ReportSectionWise_View__Load(object sender, EventArgs e)
        {
            SQLiteConnection con;
            con = new SQLiteConnection("Data Source=./database/database.sqlite;datetimeformat = CurrentCulture;");
            ReportAuthorWise rptAuth = new ReportAuthorWise();
            // MessageBox.Show("" + rptAuth.authorwiseParameter);
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * from issue1 where deptname='" + combQuery + "'", con);
            ReportDocument cr = new ReportDocument();
            cr.Load(Application.StartupPath + "\\Report\\bookissuance.rpt");
            viewDataSet ds = new viewDataSet();
            try
            {
                da.Fill(ds.issue1);
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
