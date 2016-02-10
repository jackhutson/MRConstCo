using MrConstruction.Domain;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services
{
    public class JobDetailDTO
    {
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public ContractorUserDTO Contractor { get; set; }

        public decimal? Estimate { get; set; }

        public DateTime Deadline { get; set; }

        public string Description { get; set; }

        public Project.Status State { get; set; }

    }
}