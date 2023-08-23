using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Models
{
    public class StoredProcedureParameter_SearchAvailability
    {
        public DateTime CheckInDate { get; set; }
        public int StayDurationNights { get; set; }
	    public string PersonCombination { get; set; }
    }
}
