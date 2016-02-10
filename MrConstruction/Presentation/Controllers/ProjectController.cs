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
    public class ProjectController : ApiController
    {
        public ProjectService _projectServ;
        public ProjectController(ProjectService projectServ) {
            _projectServ = projectServ;
        }

        [HttpGet]
        public IList<ProjectDTO> Get() {
            return _projectServ.ListProjects();
        }

        [HttpGet]
        public ProjectDTO Get(int id) {
            return _projectServ.GetOneProject(id);
        }
        //[HttpPost]
        //public IHttpActionResult Post(NewProjectDTO newProject) {
            //return _projectServ.AddNewProject(newProject);
        //}
    }
}
