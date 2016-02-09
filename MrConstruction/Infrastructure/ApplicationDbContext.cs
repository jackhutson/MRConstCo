using MrConstruction.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MrConstruction.Infrastructure {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        } 

        public IDbSet<Client> Clients { get; set; }

        public IDbSet<Job> Jobs { get; set; }
        
        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Portfolio> Portfolios { get; set; }
        
        public IDbSet<Project> Projects { get; set; }

        public IDbSet<Upload> Uploads { get; set; }
    }
}