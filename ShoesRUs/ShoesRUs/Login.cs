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
        //User Details
        private User user;
        //Logged In Status
        private bool loggedIn = false;


        //Set user to logged in and get details
        public void setLoggedIn(int custID)
        {
            user = new User();
            user.Update(custID);
            loggedIn = true;
        }


        //Logout the user
        public void logOut()
        {
            user.Clear();
            loggedIn = false;
        }

        //Check the user email and password on the system and return a true or false customer ID
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

        //Return the LoggedIn Status
        public bool checkLoggedIn()
        {
            return loggedIn;
        }
    }
}
