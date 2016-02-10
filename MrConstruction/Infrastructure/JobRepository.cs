using MrConstruction.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure
{
    public class JobRepository : GenericRepository<Job>
    {
        public JobRepository(DbContext db) : base(db) { }

        //check to see if job exists by job name
        public bool CheckExists(string name) {

            var job = from j in Table
                      where j.Name == name
                      select j;
            
            if(job != null) {
                return true;
            } else {
                return false;
            }
        }
    }
}



