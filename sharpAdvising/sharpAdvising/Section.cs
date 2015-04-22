using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
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
