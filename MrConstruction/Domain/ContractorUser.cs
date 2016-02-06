using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain {
    public class ContractorUser : ApplicationUser {

        public string Name { get; set; }
        public string CompanyName { get; set; }
        public Job Jobs { get; set; }
        public string PhoneNumber2 { get; set; }
    }
}