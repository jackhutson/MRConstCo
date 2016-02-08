using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models {
    public class ProjectDTO {

        public enum Status {
            ToDo,
            AwaitingEstimate,
            InProgress,
            PendingReview,
            Completed
        }


        public string Description { get; set; }
        public ClientDTO Client { get; set; }
        public IList<UploadDTO> Uploads { get; set; }
        public Status State { get; set; }
        public IList<JobDTO> JobList { get; set; }
        public decimal Budget { get; set; }
        public DateTime EstStart { get; set; }
        public DateTime EstCompleted { get; set; }
    }
}