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

            string x;
            do
            {
                TimeFilter time = new TimeFilter();
               List<Match> recomended = time.buildMyScheduleFor(pre.getQualifiedCourses(), "Fall", 3);
               pre.updateCompleted(recomended);
                x = Console.ReadLine();
            } while (x != "end");
            for (int i = 0; i < 3; i++)
            {


            }
            Console.WriteLine("sdf");

        }
    }
}

//TODO:: Update the time filter to let any on-line class be recommended