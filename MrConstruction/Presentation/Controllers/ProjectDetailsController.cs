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
    public class ProjectDetailsController : ApiController
    {
        public ProjectService _projectServ;
        public ProjectDetailsController(ProjectService projectServ) {
            _projectServ = projectServ;
        }
        public ProjectDTO Get(int id) {
            return _projectServ.GetOneProject(id);
        }
    }
}
