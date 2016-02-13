using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain {
    public class Upload: IDbEntity, IActivatable {

        public enum Classification {
            Picture,
            Blueprint
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Classification Type { get; set; }

        [InverseProperty("Uploads")]
        public Project Project { get; set; }

        [InverseProperty("Uploads")]
        public Portfolio Portfolio { get; set; }

        public bool Active { get; set; } = true;
    }
}