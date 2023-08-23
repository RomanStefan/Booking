using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Core.Models;

namespace Booking.InsertData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> annexSerices = ReadAnnexServicesFromFile();
            Random random = new Random();

            foreach (string service in annexSerices)
            {
                int basePrice = 0;
                int baseStrikePrice = 0;
             
                for(int day = 1; day <= 21; day++) //1 to 21 days period
                {
                    DateTime checkInDate = DateTime.Now.AddDays(365 + day - 1);
                    
                    for(int adult = 1; adult <= 6; adult++)
                    {
                        if (day == 1 && adult == 1)
                        {
                            basePrice = random.Next(50, 100);
                            baseStrikePrice = random.Next(50, (int)basePrice);
                        }

                        for (int children = 0; children <= 6; children++)
                        {
                            
                            float price = 0;
                            float strikePrice = 0;

                            string combination = $"{adult}A{children}C";
                            price = day * (adult * basePrice + children * basePrice * 0.5f);

                            bool showStrikePrice = Convert.ToBoolean(random.Next(2));
                            if(showStrikePrice == true)
                            {
                                strikePrice = day * (adult * baseStrikePrice + children * baseStrikePrice * 0.5f);
                            }
                            else
                            {
                                strikePrice = 0;
                            }

                            var offer = new Offer();
                            offer.CheckInDate = checkInDate;
                            offer.StayDurationNights = day;
                            offer.PersonCombination = combination;
                            offer.ServiceCode = service;
                            offer.Price = price;
                            offer.PricePerAdult = basePrice;
                            offer.PricePerChild = children == 0 ? 0 : basePrice * 0.5f;
                            offer.StrikePrice = strikePrice;
                            offer.StrikePricePerAdult = strikePrice == 0 ? 0 : baseStrikePrice;
                            offer.StrikePricePerChild = strikePrice == 0 ? 0 : baseStrikePrice * 0.5f;
                            offer.ShowStrikePrice = showStrikePrice;

                            RunStoredProcedure("SP_Offers_Save", offer);
                        }
                    }
                }
            }
        }

        private static List<string> ReadAnnexServicesFromFile()
        {
            List<string> annexServices = new List<string>();

            using(StreamReader sr = new StreamReader("D:\\Tutorials\\Booking\\Booking.InsertData\\AnnexServices.txt"))
            {
                string service; 
                while ((service = sr.ReadLine()) != null)
                {
                    annexServices.Add(service);
                }
            }

            return annexServices;
        }

        public static void RunStoredProcedure(string procedureName, object parameters = null)
        {
            string connectionString = "data source=localhost;initial catalog=Trupanion;Integrated Security=True;MultipleActiveResultSets=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Query(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
