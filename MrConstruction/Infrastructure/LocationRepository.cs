using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure
{
    public class LocationRepository : GenericRepository<Location>
    {
        public LocationRepository(DbContext db) : base(db) { }
    }
}