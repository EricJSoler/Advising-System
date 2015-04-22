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




            //////var XML = new XmlSerializer(typeof(List<Quarter>));
            //////return (List<Quarter>)XML.Deserialize(stream);

            int num_classes = 3;
            List<string> completedCourses = new List<string>();
            completedCourses.Add("MATH& 150");
            completedCourses.Add("MATH& 144");
            TimeFilter Test = new TimeFilter(num_classes);
        }
    }
}
