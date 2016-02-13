using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models {
    public class PortfolioDTO {
        public string Description { get; set; }
        public IList<UploadDTO> Uploads { get; set; }
        public UploadDTO BeforePicture { get; set; }
        public UploadDTO AfterPicture { get; set; }
        public ProjectDTO Project { get; set; }
    }
}