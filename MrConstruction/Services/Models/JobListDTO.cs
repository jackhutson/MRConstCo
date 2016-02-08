using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models {
    public class JobListDTO {
        public string Name { get; set; }
        public decimal Estimate { get; set; }
        public Project.Status State { get; set; }
        public DateTime Deadline { get; set; }

    }
}