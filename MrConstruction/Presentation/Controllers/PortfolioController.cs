using MrConstruction.Domain.Identity;
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
    public class PortfolioController : ApiController
    {
        public PortfolioService _portfolioServ;

        public PortfolioController(PortfolioService portfolioServ) {
            _portfolioServ = portfolioServ;
        }

        public IList<PortfolioDTO> Get() {
            return _portfolioServ.DisplayPortfolio(); 
        }

        [HttpPost]
        [Route("api/portfolio/{id}")]
        public void Post(int id, NewPortfolioBindingModel port) {
            if (ModelState.IsValid) {
                //Check if state is valid
                _portfolioServ.MakePortfolio(id, port);
            }
            
        }
       
        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        [Route("api/portfolio/delete/{id}")]
        public IHttpActionResult DeletePortfolio(int id) {
            _portfolioServ.DeletePortfolio(id);
            if (ModelState.IsValid) {
                return Ok();
            } else {
                return BadRequest();
            }
        }
    }
}
