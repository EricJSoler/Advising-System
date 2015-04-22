using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    public class Term
    {
        public Term()
        {
            ownedSections = new List<Section>();
        }
        public Term(string name)
        {
            termID = name;
            ownedSections = new List<Section>();

        }

        public string termID;
        public List<Section> ownedSections;
    }
}
