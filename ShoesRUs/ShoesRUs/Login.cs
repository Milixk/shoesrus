using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ShoesRUs
{
    class Login
    {
        private User user;
        private bool loggedIn = false;

        public void setLoggedIn(int custID)
        {
            user = new User();
            user.Update(custID);
            loggedIn = true;
        }

        public void logOut()
        {
            user.Clear();
            loggedIn = false;
        }

        public int loggingIn(string email, string password)
        {
            int customerID = -999;

            OleDbConnection dbCon = new OleDbConnection(DatabaseConnection.dbconnect);

            dbCon.ConnectionString = DatabaseConnection.dbconnect;
            OleDbCommand dbCmd = dbCon.CreateCommand();

            dbCmd.CommandText = "SELECT CustomerID FROM Customer WHERE CustomerEmail = @CustomerEmail AND CustomerPassword = @CustomerPassword";
            dbCmd.Parameters.AddWithValue("CustomerEmail", email);
            dbCmd.Parameters.AddWithValue("CustomerPassword", password);

            dbCon.Open();
            OleDbDataReader reader = dbCmd.ExecuteReader();

            while (reader.Read())
            {
                customerID = Convert.ToInt32(reader[0]);                
            }
            reader.Close();

            return customerID;
        }

        public bool checkLoggedIn()
        {
            return loggedIn;
        }
    }
}
