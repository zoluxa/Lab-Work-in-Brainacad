using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airtport.Enums;

namespace Airtport.ConsoleApp
{
    class Program
    {
        public static Flight[] flights;

        static void Main(string[] args)
        {
            // Initialize flights array
            flights = GetFlights(3);
            // Show main menu
            ShowMainMenu();
            System.Console.ReadLine();
        }

        static void ShowMainMenu() 
        {
            string[] menuString = new[] { "0","1","2","3","4" };
            System.Console.Clear();
            System.Console.WriteLine("This is airport Terminal");
            System.Console.WriteLine("Menu");
            System.Console.WriteLine("1: Show flights");
            System.Console.WriteLine("2: Add flight");
            System.Console.WriteLine("3: Edit flights");
            System.Console.WriteLine("4: Delete flight");
            System.Console.WriteLine("0: Exit");
            System.Console.WriteLine("Select section...");
            var inputValue = Convert.ToInt32(System.Console.ReadLine());
            switch (inputValue)
            {
                case (int)MainMenu.Show:
                    {
                        ShowCurrentFlights();
                        System.Console.WriteLine("Back to main menu...");
                        System.Console.ReadLine();
                        ShowMainMenu();
                        break;
                    }
                case (int)MainMenu.Add:
                    {
                        Flight newFlight = AddFlight();
                        int newSize = flights.Length + 1;
                        Array.Resize<Flight>(ref flights, newSize);
                        flights[newSize-1] = newFlight;
                        ShowMainMenu();
                        break;
                    }
                case (int)MainMenu.Edit:
                    {
                        Console.Clear();
                        Console.WriteLine("Set item index to edit");
                        var index = Convert.ToInt32(Console.ReadLine());
                        EditFlight(index);
                        break;
                    }
                case (int)MainMenu.Delete:
                    {
                        Console.Clear();
                        Console.WriteLine("Set item index to delete");
                        int index = Convert.ToInt32(Console.ReadLine());
                        RemoveFlight(index);
                        Console.WriteLine("Item removed successfuly");
                        Console.WriteLine("Back to main menu");
                        Console.ReadLine();
                        ShowMainMenu();
                        break;
                    }
                case (int)MainMenu.Exit:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    break;

            }
            ShowMainMenu();
            
        }

        static void ShowCurrentFlights()
        {
            System.Console.Clear();
            System.Console.WriteLine("{0,5} {1,5} {2,5} {3,5} {4,5} {5,5}", 
                "Number", "Airline", "City", "Arrival Time", "Terminal", "Status");
            System.Console.WriteLine();
            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i] != null) {
                    System.Console.WriteLine("{0,6} {1,8} {2,7} {3,5} {4,1} {5,10}",
                    flights[i].Number, flights[i].Airline, flights[i].City, flights[i].ArrivalTime, flights[i].Terminal, flights[i].Status);
                }
            }
        }

        static Flight AddFlight()
        {
            System.Console.Clear();
            System.Console.WriteLine("Please enter an flight number");
            var number = System.Console.ReadLine();
            System.Console.WriteLine("Please enter an flight arrival time (yyyy-MM-dd HH:mm)");
            var arrivalTime = System.Console.ReadLine();
            System.Console.WriteLine("Please enter an flight city");
            var city = System.Console.ReadLine();
            System.Console.WriteLine("Please enter an flight airline");
            var airline = System.Console.ReadLine();
            System.Console.WriteLine("Please enter an flight terminal");
            var terminal = System.Console.ReadLine();
            System.Console.WriteLine("Please enter an flight status");
            string status = System.Console.ReadLine();
            return new Flight
            {
                Airline = airline,
                ArrivalTime = DateTime.ParseExact(arrivalTime, "yyyy-MM-dd HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture),
                City = city,
                Number = number,
                Status = (FlightStatus)Enum.Parse(typeof(FlightStatus), status),
                Terminal = terminal
            };
        }

        static Flight[] GetFlights(int arraySize)
        {
            Flight[] flights = new Flight[arraySize];

            flights[0] = new Flight
            {
                Airline = "MAU",
                ArrivalTime = new DateTime(2016, 5, 6, 12, 30, 0),
                City = "Kiev",
                Number = "123123",
                Status = FlightStatus.Arrived,
                Terminal = "D"
            };

            flights[1] = new Flight
            {
                Airline = "Airlines",
                ArrivalTime = new DateTime(2016, 5, 6, 15, 0, 0),
                City = "Lviv",
                Number = "112233",
                Status = FlightStatus.Canceled,
                Terminal = "B"
            };

            flights[2] = new Flight
            {
                Airline = "AeroSvit",
                ArrivalTime = new DateTime(2016, 5, 6, 15, 30, 0),
                City = "Odessa",
                Number = "555444",
                Status = FlightStatus.Delayed,
                Terminal = "A"
            };
            return flights;
        }

        static void EditFlight(int index) {
            Console.Clear();
            Flight changeFlight = flights[index];

            Console.WriteLine("Choose flight info to change");
            Console.WriteLine("0: Number");
            Console.WriteLine("1: Arrival time");
            Console.WriteLine("2: City");
            Console.WriteLine("3: Airline");
            Console.WriteLine("4: Terminal");
            var infoIndex = Convert.ToInt32(Console.ReadLine());
            switch (infoIndex)
            {
                case 0:
                    {
                        Console.WriteLine("Current flight number is: {0}", changeFlight.Number);
                        Console.WriteLine("Please, set new flight number");
                        string newNumber = Console.ReadLine();
                        changeFlight.Number = newNumber;
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Current arrival time is: {0}", changeFlight.ArrivalTime);
                        Console.WriteLine("Please, set new arrival time (yyyy-MM-dd HH:mm)");
                        DateTime newArrivalTime= DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm",
                            System.Globalization.CultureInfo.InvariantCulture);
                        changeFlight.ArrivalTime = newArrivalTime;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Current flight City is: {0}", changeFlight.City);
                        Console.WriteLine("Please, set new flight City");
                        string newCity = Console.ReadLine();
                        changeFlight.City = newCity;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Current flight Airline is: {0}", changeFlight.Airline);
                        Console.WriteLine("Please, set new flight Airline");
                        string newAirline = Console.ReadLine();
                        changeFlight.Airline = newAirline;
                        break;
                    }
                case 4:
                    {
                        //Terminal
                        Console.WriteLine("Current flight Terminal is: {0}", changeFlight.Terminal);
                        Console.WriteLine("Please, set new flight Terminal");
                        string newTerminal = Console.ReadLine();
                        changeFlight.Terminal = newTerminal;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong property");
                        break;
                    }
            }
        }

        static void RemoveFlight(int index) {
            Array.Clear(flights, index, 1);
        }
    }
}
