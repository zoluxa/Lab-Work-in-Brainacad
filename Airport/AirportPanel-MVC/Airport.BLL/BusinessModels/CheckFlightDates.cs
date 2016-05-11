namespace Airport.BLL.BusinessModels
{
    using DTO;

    public class CheckFlightDates
    {
        readonly FlightDTO flightDTO;
        public CheckFlightDates(FlightDTO flightDTO)
        {
            this.flightDTO = flightDTO;
        }

        public bool DatesIsValid()
        {
            if (flightDTO.DepartureDate < flightDTO.ArrivalDate)
                return true;            
            return false;
        }
    }
}
