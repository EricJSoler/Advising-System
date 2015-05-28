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
            PreReq pre = new PreReq();
            //Graph graph = new Graph();
            List<List<Match>> all = new List<List<Match>>();
            List<Course> qual;   
            string x;
            do {
                TimeFilter time = new TimeFilter();
                qual = pre.getQualifiedCourses();
                List<Match> recomended = time.buildMyScheduleFor(qual, "Fall", 3);
                all.Add(recomended);
                pre.updateCompleted(recomended);

                Console.WriteLine("Press 'q' to quit");
               // x = Console.ReadLine();
            } while (true);
            
            Console.WriteLine("sdf");

        }
    }
}

//TODO:: Update the time filter to let any on-line class be recommended