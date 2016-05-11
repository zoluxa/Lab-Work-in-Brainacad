namespace Airport.BLL.DTO
{
    using System;
    using System.Runtime.Serialization;
    using EnumsDTO;

    [DataContract]
    public class FlightDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FlightNumber { get; set; }
        [DataMember]
        public int AirlineId { get; set; }
        [DataMember]
        public string AirlineName { get; set; }
        [DataMember]
        public DateTime DepartureDate { get; set; }
        [DataMember]
        public int DeparturePortId { get; set; }
        [DataMember]
        public string DeparturePortName { get; set; }
        [DataMember]
        public DateTime ArrivalDate { get; set; }
        [DataMember]
        public int ArrivalPortId { get; set; }
        [DataMember]
        public string ArrivalPortName { get; set; }
        [DataMember]
        public string Terminal { get; set; }
        [DataMember]
        public string Gate { get; set; }
        [DataMember]
        public FlightStatusDTO Status { get; set; }
        [DataMember]
        public int PlaceQty { get; set; }

    }
}
