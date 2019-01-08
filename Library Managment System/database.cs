using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Library_Managment_System
{
    class database
    {
        public SQLiteConnection myConnection;
        public database()
        {
            
            myConnection = new SQLiteConnection("Data Source=./database/database.sqlite;datetimeformat = CurrentCulture;");
          
            if (!File.Exists("./database/database.sqlite")){
                SQLiteConnection.CreateFile("database.sqlite");
                //MessageBox.Show("database created");
            }
        }
        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}
