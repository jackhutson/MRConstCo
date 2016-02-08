using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure {
    public class ContractorRepository {

        private ApplicationDbContext _db;

        public ContractorRepository(DbContext db) {
            _db = (ApplicationDbContext)db;
        }
    }
}