namespace Airport.BLL.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    interface IFlightPlaceService
    {
        void MakeFlightPlace(FlightPlaceDTO flightPlaceDTO);
        FlightPlaceDTO GetFlightPlace(int? id);
        IEnumerable<FlightPlaceDTO> GetFlightPlaces();
        void UpdateFlightPlace(FlightPlaceDTO flightPlaceDTO);
        void DeleteFlightPlace(int id);
        void Dispose();

    }
}
