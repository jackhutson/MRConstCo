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
        public ProjectController(ProjectService projectServ) {
            _projectServ = projectServ;
        }
        public IList<ProjectDTO> Get() {
            return _projectServ.ListProjects();
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
