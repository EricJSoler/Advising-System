using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    public class Quarter //This is the data type that will be deserialized from The Pre-requisite module
    {
        public int qNum;
        public List<string> courses;

        public Quarter()
        {

        }
        public int quarter
        {
            get { return qNum; }
        }

        public List<string> Courses
        {
            get { return courses; }
        }

    }
}
