using MrConstruction.Presentation.Models;
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

        public JobsController(JobService jobService) {
            _jobService = jobService;  
        }

        [HttpGet]
        public JobDetailDTO GetJobDetails(int id)
        {
           return _jobService.GetJobDetails(id, User.Identity.Name);
        }

        [HttpPost]
        [Route("api/task")]
        public IHttpActionResult AddJob(NewJobBindingModel job) {
            _jobService.AddJob(job);
            if (ModelState.IsValid && _jobService.CheckExists(job.Name)) {
                return Ok();
            } else {
                return BadRequest();
            }
            
        }
    }
}

