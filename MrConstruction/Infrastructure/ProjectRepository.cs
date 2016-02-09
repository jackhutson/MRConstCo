using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure {
    public class ProjectRepository : GenericRepository<Project> {
        public ProjectRepository(DbContext db) : base(db) { }

        public IQueryable<Project> GetProjects() {
            return from p in Table
                   where p.Active
                   select p;
        }

        public bool CheckExists(int id) {
            var check = from p in Table
                        where p.Id == id
                        select p;
            if(check != null) {
                return true;
            } 
            else {
                return false;
            }
        }
    }
}
