using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDL.Web.Models.CrimeViewModels
{
    public class CrimeType
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string CrimeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }


    }
}
