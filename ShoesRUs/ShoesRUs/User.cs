using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ShoesRUs
{
    class User
    {
        //User Data
        private int custID;
        private string custTitle, custName, custDOB, custGender, custEmail, custPhone, custAddNo, custAddSt, custAddCit, custAddCou, custPoCo, custCaTy, custCaNo, custCaCVV, custCaName, custCaEx;
        private bool admin = false;

        //Update the User Data
        public void Update(int custID)
        {
            OleDbConnection dbCon = new OleDbConnection(DatabaseConnection.dbconnect);

            dbCon.ConnectionString = DatabaseConnection.dbconnect;
            OleDbCommand dbCmd = dbCon.CreateCommand();

            dbCmd.CommandText = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";
            dbCmd.Parameters.AddWithValue("CustomerID", custID);

            dbCon.Open();
            OleDbDataReader reader = dbCmd.ExecuteReader();

            while (reader.Read())
            {
                this.custID = Convert.ToInt32(reader[0]);
                custTitle = reader[1].ToString();
                custName = reader[2].ToString();
                custDOB = reader[3].ToString();
                custGender = reader[4].ToString();
                custEmail = reader[5].ToString();
                custPhone = reader[6].ToString();
                custAddNo = reader[7].ToString();
                custAddSt = reader[8].ToString();
                custAddCit = reader[9].ToString();
                custAddCou = reader[10].ToString();
                custPoCo = reader[11].ToString();
                custCaTy = reader[12].ToString();
                custCaNo = reader[13].ToString();
                custCaCVV = reader[14].ToString();
                custCaName = reader[15].ToString();
                custCaEx = reader[16].ToString();
                admin = Convert.ToBoolean(reader[18]);
            }
            reader.Close();

        }

        //Clear the User Data
        public void Clear()
        {
            custID = -999;
            custTitle = null;
            custName = null;
            custDOB = null;
            custGender = null;
            custEmail = null;
            custPhone = null;
            custAddNo = null;
            custAddSt = null;
            custAddCit = null;
            custAddCou = null;
            custPoCo = null;
            custCaTy = null;
            custCaNo = null;
            custCaCVV = null;
            custCaName = null;
            custCaEx = null;
            admin = false;
        }
    }
}
