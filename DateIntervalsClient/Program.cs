using DateIntervalsClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DateIntervalsClient
{
    class Program
    {
        public static string APP_PATH = "http://localhost:56862";

        public static int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1.Сохранить интервал:");
            Console.WriteLine("2.Вывести интервалы:");
            Console.WriteLine("3.Выход:");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        public static void GetIntervals()
        {
            string controllerRoute = "/api/DateIntervals/GetIntervals";

            Console.WriteLine();
            Console.WriteLine("Введите первую дату:");
            string startDate = Console.ReadLine();
            Console.WriteLine("Введите вторую дату:");
            string endDate = Console.ReadLine();

            var Intervals = SendInterval(new DateInterval
            {
                StartDate = startDate,
                EndDate = endDate
            }, controllerRoute);

            foreach (var Interval in Intervals)
            {
                Console.WriteLine();
                Console.WriteLine(Interval.StartDate.Remove(10));
                Console.WriteLine(Interval.EndDate.Remove(10));

            }
        }

        public static void SaveInterval()
        {
            string controllerRoute = "/api/DateIntervals/Save";

            Console.WriteLine();
            Console.WriteLine("Введите первую дату:");
            string startDate = Console.ReadLine();
            Console.WriteLine("Введите вторую дату:");
            string endDate = Console.ReadLine();

            SendInterval(new DateInterval
            {
                StartDate = startDate,
                EndDate = endDate
            }, controllerRoute);

        }

        static List<DateInterval> SendInterval(DateInterval dateInterval, string route)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.PostAsJsonAsync(APP_PATH + route, dateInterval).Result;

                    var result = response.Content.ReadAsStringAsync().Result;
                    List<DateInterval> intervalsList = JsonConvert.DeserializeObject<List<DateInterval>>(result);
                    return intervalsList;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }
        }
        static void Main(string[] args)
        {

            int userInput = 0;
            do
            {
                userInput = ShowMenu();

                switch (userInput.ToString())
                {
                    case "1":
                        SaveInterval();
                        break;
                    case "2":
                        GetIntervals();
                        break;  
                }
            } while (userInput != 3);
            Console.Read();
        }
    }
}
    
