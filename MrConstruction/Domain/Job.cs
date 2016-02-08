using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain
{
    public class Job : IDbEntity, IActivatable
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Estimate { get; set; }

        public string Contractor { get; set; }

        public enum Status
        {
            ToDo,
            AwaitingEstimate,
            InProgress,
            PendingReview,
            Completed
        }

        public DateTime Deadline { get; set; }

        public Location Location { get; set; }

        public Project Project { get; set; }

        public bool Active { get; set; }

    }
}