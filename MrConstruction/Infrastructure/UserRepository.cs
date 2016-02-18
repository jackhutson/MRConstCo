using MrConstruction.Domain;
using MrConstruction.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MrConstruction.Infrastructure {
    public class UserRepository {

        private ApplicationDbContext _db;

        public UserRepository(DbContext db) {
            _db = (ApplicationDbContext)db;
        }

        public IQueryable<ApplicationUser> GetUsers() {
            return _db.Users.AsQueryable();
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

        public IQueryable<ApplicationUser> GetAdmin() {
            return from r in _db.Roles
                   from ru in r.Users
                   from u in _db.Users
                   where r.Name == Role.Admin && ru.UserId == u.Id
                   select u;
        }

        public ApplicationUser GetSpecificContractor(string id) {
            return (
                   from u in _db.Users
                   where u.Id == id
                   select u).FirstOrDefault();
        }


        public ApplicationUser GetByUserName(string name) {
            return (from u in _db.Users
                    where u.UserName == name
                    select u).FirstOrDefault();
        }

        public void SaveChanges()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbError)
            {
                var firstError = dbError.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }
    }
}