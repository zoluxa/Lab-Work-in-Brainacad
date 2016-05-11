namespace Airport.DAL.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class FlightPlace
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
        public PlaceClass PlaceClass { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:x.xx")]
        public decimal Price { get; set; }

    }
}
