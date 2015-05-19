using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    public static class Graph
    {
        public static void insert(string department, string number)
        {
            allNodes = new List<GraphNode>();
            GraphNode toBeInserted = new GraphNode(department, number, "COURSE"); //Should always be inserted 
        }

        public static List<GraphNode> allNodes;
    }
}
