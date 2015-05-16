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
            subjectRequirements = new List<Subject>();
            findDepartments();

        }

        private void findDepartments()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.read_subjects_by_program";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@programID",program));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                string readValue = reader.GetValue(0).ToString();
                if(!subjectAlreadyAdded(readValue))
                {
                    subjectRequirements.Add(new Subject(readValue));
                }
            }

            reader.Close();

            Console.WriteLine("we here");
         
            
        }


        
        private bool subjectAlreadyAdded(string test)
        {
            foreach(Subject element in subjectRequirements)
            {
                if (element.department == test)
                    return true;
            }
            return false;
        }

     
      public static string program;
      public List<Subject> subjectRequirements; ///SubjectRequirements is the list of the major related subjects inside each subject is a Course list containing the  Courses required for each department
    }
}
