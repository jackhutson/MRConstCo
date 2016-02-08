using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services
{
    public class JobDetailDTO
    {
        public string Name { get; set; }

        public Project Project { get; set; }

        public ContractorUser Contractor { get; set; }

        public decimal Estimate { get; set; }

        public string CompanyName { get; set; }

        public DateTime Deadline { get; set; }

        public string Description { get; set; }

        public Project.Status Status { get; set; }

    }
}