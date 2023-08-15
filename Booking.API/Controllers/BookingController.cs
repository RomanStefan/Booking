using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Booking.Core.Models;

namespace Booking.API.Controllers
{
    public class BookingController : ApiController
    {

        [HttpGet]
        public IHttpActionResult SearchAvailability(RequestObject requestObject)
        {
            #region Guard Clauses
            if (requestObject == null)
                return BadRequest("The content of the request cannot be null");
            #endregion


            List<Offer> offers = new List<Offer>();
            return Content(HttpStatusCode.Created, offers);
        }
    }
}
