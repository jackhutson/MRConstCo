using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Presentation.Models {
    public class NewJobBindingModel {

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Estimate { get; set; }

        public Project.Status State { get; set; }

        public string ContractorId { get; set; }

        public int ProjectId { get; set; }

        public DateTime Deadline { get; set; }
    }
}