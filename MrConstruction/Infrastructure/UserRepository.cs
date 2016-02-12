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

        public ApplicationUser GetUserById(string Id) {
            return (from u in _db.Users
                   where u.Id == Id
                   select u).FirstOrDefault();
        }

        public IQueryable<ApplicationUser> GetContractors() {
            return from r in _db.Roles
                   from ru in r.Users
                   from u in _db.Users
                   where r.Name == Role.Contractor && ru.UserId == u.Id
                   select u;
        }
    }
}