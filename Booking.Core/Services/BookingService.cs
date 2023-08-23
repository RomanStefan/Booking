using Booking.Core.Interfaces;
using Booking.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public List<Offer> SearchAvailability(DateTime DateForm, int Duration, int NumberOfAdults, int NumberOfChildrens)
        {
            #region Guard Clauses
            if (DateForm == null || Duration == 0 || NumberOfAdults == 0)
            {
                return new List<Offer>();
            }
            #endregion

            string personsCombination = ConfigurationManager.AppSettings["PersonsCombination"]
                                            .Replace("{NumberOfAdults}", NumberOfAdults.ToString())
                                            .Replace("{NumberOfChildrens}", NumberOfChildrens.ToString());

            return bookingRepository.SearchAvailability(DateForm, Duration, personsCombination);

        }
    }
}
