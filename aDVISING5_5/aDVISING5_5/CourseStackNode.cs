using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    //This builds off of the garbage CourseStack class that i was building just to mess with it will be changed soon
    public class CourseStackNode
    {
        public CourseStackNode()
        {

        }

        public CourseStackNode(string depID, string numID)
        {
            departmentID = depID;
            numberID = numID;
        }
            public string departmentID;
            public string numberID;
            public string Marker;
   
    }
}
