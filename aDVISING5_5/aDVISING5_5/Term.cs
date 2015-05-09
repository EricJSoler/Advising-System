using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpAdvising
{
    
    /// <summary>
    /// Term serves to allow for information in courses to be organized more efficently it contains a list of ownedSections
    /// </summary>

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
