namespace Library_Managment_System
{
    partial class crysView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bookissuancereport11 = new Library_Managment_System.bookissuancereport1();
            this.bookissuance1 = new Library_Managment_System.Report.bookissuance();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportas2 = new Library_Managment_System.Report.CrystalReportas();
            this.CrystalReportas1 = new Library_Managment_System.Report.CrystalReportas();
            this.CrystalReportas3 = new Library_Managment_System.Report.CrystalReportas();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReportas3;
            this.crystalReportViewer1.Size = new System.Drawing.Size(461, 356);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load_1);
            // 
            // crysView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 356);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "crysView";
            this.Text = "crysView";
            this.Load += new System.EventHandler(this.crysView_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private bookissuancereport1 bookissuancereport11;
        private Report.CrystalReportas CrystalReportas1;
        private Report.bookissuance bookissuance1;
        private Report.CrystalReportas CrystalReportas2;
        private Report.CrystalReportas CrystalReportas3;
    }
}