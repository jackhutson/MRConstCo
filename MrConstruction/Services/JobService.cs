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

        public bool checkIfAdmin(string username) {

            var admins = _userRepo.GetAdmin();

            var user = (from u in admins
                        where u.UserName == username
                        select u).FirstOrDefault();

            if(user != null) {
                return true;
            }
            else {
                return false;
            }
        }

        //Get Job Details
        public JobDetailDTO GetJobDetails(int id, string username) {

            var job = _jobRepo.Get(id);

            var isAdminUser = checkIfAdmin(username);

            var contractor = (from c in job
                           select c.Contractor).FirstOrDefault();

            var project = (from p in job
                           select p.Project).FirstOrDefault();

            return (from j in job
                    select new JobDetailDTO() {
                        Id = j.Id,
                        Name = j.Name,
                        ProjectTitle = project.Title,
                        Estimate = isAdminUser ? j.Estimate : (decimal?)null,
                        Deadline = j.Deadline,
                        Description = j.Description,
                        State = j.State.ToString(),
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
                State = (dto.State == null) ? (Project.Status)Enum.Parse(typeof(Project.Status), "ToDo") : (Project.Status)Enum.Parse(typeof(Project.Status), dto.State),
                Deadline = dto.Deadline,
                ProjectId = dto.ProjectId
            };

            _jobRepo.Add(job);
            _jobRepo.SaveChanges();
        }

        public void MarkForReview(int id) {

            var job = _jobRepo.Get(id).FirstOrDefault();

            job.State = Project.Status.PendingReview;

            _jobRepo.SaveChanges();
        }

        public void EditJob(NewJobBindingModel dto) {

            var job = _jobRepo.Get(dto.Id).FirstOrDefault();

            job.Name = dto.Name;
            job.Estimate = dto.Estimate;
            job.Deadline = dto.Deadline;
            job.State = (dto.State == null) ? (Project.Status)Enum.Parse(typeof(Project.Status), "ToDo") : (Project.Status)Enum.Parse(typeof(Project.Status), dto.State);
            job.ContractorId = dto.ContractorId;
            job.Description = dto.Description;

            _jobRepo.SaveChanges();
        }

        public void DeleteJob(int id) {

            _jobRepo.Delete(id);
            _jobRepo.SaveChanges();
        }
    }
}