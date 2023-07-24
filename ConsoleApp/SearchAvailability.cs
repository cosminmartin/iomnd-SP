//namespace ConsoleApp
//{
//    internal class SearchAvailability
//    {
//        public class RequestObject
//        {
//            public DateTime DateFrom { get; set; }
//            public int Duration { get; set; }
//            public int NumberOfPersons { get; set; }
//            public Credentials Credentials { get; set; }
//        }

//        public class Credentials
//        {
//            public string UserName { get; set; }
//            public string Password { get; set; }
//        }

//        public class AvailabilityService
//        {
//            public List<Availability> SearchAvailability(RequestObject request)
//            {
               
//                if (!ValidateCredentials(request.Credentials))
//                {
//                    throw new Exception("Invalid credentials");
//                }
          
//                List<Availability> availableTimes = new List<Availability>();
              
//                for (int i = 0; i < request.Duration; i++)
//                {
//                    Availability availability = new Availability
//                    {
//                        DateTime = request.DateFrom.AddDays(i),
//                        NumberOfPersons = request.NumberOfPersons
//                    };

//                    availableTimes.Add(availability);
//                }

//                return availableTimes;
//            }

//            private bool ValidateCredentials(Credentials credentials)
//            {           
//                return credentials.UserName == "admin" && credentials.Password == "password123";
//            }
//        }

//        public class Availability
//        {
//            public DateTime DateTime { get; set; }
//            public int NumberOfPersons { get; set; }
//        }

//        class Program
//        {
//            static void Main(string[] args)
//            {              
//                RequestObject request = new RequestObject
//                {
//                    DateFrom = DateTime.Now,
//                    Duration = 7,
//                    NumberOfPersons = 2,
//                    Credentials = new Credentials
//                    {
//                        UserName = "admin",
//                        Password = "password123"
//                    }
//                };

               
//                AvailabilityService availabilityService = new AvailabilityService();

//                try
//                {                   
//                    List<Availability> availableTimes = availabilityService.SearchAvailability(request);
            
//                    Console.WriteLine("Available Times:");
//                    foreach (Availability availability in availableTimes)
//                    {
//                        Console.WriteLine($"Date: {availability.DateTime}, Number of Persons: {availability.NumberOfPersons}");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error: {ex.Message}");
//                }

//                Console.ReadLine();
//            }
//           }
//        }
//}
