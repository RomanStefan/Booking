using Booking.Core.Interfaces;
using Booking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public List<Offer> SearchAvailability(DateTime DateForm, int Duration, string PersonCombination)
        {
            throw new NotImplementedException();
        }
    }
}
