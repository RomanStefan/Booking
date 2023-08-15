using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Core.Models
{
    public class RequestObject
    {
        public DateTime DateForm { get; set; }
        public int Duration { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildrens { get; set; }
        public Credentials Credentials{ get; set; } 
    }
}