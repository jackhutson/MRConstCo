using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models {
    public class ContractorUserDTO {

        public string Name { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public IList<JobDetailDTO> JobList { get; set; }
    }
}