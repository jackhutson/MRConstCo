using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain {
    public class Project : IDbEntity, IActivatable {

        public enum Status {
            ToDo,
            AwaitingEstimate,
            InProgress,
            PendingReview,
            Completed
        }

        public int Id { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public Client Client { get; set; }
        public IList<Upload> Uploads { get; set; }
        public Status State { get; set; }
        public IList<Job> JobList { get; set; }
        public decimal Budget { get; set; }
        public DateTime EstStart { get; set; }
        public DateTime EstCompleted { get; set; }
    }
}