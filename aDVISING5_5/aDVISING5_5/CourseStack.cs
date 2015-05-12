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


    /// <summary>
    ///CourseStack temporary garbage code I was playing with but contains a function I dont want to delete yet 
    /// </summary>
    public class CourseStack
    {
        public CourseStack()
        {
            complete = false;

        }

        public CourseStack(string dep, string numID)
        {
            department = dep;
            numberID = numID;
            fillStack();
        }

        private void fillStack()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.read_nodeID_by_departmentID_numberID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DepartmentID", department));
            cmd.Parameters.Add(new SqlParameter("@NumberID", numberID));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();

            string readValue;
            while (reader.Read())
            {
                readValue = reader.GetValue(0).ToString();

            }
            reader.Close();    

        }

        private 

        


        string department;
        string numberID;
        bool complete;
        List<Course> cStack;
    }



}
