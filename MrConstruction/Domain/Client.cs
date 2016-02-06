using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain {
    public class Client : IDbEntity, IActivatable {

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } = true;
    }
}