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
            if (department == "MATH")
            {
                startingPoint = Program.math;
            }
            else if (department == "CHEM")
            {
                startingPoint = Program.chemistry;
            }
            else if (department == "ENGL")
            {
                startingPoint = Program.english;
            }
            else if (department == "PHYS")
            {
                startingPoint = new Course("114", "PHYS");
            }

            cStack = new List<CourseStackNode>();
            bool hadAStartingPoint = findStartNodeID();
            findGoalNodeID();
            if (hadAStartingPoint)
            {
                this.cStack.Add(new CourseStackNode(startingPoint.departmentID, startingPoint.numberID));
                fillStack(); //From here on
            }


        }

        public void findGoalNodeID()
        {
            goalNodeIDs = new List<string>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.read_nodeID_by_departmentID_numberID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DepartmentID", this.department));
            cmd.Parameters.Add(new SqlParameter("@NumberID", this.numberID));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();

            string readValue;
            while (reader.Read())
            {
                readValue = reader.GetValue(0).ToString();
                goalNodeIDs.Add(readValue);
            }
            reader.Close();    
          

        }

        public bool findStartNodeID()
        {
            startingNodeIDs = new List<string>();
          if(startingPoint != null)
          {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.read_nodeID_by_departmentID_numberID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DepartmentID", startingPoint.departmentID));
            cmd.Parameters.Add(new SqlParameter("@NumberID", startingPoint.numberID));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();

            string readValue;
            while (reader.Read())
            {
                readValue = reader.GetValue(0).ToString();
                startingNodeIDs.Add(readValue);
            }
            reader.Close();    
           
           return true;
          }
            return false;
        }

        private void fillStack()
        {
            string readDepartment = null;
            string nextNode = null;
            string readNumberID = null;
            nextNode = findNextNode(startingNodeIDs[0]);//
            while(!(goalNodeIDs.Contains(nextNode)))///TODO: Figure out how to deal with ands //6.1.1.1.1
            {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.read_departmentID_programID_by_nodeID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nodeID", nextNode));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();

            
            while (reader.Read())
            {
                readDepartment = reader.GetValue(0).ToString();
                readNumberID = reader.GetValue(1).ToString();
                cStack.Add(new CourseStackNode(readDepartment, readNumberID));
            }
            reader.Close();
            }

            nextNode = findNextNode(nextNode);
        }

        private string findNextNode(string node)
        {
            return node += ".1";
        }

       




        public string department;
        public string numberID;
        List<string> goalNodeIDs;
        bool complete;
        List<CourseStackNode> cStack;
        Course startingPoint;
        List<string> startingNodeIDs;
    }



}
