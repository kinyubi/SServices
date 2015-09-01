using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Suncrest.ShippingServices.Models;

namespace Suncrest.ShippingServices.Controllers
{
    public class ZonesController : ApiController
    {
        [Route("zones")]
        public IEnumerable<ZipZone> Get()
        {
            return ShippingZones.GetAll();
        }

        [Route("zones/{zip:length(5)}")]
        public IHttpActionResult Get(string zip)
        {
            ZipZone zipZone = ShippingZones.GetOne(zip);
            if (zipZone == null)
            {
                return NotFound();
            }
            return Ok(zipZone);
        }
    }
}
