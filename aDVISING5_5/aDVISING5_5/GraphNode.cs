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
    /// Graph Node: Will be the nodes used in the Graph class list of allCourses. Relationships between GraphNodes will be represented by the adjacency matrix adj in the Graph class
    /// /// </summary>
    public class GraphNode
    {
        public GraphNode()
        { }

       /// <summary>
       /// This constructor will intake the departmnetID the numberID and what row in the adjacency matrix from the Graph class pre-requisite information for this Course will be stored
       /// </summary>
       /// <param name="depID"></param>
       /// <param name="numID"></param>
       /// <param name="rowValue"></param>
        public GraphNode(string depID, string numID, int rowValue)
        {
            departmentID = depID;
            numberID = numID;
            row = rowValue;
        }
    
        /// <summary>
        /// Row will indicate which row in the adjacency matrix of the graph holds the pre-requisite information of this course 
        /// </summary>
        public int row;
        /// <summary>
        /// Complete will store a boolean value indicating whether the corresponding course has been recommended.
        /// </summary>
        public bool completed;
        /// <summary>
        /// departmentID will store which department the course belongs too
        /// </summary>
        public string departmentID;
        /// <summary>
        /// numberID will store which number corresponds to the given course
        /// </summary>
        public string numberID;
    }


}
