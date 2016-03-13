using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesRUs
{
    class User
    {
        private bool loggedIn = false;
        private int custID;
        private string custTitle, custName, custDOB, custGender, custEmail, custPhone, custAddNo, custAddSt, custAddCit, custAddCou, custPoCo, custCaTy, custCaNo, custCaCVV, custCaName, custCaEx;
        private bool admin = false;

        public void Get()
        {

        }

        public void Update()
        {

        }

        public void Clear()
        {
            loggedIn = false;
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
