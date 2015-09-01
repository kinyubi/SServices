using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Suncrest.ShippingServices.Models;

namespace Suncrest.ShippingServices.Controllers
{
    public class CostsController : ApiController
    {
        [Route("costs")]
        public IEnumerable<ShippingCost> Get()
        {
            return ShippingCosts.GetAll();
        }

        [Route("costs/{zone:length(1)}/{weight:decimal}")]
        public IHttpActionResult Get(string zone, decimal weight)
        {
            ShippingCost rate = ShippingCosts.GetOne(zone,weight);
            if (rate == null)
            {
                return NotFound();
            }
            return Ok(rate);
        }
    }
}
