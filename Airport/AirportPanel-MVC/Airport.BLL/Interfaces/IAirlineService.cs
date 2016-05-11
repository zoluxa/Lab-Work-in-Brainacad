namespace Airport.BLL.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    interface IAirlineService
    {
        void MakeAirline(AirlineDTO airlineDTO);
        AirlineDTO GetAirline(int? id);
        IEnumerable<AirlineDTO> GetAirlines();
        void UpdateAirline(AirlineDTO airlineDTO);
        void DeleteAirline(int id);
        void Dispose();

        // Filter
        IEnumerable<AirlineDTO> FindByName(string value);

        // Order
        IEnumerable<AirlineDTO> OrderByName(IEnumerable<AirlineDTO> list);
        IEnumerable<AirlineDTO> OrderByNameDesc(IEnumerable<AirlineDTO> list);
    }
}
