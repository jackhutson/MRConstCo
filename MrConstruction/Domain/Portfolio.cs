using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain {
    public class Portfolio : IDbEntity, IActivatable {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Upload> Uploads { get; set; }
        public Upload BeforePicture { get; set; }
        public Upload AfterPicture { get; set; }
        public Project Project { get; set; }
        public bool Active { get; set; } = true;
    }
}