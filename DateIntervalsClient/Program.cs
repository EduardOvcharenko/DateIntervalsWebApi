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
        private static string token;
        public static string APP_PATH = "http://localhost:56862";

        public static int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1.Регистрация:");
            Console.WriteLine("2.Логин:");
            Console.WriteLine("3.Сохранить интервал:");
            Console.WriteLine("4.Вывести интервалы:");
            Console.WriteLine("5.Выход:");
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
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        SaveInterval();
                        break;
                        
                    case "4":
                        GetIntervals();
                        break;
                }
            } while (userInput != 5);
            Console.Read();
        }

        // регистрация
        static string Register(string email, string password)
        {
            var registerModel = new
            {
                Email = email,
                Password = password
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/api/Account/Register", registerModel).Result;
                return response.StatusCode.ToString();
            }
        }

        // создаем http-клиента с токеном 
        static HttpClient CreateClient(string accessToken)
        {
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
            return client;
        }

        // получаем информацию о клиенте 
        static string GetUserInfo(string token)
        {
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/Account/UserInfo").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        // обращаемся по маршруту api/values 
        static List<DateInterval> GetValues(string startDate, string endDate)
        {
            string intervalString = $"?startDate={startDate}&endDate={endDate}";
            string controllerRoute = "/api/DateIntervals";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(APP_PATH + controllerRoute + intervalString).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                // Десериализация полученного JSON-объекта
                List<DateInterval> tokenDictionary =
                    JsonConvert.DeserializeObject<List<DateInterval>>(result);
                return tokenDictionary;
            }
        }
    }
}
    
