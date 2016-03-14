using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ShoesRUs
{
    class Contact
    {
        OleDbConnection myConn = new OleDbConnection();

        public void sendMessage(string name, string email, string custNo, string ordNo, string category, string subject, string description)
        {
            myConn.ConnectionString = DatabaseConnection.dbconnect;
            myConn.Open();

            OleDbCommand myCmd = myConn.CreateCommand();

            myCmd.CommandText = "INSERT INTO Message (Name, Email, CustomerNo, OrderNo, Category, Subject, Description) VALUES (@Name, @Email, @CustomerNo, @OrderNo, @Category, @Subject, @Description)";

            myCmd.Parameters.AddWithValue("Name", name);
            myCmd.Parameters.AddWithValue("Email", email);
            myCmd.Parameters.AddWithValue("CustomerNo", custNo);
            myCmd.Parameters.AddWithValue("OrderNo", ordNo);
            myCmd.Parameters.AddWithValue("Category", category);
            myCmd.Parameters.AddWithValue("Subject", subject);
            myCmd.Parameters.AddWithValue("Description", description);


            int rowsChanged = myCmd.ExecuteNonQuery();


            myConn.Close();

        }

        public int checkMessage(string name, string email, string custNo, string ordNo, string category, string subject, string description)
        {
            int check = 0;

            myConn.ConnectionString = DatabaseConnection.dbconnect;
            myConn.Open();

            OleDbCommand myCmd = myConn.CreateCommand();


            myCmd.CommandText = "SELECT COUNT(*) FROM Message  "
                                                          + " Where Name = @Name AND Email = @Email AND CustomerNo = @CustomerNo AND OrderNo = @OrderNo AND Category = @Category AND Subject = @Subject AND Description = @Description";
            myCmd.Parameters.AddWithValue("Name", name);
            myCmd.Parameters.AddWithValue("Email", email);
            myCmd.Parameters.AddWithValue("CustomerNo", custNo);
            myCmd.Parameters.AddWithValue("OrderNo", ordNo);
            myCmd.Parameters.AddWithValue("Category", category);
            myCmd.Parameters.AddWithValue("Subject", subject);
            myCmd.Parameters.AddWithValue("Description", description);

            check = (int)myCmd.ExecuteScalar();

            myConn.Close();
            return check;
        }

    }
}
