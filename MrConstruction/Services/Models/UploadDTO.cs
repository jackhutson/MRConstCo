using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models {
    public class UploadDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
    }
}