using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    /// <summary>
    /// Graph class will hold all the required courses in order to complete a degree in a dictionary. Relationships between courses will be represented by an adjacency matrix 
    /// </summary>
    public class Graph
    {
        Graph()
        {
            allCourses = new Dictionary<int, GraphNode>();
        }

        /// <summary>
        /// Build will intake the departmentID and numberID of a course then proceed to build the graph for that course and all of its pre-requisites until it reaches a course the student is qualified for
        /// </summary>
        /// <param name="department"></param>
        /// <param name="number"></param>
        public void build(string department, string number)
        {
            
        }

        /// <summary>
        /// fidQualifiedCourses() will traverse through the adjacency matrix and search for the courses a student is currently qualified for. It will then store this in a List<Course> qualified</Course> and return this value to be sent to the time filter 
        /// </summary>
        /// <returns></returns>
        public List<Course> findQualifiedCourses()
        {
            List<Course> qualified = new List<Course>();

            return qualified;
        }
        /// <summary>
        /// update Completed will intake a List<Course> recommended </Course> that have been completed and will update the graph to mark these courses as completed
        /// </summary>
        /// <param name="recommended"></param>
        public void updateCompleted(List<Course> recommended)
        {

        }



        /// <summary>
        /// allCourses is a dictionary of GraphNode using integers as keys. The integer key for each entry in the dictionary will represent what row in the ajacency matrix information about the course can be found
        /// </summary>
        Dictionary<int, GraphNode> allCourses;

        /// <summary>
        /// adj is a 3 dimensional List matrix. Each the rows of the matrix will be used to store information for a course from the allCourses dictionary. Columns Will be used to represent Pre-Requisites for the course in a given row. Width will be used to represent the different possible combinations of taking different courses
        /// i.e. [Course][Pre-Reqs][Combinations] 
        /// </summary>
        List<List<List<bool>>> adj;

    }
}
