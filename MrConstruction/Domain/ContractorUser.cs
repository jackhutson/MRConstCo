using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain {
    public class ContractorUser : ApplicationUser {

        public string Name { get; set; }
        public string CompanyName { get; set; }
        public IList<Job> JobList { get; set; }
        public string PhoneNumber2 { get; set; }
    }
}