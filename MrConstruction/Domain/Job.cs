using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain
{
    public class Job : IDbEntity, IActivatable {

        public int Id { get; set; }

        public bool Active { get; set; } = true;

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Estimate { get; set; }

        public string ContractorId { get; set; }

        [ForeignKey("ContractorId")]
        public virtual ApplicationUser Contractor { get; set; }

        public Project.Status State { get; set; }

        public DateTime Deadline { get; set; }
        
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}