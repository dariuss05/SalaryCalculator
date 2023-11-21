using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculator
{
    public class Angajat
    {
        public int nr_crt { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string functie { get; set; }
        public int salar_baza { get; set; }
        public int spor { get; set; }
        public int premii_brute { get; set; }
        public int total_brut { get; set; }
        public int brut_impozabil { get; set; }
        public int retineri { get; set; }
        public int virat_card { get; set; }
        public int taxa_id { get; set; }
        public Taxa taxa { get; set; }

        
    }

    public class Taxa
    {
        public int id { get; set; }
        public float impozit { get; set; }
        public float cas { get; set; }
        public float cass { get; set; }
    }
}