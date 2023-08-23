using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Booking.Core.Interfaces;
using Booking.Core.Models;

namespace Booking.API.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public IHttpActionResult SearchAvailability(RequestObject requestObject)
        {
            #region Guard Clauses
            if (requestObject == null)
                return BadRequest("The content of the request cannot be null");
            #endregion

            if (!UserIsValid(requestObject.Credentials))
            {
                throw new HttpResponseException(CreateUnauthorizedResponse());
            };

            List<Offer> offers = bookingService.SearchAvailability(requestObject.DateForm, requestObject.Duration, requestObject.NumberOfAdults, requestObject.NumberOfChildrens);
            
            return Content(HttpStatusCode.Created, offers);
        }

        private bool UserIsValid(Credentials credentials)
        {
            var validUserName = ConfigurationManager.AppSettings["ApiUser_UserName"].ToString();
            var validPassword = ConfigurationManager.AppSettings["ApiUser_Password"].ToString();

            if (credentials.UserName.Equals(validUserName) && credentials.Password.Equals(validPassword))
                return true;

            return false;
        }

        private HttpResponseMessage CreateUnauthorizedResponse()
        {
            return new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("Invalid username or password")
            };
        }
    }
}
