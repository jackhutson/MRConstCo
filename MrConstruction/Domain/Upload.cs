using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain {
    public class Upload: IDbEntity, IActivatable {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}