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
    public class LocationController : ApiController
    {
        public LocationService _locationServ;

        public LocationController(LocationService locationServ) {
            _locationServ = locationServ;
        }

        [HttpGet]
        public LocationDTO Get(int id) {
            return _locationServ.GetLocation(id);
        }
            

        [HttpPost]
        public IHttpActionResult Post(LocationDTO location) {
            _locationServ.EditLocation(location);

            if (ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
