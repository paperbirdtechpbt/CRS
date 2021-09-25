using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDL.Web.Models.CrimeViewModels
{
    public class CaseSaveUpdate
    {
        public int id { get; set; }

        public int crimetype { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public int MSTCrimeTypeID { get; set; }
        public string Name { get; set; }
        public string CrimeName { get; set; }
        public int MSTCrimeHeadTypeID { get; set; }
        public string CaseNo { get; set; }
        public string ComplainerName { get; set; }
        public string ComplainerContactNo { get; set; }
        public int MSTStatusId { get; set; }

        public string MSTStatus { get; set; }
        public string ComplainerAddress { get; set; }
        public string JsonData { get; set; }
        public string CrimeHeadName { get; set; }
        public string Value { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}
