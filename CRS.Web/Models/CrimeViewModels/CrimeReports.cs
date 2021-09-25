using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDL.Web.Models.CrimeViewModels
{
    public class CrimeReports
    {
        public int id { get; set; }

        public int crimetype { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }

        public string q1 { get; set; }
        public string q2 { get; set; }
        public string q3 { get; set; }
        public string q4 { get; set; }
        public string q5 { get; set; }
        public string q6 { get; set; }
        public string q7 { get; set; }
        public string q8 { get; set; }
        public string q9 { get; set; }
        public string q10 { get; set; }
    }
}
