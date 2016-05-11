using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Airport.WebAPI.Models
{
    [DataContract]
    public class Flight
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FlightNumber { get; set; }
        [DataMember]
        public string DeparturePortName { get; set; }
        [DataMember]
        public string ArrivalPortName { get; set; }
        [DataMember]
        public DateTime DepartureDate { get; set; }
        [DataMember]
        public DateTime ArrivalDate { get; set; }
        [DataMember]
        public string AirlineName { get; set; }
        [DataMember]
        public string Terminal { get; set; }
        [DataMember]
        public string Gate { get; set; }

    }
}
