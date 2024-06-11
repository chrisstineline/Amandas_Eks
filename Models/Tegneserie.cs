using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amanda_Eks.models
{
    internal class Tegneserie : Publikation
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Rating { get; set; }
        public int Year { get; set; }

    }
}
