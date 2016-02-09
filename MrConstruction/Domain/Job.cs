using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain
{
    public class Job : IDbEntity, IActivatable
    {

        public int Id { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Estimate { get; set; }

        public ApplicationUser Contractor { get; set; }

        public Project.Status State { get; set; }

        public DateTime Deadline { get; set; }

        public Project Project { get; set; }

    }
}