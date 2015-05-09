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

     public string departmentID;
     public string numberID;
     public List<Section> sectionOptions;
       
    }
}
