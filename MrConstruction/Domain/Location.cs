using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain
{
    public class Location : IDbEntity, IActivatable
    {

        public int Id { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public bool Active { get; set; } = true;

    }
}