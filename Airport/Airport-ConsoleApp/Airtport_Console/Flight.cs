using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airtport.Enums;

namespace Airtport
{
    class Flight
    {
        public string Number { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string City { get; set; }
        public string Airline { get; set; }
        public string Terminal { get; set; }
        public FlightStatus Status { get; set; }
    }
}
