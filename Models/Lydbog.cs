using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amanda_Eks.models
{
    internal class Lydbog : Publikation
    {
        public string IndtaltAf { get; set; }
        public double LaengdeIMinutter { get; set; }
    }
}
