using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models {
    public class ProjectDTO {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public IList<UploadDTO> Uploads { get; set; }
        public UploadDTO BeforePicture { get; set; }
        public UploadDTO AfterPicture { get; set; }
        public Project.Status State { get; set; }
        public IList<JobListDTO> JobList { get; set; }
        public decimal Budget { get; set; }
        public DateTime EstStart { get; set; }
        public DateTime EstCompleted { get; set; }

    }
}