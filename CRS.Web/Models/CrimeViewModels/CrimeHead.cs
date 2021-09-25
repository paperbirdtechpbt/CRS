using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDL.Web.Models.CrimeViewModels
{
    public class CrimeHead
    {
        public int id { get; set; }
        public int MSTCrimeTypeID { get; set; }
        public int MSTCrimeHeadTypeID { get; set; }
        public int MSTCrimeHeadID { get; set; }
        public string CrimeHeadName { get; set; }
        public string CrimeName { get; set; }
        public string CrimeHeadTypeName { get; set; }
        public string Value { get; set; }
        public int MSTCaseID { get; set; }
    }
}
