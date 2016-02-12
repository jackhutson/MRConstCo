using Microsoft.AspNet.Identity;
using MrConstruction.Domain;
using MrConstruction.Domain.Identity;
using MrConstruction.Infrastructure;
using MrConstruction.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models {
    public class JobService {

        private JobRepository _jobRepo;

        private UserRepository _userRepo;

        private ProjectRepository _projectRepo;

        public JobService(JobRepository jobRepo, UserRepository userRepo, ProjectRepository projectRepo) {
            _jobRepo = jobRepo;
            _userRepo = userRepo;
            _projectRepo = projectRepo;
        }

        //checks db for job by job name 
        public bool CheckExists(string name) {
            return _jobRepo.CheckExists(name);
        }

        //Get Job Details
        public JobDetailDTO GetJobDetails(int id, string username) {

            var job = _jobRepo.Get(id);
            var users = _userRepo.GetUsers();

            var contractor = (from c in job
                           select c.Contractor).FirstOrDefault();

            var project = (from p in job
                           select p.Project).FirstOrDefault();

            return (from j in job
                    from u in users
                    where u.UserName == username
                    select new JobDetailDTO() {
                        Name = j.Name,
                        ProjectTitle = project.Title,
                        Estimate = (u.Roles.FirstOrDefault(r => r.RoleId == Role.Admin) != null) ? j.Estimate : (decimal?)null,
                        Deadline = j.Deadline,
                        Description = j.Description,
                        State = j.State,
                        Contractor = new ContractorUserDTO() {
                            Id = contractor.Id,
                            Name = contractor.Name,
                            Title = contractor.Title,
                            CompanyName = contractor.CompanyName,
                            Email = contractor.Email,
                            PhoneNumber = contractor.PhoneNumber,
                            PhoneNumber2 = contractor.PhoneNumber2
                        }
                    }).FirstOrDefault();
        }

        //Add a new job
        public void AddJob(NewJobBindingModel dto) {

            var job = new Job() {
                Name = dto.Name,
                Description = dto.Description,
                Estimate = dto.Estimate,
                ContractorId = dto.ContractorId,
                State = dto.State,
                Deadline = dto.Deadline,
                ProjectId = dto.ProjectId
            };

            _jobRepo.Add(job);
            _jobRepo.SaveChanges();
        }
    }
}