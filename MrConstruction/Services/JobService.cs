using Microsoft.AspNet.Identity;
using MrConstruction.Domain;
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
        private ProjectRepository _projectRepo;
        private ApplicationUserManager _appUserRepo;

        public JobService(JobRepository jobRepo, UserRepository userRepo, ProjectRepository projectRepo, ApplicationUserManager appUserRepo) {
            _jobRepo = jobRepo;
            _userRepo = userRepo;
            _projectRepo = projectRepo;
            _appUserRepo = appUserRepo;
        }

        //checks db for job by job name 
        public bool CheckExists(string name) {
            return _jobRepo.CheckExists(name);
        }

        //Get Job Details
        public JobDetailDTO GetJobDetails(int id, string username) {

            return (from j in _jobRepo.Get(id)
                    from u in _userRepo.GetUsers()
                    where u.UserName == username
                    select new JobDetailDTO() {
                        Deadline = j.Deadline,
                        Description = j.Description,
                        Estimate = (u.Roles.FirstOrDefault(r => r.RoleId == Role.Admin)!= null) ? j.Estimate : (decimal?)null,
                        Name = j.Name,
                        ProjectId = j.ProjectId, 
                        State = j.State,
                        Contractor = new ContractorUserDTO() {
                            Name = j.Contractor.Name,
                            CompanyName = j.Contractor.CompanyName
                        }
                    }).FirstOrDefault();                    
        } 

        //Add a new job
        public JobDetailDTO AddJob(JobDetailDTO dto) {

            var contractor = _appUserRepo.FindById(dto.Contractor.Id);

            var job = new Job() {
                Name = dto.Name,
                Description = dto.Description,
                Estimate = dto.Estimate,
                Contractor = contractor,
                State = dto.State,
                Deadline = dto.Deadline,
                ProjectId = dto.ProjectId
            };

            _jobRepo.Add(job);
            _jobRepo.SaveChanges();

            return new JobDetailDTO() {
                Name = job.Name,
                Description = job.Description,
                Estimate = job.Estimate,
                Contractor = new ContractorUserDTO() {
                    Name = job.Contractor.Name,
                    CompanyName = job.Contractor.CompanyName
                },
                State = job.State,
                Deadline = job.Deadline,
                ProjectId = job.ProjectId
            };
        }
    }
}