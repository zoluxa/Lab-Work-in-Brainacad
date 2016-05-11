using System.Collections.Generic;
using Airport.BLL.DTO;

namespace Airport.BLL.Interfaces
{
    interface IPortService
    {
        void MakePort(PortDTO portDTO);
        PortDTO GetPort(int? id);
        IEnumerable<PortDTO> GetPorts();
        void UpdatePort(PortDTO portDTO);
        void DeletePort(int id);
        void Dispose();

        // Filtering
        IEnumerable<PortDTO> FindByName(string value);

        // Ordering
        IEnumerable<PortDTO> OrderByName(IEnumerable<PortDTO> ports);
        IEnumerable<PortDTO> OrderByNameDesc(IEnumerable<PortDTO> ports);
    }
}
