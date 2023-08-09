using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                float price = 0;
                float strikePrice = 0;
                for(int day = 1; day <= 21; day++) //1 to 21 days period
                {
                    DateTime checkInDate = DateTime.Now.AddDays(365 + day - 1);
                    
                    for(int adult = 1; adult <= 6; adult++)
                    {
                        if (day == 1 && adult == 1)
                        {
                            price = random.Next(50, 100);
                            strikePrice = random.Next(50, (int)price);
                        }

                        for (int children = 0; children <= 6; children++)
                        {
                            string combination = $"{adult}A{children}C";
                            price = day * (adult * price + children * price * 0.5f);

                            bool showStrikePrice = Convert.ToBoolean(random.Next(2));
                            if(showStrikePrice == true)
                            {
                                strikePrice = day * (adult * strikePrice + children * strikePrice * 0.5f);
                            }
                            else
                            {
                                strikePrice = 0;
                            }
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
    }
}
