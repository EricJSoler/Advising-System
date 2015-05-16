using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
   public class CourseGraph
    {
      public CourseGraph()
       {
           adj = new int[MATRIXSIZE, MATRIXSIZE];
          courses = new List<GraphNode>();
       }

       public int addNode(string department, string numberID)
       {
           if (department == "-1")
           {
               return -1;
           }
           bool alreadyHaveIt = false;
                      
           foreach (GraphNode element in courses)
           {
               if (element.department == department && element.number == numberID)
               {
                       alreadyHaveIt = true;
                       return element.row;
               }
           }
           int i = courses.Count;

           ///TODO: if this class doesnt have any pre-reqs or are the pre-reqs are already completed we need to end this recursion

           if (!(alreadyHaveIt))
           {
               GraphNode nodeToAdd = new GraphNode(department, numberID);
               
               

               nodeToAdd.row = i;
               courses.Add(nodeToAdd);


               //Read the pre-reqs here then call the function on itself
               int requirementIndex;
               string dep;
               string num;
               Console.WriteLine("enter pre-req dep");
               dep = Console.ReadLine();
               Console.WriteLine("enter pre-req num");
               num = Console.ReadLine();
               

               requirementIndex = addNode(dep, num);
               if(requirementIndex!= -1)
               adj[i, requirementIndex] = 1;
               return i;

           }
           return -1;          
       }



       public int [,] adj;
       const int MATRIXSIZE = 100;
       public List<GraphNode> courses;
    }
}






