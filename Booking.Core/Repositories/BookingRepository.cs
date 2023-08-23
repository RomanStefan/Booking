using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Booking.Core.Interfaces;
using Booking.Core.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Booking.Core.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly string connectionString;
        private readonly string searchAvailabilityStoredProcedure;

        public BookingRepository()
        {
            connectionString = "data source=localhost;initial catalog=Trupanion;Integrated Security=True;MultipleActiveResultSets=True";
            searchAvailabilityStoredProcedure = "SP_Offers_SearchAvailability";
        }

        public List<Offer> SearchAvailability(DateTime DateForm, int Duration, string PersonCombination)
        {
            List<Offer> availabilityOffers = new List<Offer>();
            
            var parameters = new StoredProcedureParameter_SearchAvailability
            {
                CheckInDate = DateForm.Date,
                StayDurationNights = Duration,
                PersonCombination = PersonCombination
            };
            

            using (var connection = new SqlConnection(connectionString))
            {
                availabilityOffers =  connection.Query<Offer>(searchAvailabilityStoredProcedure, parameters , commandType: CommandType.StoredProcedure).ToList();
            }

            return availabilityOffers;
        }
    }
}
