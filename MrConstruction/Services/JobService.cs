using MrConstruction.Domain.Identity;
using MrConstruction.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models
{
    public class JobService
    {
        private JobRepository _jobRepo;
        private UserRepository _userRepo;

        public JobService(JobRepository jobRepo, UserRepository userRepo) {
            _jobRepo = jobRepo;
            _userRepo = userRepo;
        }

        public JobDetailDTO GetJobDetails(int id, string username) {

            return (from j in _jobRepo.Get(id)
                    from u in _userRepo.GetUsers()
                    where u.UserName == username
                    select new JobDetailDTO() {
                        Deadline = j.Deadline,
                        Description = j.Description,
                        Estimate = (u.Roles.FirstOrDefault(r => r.RoleId == Role.Admin)!= null) ? j.Estimate : (decimal?)null,
                        Name = j.Name,
                        Project = j.Project,
                        State = j.State,
                        Contractor = new ContractorUserDTO() {
                            Name = j.Contractor.Name,
                            CompanyName = j.Contractor.CompanyName
                        }
                    }).FirstOrDefault();                    
        } 
    }
}