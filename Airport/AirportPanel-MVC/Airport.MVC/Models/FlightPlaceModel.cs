namespace Airport.MVC.Models
{
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class FlightPlaceModel
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        [Display(Name = "Flight number")]
        public string FlightNumber { get; set; }
        public PlaceClass PlaceClass { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:x.xx}")]
        public decimal Price { get; set; }

    }
}
