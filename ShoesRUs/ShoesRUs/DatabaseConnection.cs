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
        //Database Path on the Local Machine
        public static readonly string dbconnect = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source = " + Application.StartupPath + @"\ShoesRUsDB.accdb";
    }
}
