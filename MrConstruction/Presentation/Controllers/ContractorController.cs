using MrConstruction.Domain.Identity;
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
    public class ContractorController : ApiController {

        private ContractorService _contractorService;

        public ContractorController(ContractorService contractorService) {
            _contractorService = contractorService;
        }

        [HttpGet]
        [Route("api/contractor/{id}")]
        public ContractorUserDTO Get(string id) {
            return _contractorService.GetContractorForEdit(id);
        }




        [Authorize(Roles = Role.Admin)]
        public IList<ContractorUserDTO> GetContractors() {
            var cs = _contractorService.GetContractors();
            return cs;
        }
    }
}
