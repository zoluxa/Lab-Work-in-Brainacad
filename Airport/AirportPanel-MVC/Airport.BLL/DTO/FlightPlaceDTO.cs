namespace Airport.BLL.DTO
{
    using EnumsDTO;

    public class FlightPlaceDTO
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public PlaceClassDTO PlaceClass { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
