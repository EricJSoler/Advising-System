﻿using System;
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
            coursesPlacedInto.Add("ENGL", 98);
            coursesPlacedInto.Add("CS", 131);
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

            //foreach (Subject element in subjectRequirements.Values)
            //{
            //    foreach (Course ele in element.reqCourses.Values)
            //    {
            //        courseGraph.insertCourse(ele.departmentID, ele.numberID);
            //    }
            //}

            //test values
            courseGraph.insertCourse("MATH", "163");
            courseGraph.insertCourse("PHYS", "243");
            courseGraph.insertCourse("CS", "132");
            courseGraph.insertCourse("CS", "131");
            Console.WriteLine("Graph has been built");




        }


        public List<Course> getQualifiedCourses()
        {
            List<Course> qual = new List<Course>();
            qual = courseGraph.findQualifiedCourses();
            foreach(Course element in qual)
            {
                element.importance = getImportanceRating(element);
            }
            return qual;
        }



        public int getImportanceRating(Course passed)
        {
            int importance = 0;
            Subject temp;
            subjectRequirements.TryGetValue(passed.departmentID, out temp);
            Course tempC;
            if (temp != null)
            {
                if (temp.reqCourses.TryGetValue(passed.departmentID + passed.numberID, out tempC))
                    importance += 10;
            }
            importance += courseGraph.occurenceCount(passed.departmentID, passed.numberID);
            switch (passed.departmentID)
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
