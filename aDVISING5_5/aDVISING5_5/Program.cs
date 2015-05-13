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
    public class Program
    {
        static void Main(string[] args)
        {

            SQLHANDLER.start();
            

            ///Recieve all this from the user
            String recievedDegree;///TODO:For our final product recievedDegree and quarterOfEnrollment will be coming in most likely from a windows form application for now we will just input them into the console
            String quarterOfEnrollment;
            math = new Course("144", "MATH");//these are the courses a student is qualified to take in their respective fields
            chemistry = new Course("141", "CHEM");
            english = new Course("98", "ENGL");

           // recievedDegree = Console.ReadLine();
            //quarterOfEnrollment = Console.ReadLine();
            PreReq wow = new PreReq();
            TimeFilter test = new TimeFilter(3);
          
        }


        public static Course math;
        public static Course chemistry;
        public static Course english;

        
    }
}

