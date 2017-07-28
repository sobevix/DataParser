using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser.Models
{
    public class DataLine
    {
        public enum field
        {
            Guid,
            Val1,
            Val2,
            Val3,
        };

        public string DataGuid { get; set; }
        public string Val1 { get; set; }
        public string Val2 { get; set; }
        public string Val3 { get; set; }
        
        
    }
}
