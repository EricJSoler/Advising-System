using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
   public class GraphNode: CourseGraph 
    {
        public GraphNode() { }

        public GraphNode(string dep, string num){
            department = dep;
            number = num;
             
        }

        public int row;
        public string department;
        public string number;
    }
}
