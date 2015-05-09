using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;//added 2/25
using System.IO;

namespace sharpAdvising
{
    /// <summary>
    /// SQLHandler handles the connection with the database it currently has two connections one for the "Pretty Database" and one for the "Sandbox database" that we are playing in trying to make pre-req filter work
    /// </summary>
    public static class SQLHANDLER
    {
       
        public static void start()
        {
            myConnection = new SqlConnection("User ID = Algo;" + "Password = Alg0rithm; server = algo.database.windows.net;" + "database =Advising_20150405;"
    + "Connection Timeout = 30;");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            myConnection2 = new SqlConnection("User ID = Algo;" + "Password = Alg0rithm; server = algo.database.windows.net;" + "database =Test_0506;"
   + "Connection Timeout = 30;"+"MultipleActiveResultSets=true;");
            try
            {
                myConnection2.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

           
        }



        public static SqlConnection myConnection;
        public static SqlConnection myConnection2;
    }
}
