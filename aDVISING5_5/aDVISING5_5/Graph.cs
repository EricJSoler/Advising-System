using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    /// <summary>
    /// Graph class will hold all the required courses in order to complete a degree in a dictionary. Relationships between courses will be represented by an adjacency matrix 
    /// </summary>
    class Graph
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Graph()
        {
            allCourses = new Dictionary<String, GraphNode>();
            courseGrid = new List<List<List<bool>>>();
            gridDepth = 1;
        }

        /// <summary>
        /// Checks if the depth is the correct size for all lists
        /// </summary>
        /// <param name="depth">The current depth to check against</param>
        public void checkDepth(int depth)
        {
            if (gridDepth < depth) {
                gridDepth = depth;
                for (int i = 0; i < courseGrid.Count; i++) {
                    for (int j = 0; j < courseGrid[i].Count; j++) {
                        while (courseGrid[i][j].Count < gridDepth)
                            courseGrid[i][j].Add(false);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a single course to the adjacency matrix
        /// </summary>
        public void addCourseToGrid()
        {
            courseGrid.Add(new List<List<bool>>());
            for (int i = 0; i < courseGrid.Count; i++) {
                courseGrid[i].Add(new List<bool>());
                if (courseGrid.Count > 1 && i > 0)
                    courseGrid[courseGrid.Count - 1].Add(new List<bool>());
            }


            for (int i = 0; i < courseGrid.Count; i++) {
                for (int j = 0; j < courseGrid[i].Count; j++) {
                    while (courseGrid[i][j].Count < gridDepth)
                        courseGrid[i][j].Add(false);
                }
            }
        }

        /// <summary>
        /// Builds the graph with the griven list of required courses
        /// </summary>
        /// <param name="prereqRows">List of required courses</param>
        /// <param name="parentIndex">0 for first (for recursion)</param>
        public void build(List<PrereqRow> prereqRows, int parentIndex)
        {
            int path = 0;
            String depth = "1";
            foreach (PrereqRow row in prereqRows) {
                if (row.prereqDepartmentID == "MASTER")
                    continue;

                int index = 0;
                // Add course if not a duplicate
                try {
                    allCourses.Add(row.prereqDepartmentID + row.prereqNumberID, new GraphNode(row.prereqDepartmentID, row.prereqNumberID));
                    addCourseToGrid();
                    index = allCourses.Count - 1;
                }
                catch (ArgumentException e) {
                    //duplicate...
                    for (int i = 0; i < allCourses.Count; i++) {
                        if (allCourses.ElementAt(i).Key == row.prereqDepartmentID + row.prereqNumberID) {
                            index = i;
                            break;
                        }
                    }
                }

                List<PrereqRow> morePrereqs;
                morePrereqs = getCoursePrereq(row.prereqDepartmentID, row.prereqNumberID);
                build(morePrereqs, index);
                checkDepth(path + 1);
                if (row.type == "OR") {
                    courseGrid[parentIndex][index][path++] = true;
                    checkDepth(path + 1);
                }
                else {
                    if (row.groupID.Split('.').Count() < depth.Split('.').Count() ||
                        row.groupID.Split('.')[row.groupID.Split('.').Count() - 1] != depth.Split('.')[depth.Split('.').Count() - 1])
                        path++;

                    checkDepth(path + 1);
                    courseGrid[parentIndex][index][path] = true;
                }

                //if (row.type == "OR") {
                //    if (depth.Length < row.groupID.Length) {
                //        //new or level
                //        depth = row.groupID;
                //        courseGrid[parentIndex][index][path] = true;
                //        checkDepth(++path);
                //    }
                //    else if (depth.Length == row.groupID.Length) {
                //        if (depth == row.groupID) {
                //            depth = row.groupID;
                //            courseGrid[parentIndex][index][path] = true;
                //            checkDepth(++path);
                //        }
                //    }
                //    else if (depth.Length > row.groupID.Length) {
                //        path = row.groupID.Split('.').Count() - 1;
                //        depth = row.groupID;
                //        courseGrid[parentIndex][index][path] = true;
                //    }
                //}
                //else if (row.type == "AND") {
                //    depth = row.groupID;
                //    courseGrid[parentIndex][index][path] = true;
                //}
            }
        }

        /// <summary>
        /// Gets the list of courses required to take for the desired course
        /// </summary>
        /// <param name="departmentID">The courses department ID that you want the prereqs for</param>
        /// <param name="numberID">The courses number ID that you want the prereqs for</param>
        /// <returns></returns>
        public List<PrereqRow> getCoursePrereq(String departmentID, String numberID)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.Read_PreReqDep_PreReqN_Ext_GroupID_By_DepID_NumID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DepID", departmentID));
            cmd.Parameters.Add(new SqlParameter("@NumID", numberID));
            cmd.Connection = SQLHANDLER.myConnection2;

            reader = cmd.ExecuteReader();

            List<PrereqRow> prereqs = new List<PrereqRow>();
            int i = 0;
            while (reader.Read()) {
                prereqs.Add(new PrereqRow());
                prereqs[i].departmentID = departmentID;
                prereqs[i].numberID = numberID;
                prereqs[i].prereqDepartmentID = reader.GetValue(0).ToString();
                prereqs[i].prereqNumberID = reader.GetValue(1).ToString();
                prereqs[i].type = reader.GetValue(2).ToString();
                prereqs[i++].groupID = reader.GetValue(3).ToString();
            }
            reader.Close();

            return prereqs;
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
        public Dictionary<String, GraphNode> allCourses;

        /// <summary>
        /// courseGrid is a 3 dimensional List matrix. Each the rows of the matrix will be used to store information for a course from the allCourses dictionary. Columns Will be used to represent Pre-Requisites for the course in a given row. Width will be used to represent the different possible combinations of taking different courses
        /// i.e. [Course][Pre-Reqs][Combinations] 
        /// </summary>
        public List<List<List<bool>>> courseGrid;
        public int gridDepth;
    }
    /// <summary>
    /// The rows that the db tables return
    /// </summary>
    class PrereqRow
    {
        /// <summary>
        /// Represents the department of the MASTER course
        /// </summary>
        public String departmentID;
        /// <summary>
        /// Represents the course number of the MASTER course
        /// </summary>
        public String numberID;
        /// <summary>
        /// Represents the department of the prereq course
        /// </summary>
        public String prereqDepartmentID;
        /// <summary>
        /// Represents the course number of the prereq course
        /// </summary>
        public String prereqNumberID;
        /// <summary>
        /// The type of parent the prereq has (AND or OR)
        /// </summary>
        public String type;
        /// <summary>
        /// The group ID its parent has ex: 1.1.3
        /// </summary>
        public String groupID;
    }
}
