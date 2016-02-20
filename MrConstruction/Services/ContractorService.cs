using Microsoft.AspNet.Identity;
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
        private ApplicationUserManager _appUserRepo;

        public ContractorService(UserRepository userRepo, ApplicationUserManager appUserRepo) {
            _userRepo = userRepo;
            _appUserRepo = appUserRepo;
        }

        public ContractorUserDTO GetContractorForEdit(string id) {

            var contractor = _userRepo.GetSpecificContractor(id);

            var dto = new ContractorUserDTO()
            {
                Id = contractor.Id,
                Name = contractor.Name,
                Title = contractor.Title,
                CompanyName = contractor.CompanyName,
                Email = contractor.Email,
                PhoneNumber = contractor.PhoneNumber,
                PhoneNumber2 = contractor.PhoneNumber2,
            };

            return dto;
        }

        public ContractorWithJobListDTO GetContractorWithJobs(string username) {

            var dto = (from c in _userRepo.GetByUserNameWithJobs(username)
                       select new ContractorWithJobListDTO() {
                           Id = c.Id,
                           Name = c.Name,
                           Title = c.Title,
                           CompanyName = c.CompanyName,
                           Email = c.Email,
                           PhoneNumber = c.PhoneNumber,
                           PhoneNumber2 = c.PhoneNumber2,
                           JobList = (from j in c.JobList
                                      select new JobListDTO() {
                                          Id = j.Id,
                                          Name = j.Name,
                                          Estimate = j.Estimate,
                                          State = j.State.ToString(),
                                          Deadline = j.Deadline
                                      }).ToList()
                       }).FirstOrDefault();

            return dto;
        }
        
        public void EditContractor(ContractorUserDTO edited)
        {
            var contractor = _userRepo.GetSpecificContractor(edited.Id);

            contractor.Name = edited.Name;
            contractor.Title = edited.Title;
            contractor.CompanyName = edited.CompanyName;
            contractor.Email = edited.Email;
            contractor.PhoneNumber = edited.PhoneNumber;
            contractor.PhoneNumber2 = edited.PhoneNumber2;

            _userRepo.SaveChanges();

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

        public void DeleteContractor(string id)
        {
            var contractor = _userRepo.GetUserById(id);
            _appUserRepo.Delete(contractor);
            _userRepo.SaveChanges();
        }
        
    }
}