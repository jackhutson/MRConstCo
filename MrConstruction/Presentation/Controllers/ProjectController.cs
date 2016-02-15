using MrConstruction.Domain;
using MrConstruction.Domain.Identity;
using MrConstruction.Services;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace MrConstruction.Presentation.Controllers
{
    public class ProjectController : ApiController
    {
        public ProjectService _projectServ;

        public UploadService _uploadServ;

        public ProjectController(ProjectService projectServ, UploadService uploadServ) {
            _projectServ = projectServ;
            _uploadServ = uploadServ;
        }

        [HttpGet]
        public IList<ProjectDTO> Get() {
            return _projectServ.ListProjects();
        }

        [HttpGet]
        public ProjectDTO Get(int id) {
            return _projectServ.GetOneProject(id);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public IHttpActionResult Post(NewProjectDTO newProject) {
            _projectServ.AddNewProject(newProject);
            if (ModelState.IsValid && _projectServ.CheckExists(newProject.Title)) {
                return Ok();
            } else {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/project/{id}/upload")]
        public async Task<IHttpActionResult> Post(int id) {
            var formData = await this.ReadFile();

            var file = formData.Files[0];
            var dst = HttpContext.Current.Server.MapPath("~/Public/" + file.RemoteFileName);
            file.FileInfo.MoveTo(dst);
            var type = formData.FormData["type"][0];
            var dto = new UploadDTO() {
                Name = file.RemoteFileName,
                Url = Url.Content("~/Public/" + file.RemoteFileName),
                Type = type
            };

            _uploadServ.SaveUpload(id, dto);
            return Ok();
       
        }

        //public async Task<IHttpActionResult> Post() {

        //    var formData = await this.ReadFile();

        //    var dst = HttpContext.Current.Server.MapPath("~/Public/");
        //    var file = formData.Files[0];
        //    file.FileInfo.MoveTo(dst + file.RemoteFileName);

        //    var projectId = int.Parse(formData.FormData["projectId"][0]);
        //}
    }
}