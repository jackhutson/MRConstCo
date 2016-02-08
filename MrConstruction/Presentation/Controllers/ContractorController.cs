using MrConstruction.Services;
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


    }
}
