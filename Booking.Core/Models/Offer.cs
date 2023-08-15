using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Models
{
    public class Offer
    {
        public DateTime CheckInDate { get; set; }
  	    public int StayDurationNights { get; set; }
  	    public string PersonCombination { get; set; }
  	    public string Service_Code { get; set; }
        public float Price { get; set; }
        public int PricePerAdult { get; set; }
        public float PricePerChild { get; set; }
        public float StrikePrice { get; set; }
        public int StrikePricePerAdult { get; set; }
        public float StrikePricePerChild { get; set; }
        public bool ShowStrikePrice { get; set; }
    }
}
