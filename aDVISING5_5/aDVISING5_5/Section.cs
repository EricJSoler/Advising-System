using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    
   
   /// <summary>
    ///  Secion contains more specific information about the courses i.e. a List of times the course will be scheduled. The database hasnt been updated to contain that specific of information so sectionID is what is being used as the comparison in the time filter because it just stores the time the course is being offered
   /// </summary>

    public class Section
    {
        public Section()
        {
            daySchedule = new List<Times>();
        }
        public Section(string name)
        {
            sectionID = name;
            daySchedule = new List<Times>();
        }

        public List<Times> daySchedule;
        public string sectionID;

    }
}
