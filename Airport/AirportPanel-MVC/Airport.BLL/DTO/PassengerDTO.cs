namespace Airport.BLL.DTO
{
    using System;
    using EnumsDTO;

    public class PassengerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
        public string FlightNumber { get; set; }
        public int FlightId { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public SexDTO Sex { get; set; }
        public PlaceClassDTO PlaceClass { get; set; }
        public decimal Price { get; set; }

    }
}
