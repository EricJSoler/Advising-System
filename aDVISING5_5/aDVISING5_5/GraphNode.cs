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
    public class GraphNode
    {
        public GraphNode()
        {
        }

        public GraphNode(string department, string number, string nodeType)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.Read_PreReqDep_PreReqN_Ext_GroupID_By_DepID_NumID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DepID",department));
            cmd.Parameters.Add(new SqlParameter("@NumID", number));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();
            List<String> readDep = new List<String>();
            List<String> readNum = new List<String>();
            List<String> ext = new List<String>();
            List<String> group = new List<String>();
            while (reader.Read()) ///Pull in the table of pre-requisite for the course
            {
                readDep.Add(reader.GetValue(0).ToString());
                readNum.Add(reader.GetValue(1).ToString());
                ext.Add(reader.GetValue(2).ToString());
                group.Add(reader.GetValue(3).ToString());
            }

            int i = 0;
            foreach (String element in readDep)
            {
                Console.WriteLine(readDep[i]);
                Console.WriteLine(readNum[i]);
                Console.WriteLine(ext[i]);
                Console.WriteLine(group[i]);
                Console.WriteLine("------------");
                i++;
            }

            reader.Close();
        }


        List<GraphNode> children;
        int inDegree;
        string department;
        string number;
        string nodeType;
    }
}
