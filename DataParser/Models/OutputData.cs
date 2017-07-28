using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser.Models
{
    public class OutputData
    {
        public string DataGuid { get; set; }
        public int ValSum { get; set; }
        public bool IsDuplicateGuid { get; set; }
        public bool Val3LengthGreaterThanAverage { get; set; }
    }
}
