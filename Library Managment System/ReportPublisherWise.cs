﻿using System;
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
    public partial class ReportPublisherWise : Form
    {
        public ReportPublisherWise()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReportPublisherWise_Load(object sender, EventArgs e)
        {
            try
            {
                database db = new database();
                string query = "SELECT name FROM tblpublisher;";
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
        //OK
        private void button1_Click(object sender, EventArgs e)
        {
            ReportPublisherWise_View_ pubView = new ReportPublisherWise_View_();
            pubView.combQuery = comboBox1.Text;
            //MessageBox.Show("" + athView.combQuery);
            this.Hide();
            pubView.ShowDialog();
        }
        //exit
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
