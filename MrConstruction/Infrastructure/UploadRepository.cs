using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure {
    public class UploadRepository:GenericRepository<Upload> {
        public UploadRepository(DbContext db) : base(db) { }
    }
}