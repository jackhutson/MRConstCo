using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure {
    public class ClientRepository : GenericRepository<Client>{

        public ClientRepository(DbContext db) : base (db) { }
    }
}