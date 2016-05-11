using System;

namespace Airport.MVC.Models
{
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class FlightModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [Display(Name = "Flight number")]
        public string FlightNumber { get; set; }
        [Display(Name = "Airline")]
        public int AirlineId { get; set; }
        [Display(Name = "Airline")]
        public string AirlineName { get; set; }
        [Display(Name = "Arrival port")]
        public int ArrivalPortId { get; set; }
        [Display(Name = "Arrival port")]
        public string ArrivalPortName { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Arrival time")]
        public DateTime ArrivalTime { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Arrival date")]
        public DateTime ArrivalDate { get; set; }
        [Display(Name = "Departure port")]
        public int DeparturePortId { get; set; }
        [Display(Name = "Departure port")]
        public string DeparturePortName { get; set; }
        [Display(Name = "Departure date")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        [Display(Name = "Departure time")]
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }
        [MaxLength(5)]
        public string Terminal { get; set; }
        [MaxLength(5)]
        public string Gate { get; set; }
        public int PlaceQty { get; set; }
        public FlightStatus Status { get; set; }

    }
}
