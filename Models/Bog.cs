using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amanda_Eks.models
{
    public class Bog : Publikation
    {
        public string Type { get; set; }
        public string Titel { get; set; }
        public string Forfatter { get; set; }
        public List<string> Genrer { get; set; }
        public int PublikationsAar { get; set; }
        public string Udgiver { get; set; }
        public double MatchPercentage { get; set; }
        public string ISBN { get; set; }
        public int AntalSider { get; set; }
        public int Kapitler { get; set; }
    }
}
