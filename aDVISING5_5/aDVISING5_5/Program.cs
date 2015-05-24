using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;
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

            
            Dictionary<String, int> coursesPlacedInto = new Dictionary<String, int>();//TODO: recieve this from taylors input thing
            coursesPlacedInto.Add("MATH", 141);
            coursesPlacedInto.Add("ENGL", 101);
            Graph graph = new Graph();
            graph.coursesPlacedInto = coursesPlacedInto;
            graph.insertCourse("MATH","163");

           // recievedDegree = Console.ReadLine();
            //quarterOfEnrollment = Console.ReadLine();
            //PreReq wow = new PreReq();
            //TimeFilter test = new TimeFilter(3);
            Console.WriteLine("sdf");
          
        }


        public static Course math;
        public static Course chemistry;
        public static Course english;

        
    }
}

