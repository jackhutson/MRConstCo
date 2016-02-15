using MrConstruction.Services;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MrConstruction.Presentation.Controllers {
    public class ClientController : ApiController {

        private ClientService _clientServ;

        public ClientController(ClientService clientServ) {
            _clientServ = clientServ;
        }

        [HttpGet]
        public ClientDTO Get(int id) {
            return _clientServ.GetClient(id);
        }

        [HttpPost]
        public IHttpActionResult Post(ClientDTO client) {
            _clientServ.EditClient(client);
            if (ModelState.IsValid) {
                return Ok();
            } else {
                return BadRequest();
            }
        }
    }
}
