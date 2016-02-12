using MrConstruction.Domain.Identity;
using MrConstruction.Infrastructure;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MrConstruction.Services {
    public class ContractorService {

        private UserRepository _userRepo;

        public ContractorService(UserRepository userRepo) {
            _userRepo = userRepo;
        }

        [Authorize(Roles="Admin")]
        public IList<ContractorUserDTO> GetContractors() {
            var contractors = _userRepo.GetContractors();
            return (from c in contractors
                    select new ContractorUserDTO() {
                        Id = c.Id,
                        Name = c.Name,
                        Title = c.Title,
                        CompanyName = c.CompanyName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        PhoneNumber2 = c.PhoneNumber2
                    }).ToList();
        }
    }
}