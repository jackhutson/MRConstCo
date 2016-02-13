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

        public void Post(NewPortfolioBindingModel port) {
            _portfolioServ.MakePortfolio(port);
        }
    }
}
