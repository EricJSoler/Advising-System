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
    public class Course
    {
        public Course(Course previousCourse)//Copy constructor started working on but I dont think i need it 
        {
            courseID = previousCourse.courseID;
            foreach (Term elementT in previousCourse.ownedTerms)
            {
                foreach(Section elementS in elementT.ownedSections)
                {

                }
            }
        }
        public Course()//Default constructor I know it should do something but I dont really know what so im just gonna create the stuff but empty for now cuz ya
        {
            ownedTerms = new List<Term>();
        }

        public Course(string name)
        {
            //THis was for error just temporary Eventually this will replace the function below but for now the stored procedure requires me to pass in two string when I only want to pass one since that is the input im recieveing
        }

        public Course(string numID, string dID)
        {
            ownedTerms = new List<Term>();
            courseID = numID;
            readDataForCourseName(dID, numID);
        }

        public string courseID;
        private string departmentID;
        private string NumberID;
        public List<Term> ownedTerms;


        public void readDataForCourseName(string dID, string nID)
        {
            SqlConnection myConnection = new SqlConnection("User ID = Algo;" + "Password = Alg0rithm; server = algo.database.windows.net;" + "database =Advising_20150405;"
                + "Connection Timeout = 30;");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Course.spOfferingRead_ByDepartmentIdAndNumberId";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DepartmentID", dID));
            cmd.Parameters.Add(new SqlParameter("@NumberID", nID));
            cmd.Connection = myConnection;

            reader = cmd.ExecuteReader();


            int counter = 0;
            while (reader.Read())
            {
                int count = reader.FieldCount;

                for (int i = 0; i < count; i++)
                {

                    string colName;
                    colName = reader.GetName(i);
                    string readValue = reader.GetValue(i).ToString();
                    if (colName == "IntervalID")
                    {
                        bool stillEmpty = true;
                        foreach (Term element in ownedTerms)
                        {
                            if (readValue == element.termID)
                            {
                                element.ownedSections.Add(new Section(reader.GetValue(++i).ToString()));
                                stillEmpty = false;
                            }
                        }
                        if (stillEmpty)
                        {
                            ownedTerms.Add(new Term(reader.GetValue(i).ToString()));
                            ownedTerms[counter].ownedSections.Add(new Section(reader.GetValue(++i).ToString()));
                            counter++;
                        }
                    }

                }

            }

            reader.Close();
            myConnection.Close();
        }
    }
}
