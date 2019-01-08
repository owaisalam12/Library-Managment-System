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
    public partial class ReportCategoryWise_View_ : Form
    {
        public ReportCategoryWise_View_()
        {
            InitializeComponent();
        }
        public string combQuery;
        private void ReportCategoryWise_View__Load(object sender, EventArgs e)
        {
            SQLiteConnection con;
            con = new SQLiteConnection("Data Source=./database/database.sqlite;datetimeformat = CurrentCulture;");
            ReportAuthorWise rptAuth = new ReportAuthorWise();
            // MessageBox.Show("" + rptAuth.authorwiseParameter);
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * from querybook where Book_Catagory='" + combQuery + "'", con);
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
