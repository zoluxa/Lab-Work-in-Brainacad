namespace Airport.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using DTO;

    interface IFlightService
    {
        void MakeFlight(FlightDTO flightDTO);
        FlightDTO GetFlight(int? id);
        IEnumerable<FlightDTO> GetFlights();
        void UpdateFlight(FlightDTO flightDTO);
        void DeleteFlight(int id);
        void Dispose();

        // find by parameter
        IEnumerable<FlightDTO> FindByAirline(string searchString);
        IEnumerable<FlightDTO> FindByDeparturePort(string searchString);
        IEnumerable<FlightDTO> FindByDepartureDate(string searchString);
        IEnumerable<FlightDTO> FindByArrivalPort(string searchString);
        IEnumerable<FlightDTO> FindByArrivalDate(string searchString);

        // order by parameter
        IEnumerable<FlightDTO> OrderByAirline(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByAirlineDesc(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByDeparturePort(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByDeparturePortDesc(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByDepartureDate(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByDepartureDateDesc(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByArrivalPort(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByArrivalPortDesc(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByArrivalDate(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByArrivalDateDesc(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByFlightNumber(IEnumerable<FlightDTO> flights);
        IEnumerable<FlightDTO> OrderByFlightNumberDesc(IEnumerable<FlightDTO> flights);
    }
}
