using Booking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Interfaces
{
    public interface IBookingRepository
    {
        List<Offer> SearchAvailability(DateTime DateForm, int Duration, string PersonCombination);
    }
}
