using MrConstruction.Services;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MrConstruction.Presentation.Controllers
{
    public class JobsController : ApiController
    {
        private JobService _jobService;
        private ProjectService _projectService;

        public JobsController(JobService jobService, ProjectService projectService) {
            _jobService = jobService;
            _projectService = projectService;  
        }

        [HttpGet]
        public JobDetailDTO GetJobDetails(int id)
        {
           return _jobService.GetJobDetails(id, User.Identity.Name);
        }

        [HttpPost]
        [Route("api/projectDetails/addjob")]
        public IHttpActionResult addJob(JobDetailDTO job, int id) {
            if (ModelState.IsValid && _projectService.CheckExists(id)) {
                return Ok(_jobService.AddJob(new JobDetailDTO() {
                    Name = job.Name,
                    Description = job.Description,
                    Estimate = job.Estimate,
                    Contractor = job.Contractor,
                    State = job.State,
                    Deadline = job.Deadline,
                    Project = job.Project
                }, id, job.Contractor.Id));
            }
            return BadRequest();
        }
    }
}

