using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure {
    public class UploadRepository:GenericRepository<Upload> {
        public UploadRepository(DbContext db) : base(db) { }
        public Upload FindUploadById(int id) {
            return (from u in Table
                    where u.Id == id
                    select u).FirstOrDefault();
        }

        public IQueryable<Upload> FindUploadsByProjectId(int projectId) {
            return from u in Table
                   where u.Project.Id == projectId && u.Active
                   select u;
        }
    }
}