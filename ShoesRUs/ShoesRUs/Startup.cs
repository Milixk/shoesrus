using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace ShoesRUs
{
    class Startup
    {
        public Startup()
        {
            DatabaseExist();
        }
        private void DatabaseExist()
        {
            if (File.Exists(Application.StartupPath + @"\ShoesRUsDB.accdb") == false)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Milixk/shoesrus/blob/master/ShoesRUsDB.accdb?raw=true", Application.StartupPath + @"\ShoesRUsDB.accdb");
                }
            }
            
        }
    }
}
