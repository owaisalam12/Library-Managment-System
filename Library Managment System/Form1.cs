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
            database db = new database();

            //insert into database
            //string query = "INSERT INTO users('username','password') VALUES (@username,@password)";
            //SQLiteCommand myCommand = new SQLiteCommand(query,db.myConnection);
            //db.OpenConnection();
            //myCommand.Parameters.AddWithValue("@username",username);
            //myCommand.Parameters.AddWithValue("@password",password);
            //var result = myCommand.ExecuteNonQuery();
            //db.CloseConnection();
            //MessageBox.Show("Rows Added: {0}", result.ToString());
            //db.CloseConnection();
            // MessageBox.Show("Rows Added: {0}", result.ToString());

            //select from database

            string query = "SELECT * FROM users WHERE username='" + username + "' and password='" + password + "'";
            SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);
            db.OpenConnection();
            // myCommand.Parameters.AddWithValue("@username",username);
            //myCommand.Parameters.AddWithValue("@password",password);
            SQLiteDataReader result = myCommand.ExecuteReader();
            int count = 0;
            // if (result.HasRows)
            //{
            while (result.Read())
            {

                count++;
                //MessageBox.Show(result.GetString(0));
            }
            if (count == 1)
            {
                MessageBox.Show("Logged In ");
                this.Hide();
                mdi_userParent mdParent = new mdi_userParent();
                mdParent.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
            // }
            db.CloseConnection();
            //MessageBox.Show("Rows Added: {0}", result.ToString();
        }


    }
}
