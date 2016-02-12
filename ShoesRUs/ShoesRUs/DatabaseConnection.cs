using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesRUs
{
    class DatabaseConnection
    {
        public static readonly string dbconnect = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source = " + Application.StartupPath + @"\ShoesRUsDB.accdb";

        /*

            DO NOT USE THE CODE BELOW!

            CHECK THE REGISTER FORM AS EXAMPLE!


        */

        //OleDbConnection dbCon = new OleDbConnection(dbconnect);

        /*
        //SELECT specified data from the database with no WHERE criteria
        public OleDbDataReader getData(string table, string selectedColumn)
        {
            dbCon.ConnectionString = DatabaseConnection.dbconnect;
            OleDbCommand dbCmd = dbCon.CreateCommand();

            dbCmd.CommandText = "SELECT @selectedColumn FROM @table";
            dbCmd.Parameters.AddWithValue("selectedColumn", selectedColumn);
            dbCmd.Parameters.AddWithValue("table", table);

            dbCon.Open();
            OleDbDataReader dbDR = dbCmd.ExecuteReader();
            dbCon.Close();

            return dbDR;
        }

        //SELECT specified data from the database with WHERE criteria specified
        public OleDbDataReader getData(string table, string selectedColumn, string whereColumn, string whereData)
        {
            dbCon.ConnectionString = DatabaseConnection.dbconnect;
            OleDbCommand dbCmd = dbCon.CreateCommand();

            dbCmd.CommandText = "SELECT @selectedColumn FROM @table WHERE @whereColumn = @whereData";
            dbCmd.Parameters.AddWithValue("selectedColumn", selectedColumn);
            dbCmd.Parameters.AddWithValue("table", table);
            dbCmd.Parameters.AddWithValue("whereColumn", whereColumn);
            dbCmd.Parameters.AddWithValue("whereData", whereData);

            dbCon.Open();
            OleDbDataReader dbDR = dbCmd.ExecuteReader();
            dbCon.Close();

            return dbDR;
        }

        //UPDATE specified data in the database with WHERE criteria specified
        public void updateData(string table, string setData, string whereColumn, string whereData)
        {
            dbCon.ConnectionString = DatabaseConnection.dbconnect;
            OleDbCommand dbCmd = dbCon.CreateCommand();

            dbCmd.CommandText = "UPDATE @table SET @setData WHERE @whereColumn = @whereData";
            dbCmd.Parameters.AddWithValue("table", table);
            dbCmd.Parameters.AddWithValue("setData", setData);
            dbCmd.Parameters.AddWithValue("whereColumn", whereColumn);
            dbCmd.Parameters.AddWithValue("whereData", whereData);

            dbCon.Open();
            int rowsChanged = dbCmd.ExecuteNonQuery();
            dbCon.Close();
        }

        //INSERT data into the specified table of the database using the specified columns and data
        public void insertData(string table, string valueColumn, string valueData)
        {
            dbCon.ConnectionString = DatabaseConnection.dbconnect;
            OleDbCommand dbCmd = dbCon.CreateCommand();

            dbCmd.CommandText = "INSERT INTO " + table + "VALUES (" + valueData + ")";
            //dbCmd.Parameters.AddWithValue("table", table);
            //dbCmd.Parameters.AddWithValue("valueColumn", valueColumn);
            //dbCmd.Parameters.AddWithValue("valueData", valueData);

            dbCon.Open();
            int rowsChanged = dbCmd.ExecuteNonQuery();
            dbCon.Close();
        }
        */
    }
}
