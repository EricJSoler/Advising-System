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

            Graph graph = new Graph();
            List<PrereqRow> rows = graph.getCoursePrereq("CS", "110");
            Dictionary<String, int> coursesPlacedInto = new Dictionary<String, int>();
            coursesPlacedInto.Add("ENGL", 101);
            graph.coursesPlacedInto = coursesPlacedInto;
            graph.build(rows, 0);

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

