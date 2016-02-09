using MrConstruction.Domain;
using MrConstruction.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure {
    public class UserRepository {

        private ApplicationDbContext _db;

        public UserRepository(DbContext db) {
            _db = (ApplicationDbContext)db;
        }

        public IQueryable<ApplicationUser> GetUsers() {
            return _db.Users;
        }

        public IQueryable<ApplicationUser> GetContractors() {
            return from u in _db.Users
                   where u.Roles.FirstOrDefault(r => r.RoleId == Role.Contractor) != null
                   select u;
        }
    }
}