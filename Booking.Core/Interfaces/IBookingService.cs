using Booking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Interfaces
{
    public interface IBookingService
    {
        List<Offer> SearchAvailability(DateTime DateForm, int Duration, int NumberOfAdults, int NumberOfChildrens);
    }
}
