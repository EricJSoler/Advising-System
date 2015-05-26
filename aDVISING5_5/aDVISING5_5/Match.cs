using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    /// <summary>
    /// Match simply holds the department id and number id for a course this will most likely be used for output
    /// </summary>
    public class Match
    {
        public Match()
        {
            sectionOptions = new List<Section>();
        }

        public Match(string dep, string num)
        {
            departmentID = dep;
            numberID = num;
            sectionOptions = new List<Section>();
        }
        public Match(Match a)
        {
            sectionOptions = new List<Section>();
            departmentID = a.departmentID;
            numberID = a.numberID;
            importance = a.importance;

            
        }

     public string departmentID;
     public string numberID;
     public List<Section> sectionOptions;
     public int importance;
       
    }
}
