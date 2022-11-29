using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPoem.Application.Contracts.Dtos
{
   
    public class author
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class poem
    {
        public string author { get; set; }
        public string title { get; set; }
        public string[] paragraphs { get; set; }
    }

}
