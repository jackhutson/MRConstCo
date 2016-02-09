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

        public JobsController(JobService jobService)
        {
            _jobService = jobService;    
        }

        [HttpGet]
        public JobDetailDTO Get()
        {
           return _jobService.GetJobDetails();
        }
    }
}

