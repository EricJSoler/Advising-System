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
    /// <summary>
    /// This is the module currently being worked on and needs to build an object made up of courses that a student is qualified for
    /// </summary>
    public class PreReq
    {

        public PreReq()
        {
            program = "AAS-MCAIMS";
            subjectRequirements = new Dictionary<string, Subject>();
            courseGraph = new Graph();
            Dictionary<String, int> coursesPlacedInto = new Dictionary<String, int>();//TODO: recieve this from taylors input thing
            coursesPlacedInto.Add("MATH", 141);
            coursesPlacedInto.Add("ENGL", 101);
            courseGraph.coursesPlacedInto = coursesPlacedInto;
            findDepartments();

        }

        private void findDepartments()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.read_subjects_by_program";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@programID", program));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string readValue = reader.GetValue(0).ToString();
                try
                {
                    subjectRequirements.Add(readValue, new Subject(readValue));
                }
                catch (ArgumentException e)
                {
                    //Do Nothing wow science
                }
            }

            reader.Close();

            foreach (Subject element in subjectRequirements.Values)
            {
                foreach (Course ele in element.reqCourses.Values)
                {
                    courseGraph.insertCourse(ele.departmentID, ele.numberID);
                }
            }
            Console.WriteLine("Graph has been built");
        }

        public int getImportanceRating(string dep, string num)
        {
            int importance = 0;
            Subject temp;
            subjectRequirements.TryGetValue(dep, out temp);
            Course tempC;
            if (temp.reqCourses.TryGetValue(dep + num, out tempC))
                importance += 10;
            importance += courseGraph.occurenceCount(dep, num);
            switch (dep)
            {
                case "MATH":
                    importance += 55;
                    break;
                case "PHYS":
                    importance += 20;
                    break;
            }
            return importance;
        }


        public static string program;
        public Dictionary<string, Subject> subjectRequirements; ///SubjectRequirements is the list of the major related subjects inside each subject is a Course list containing the  Courses required for each department
        public Graph courseGraph;
    }
}
