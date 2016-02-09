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

        public JobService(JobRepository jobRepo) {
            _jobRepo = jobRepo;
        }

        public JobDetailDTO GetJobDetails() {
            return (from j in _jobRepo.GetJobDetails()
                    select new JobDetailDTO()
                    {
                        Contractor = j.Contractor,
                        CompanyName = j.Contractor.CompanyName,
                        Deadline = j.Deadline,
                        Description = j.Description,
                        Estimate = j.Estimate,
                        Name = j.Name,
                        Project = j.Project,
                        Status = j.State
                    }).FirstOrDefault();
                    
        } 
    }
}