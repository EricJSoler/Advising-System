﻿using System;
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
    /// This is the module currently being worked on and needs to build an object made up of courses that a student is qualified for
    /// </summary>
    public class PreReq
    {

        public PreReq()
        {

            string depIDHighestMath;
            string numIDHighestMath;
            depIDHighestMath = Console.ReadLine();
            numIDHighestMath = Console.ReadLine();
            CourseStack first = new CourseStack(depIDHighestMath,numIDHighestMath, false);


            ////
            string num;
            string dep;
            Console.WriteLine("inpout department ID");
            dep = Console.ReadLine();

            Console.WriteLine("input number ID");
            num = Console.ReadLine();

            
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.read_by_dep_num";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DepartmentID", dep));
            cmd.Parameters.Add(new SqlParameter("@NumberID", num));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int fieldCount = reader.FieldCount;
                for(int i = 0; i < fieldCount; i++)
                {
                    string colName = reader.GetName(i);
                    string readValue = reader.GetValue(i).ToString();
                    Console.WriteLine("we here");
                }

            }

            reader.Close();
        }
    }
}
