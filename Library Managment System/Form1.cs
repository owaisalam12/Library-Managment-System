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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            
            if ((username == "Admin")&&(password == "farooqi"))
            {
                MessageBox.Show("Login Succesfull", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                mdi_userParent mdParent = new mdi_userParent();
                mdParent.FormClosed += new FormClosedEventHandler(mdi_FormClosed);
                mdParent.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

            
        }
        private void mdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Admin";
            textBox1.Enabled = false;
            this.ActiveControl = textBox2;
           // textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    button1.PerformClick();
            //}
        }
    }
}
