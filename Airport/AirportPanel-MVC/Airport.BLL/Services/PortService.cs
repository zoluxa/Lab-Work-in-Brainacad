namespace Airport.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using DAL.Model.Entities;
    using DTO;
    using Infrastructure;
    using Interfaces;
    using UnitOfWork.Catalogs;

    public class PortService : IPortService, IDisposable
    {
        readonly PortUnit portUnit;
        public PortService()
        {
            portUnit = new PortUnit();
        }

        public void DeletePort(int id)
        {
            portUnit.PortRepository.Delete(id);
            portUnit.SaveChanges();
        }

        public void Dispose()
        {
            portUnit.Dispose();
        }

        public PortDTO GetPort(int? id)
        {
            if (id == null)
                throw new ValidationException("id is null.", "");
            var port = portUnit.PortRepository.GetByID(id);
            if (port == null)
                throw new ValidationException("port not found", "");
            Mapper.CreateMap<Port, PortDTO>();
            return Mapper.Map<Port, PortDTO>(port);

        }

        public IEnumerable<PortDTO> OrderByNameDesc(IEnumerable<PortDTO> list)
        {
            return list.OrderByDescending(p => p.Name);
        }

        public IEnumerable<PortDTO> OrderByName(IEnumerable<PortDTO> list)
        {
            return list.OrderBy(p => p.Name);
        }

        public IEnumerable<PortDTO> GetPorts()
        {
            Mapper.CreateMap<Port, PortDTO>();
            return Mapper.Map<IEnumerable<Port>, List<PortDTO>>(portUnit.PortRepository.Get());
        }

        public void MakePort(PortDTO portDTO)
        {
            var port = new Port
            {
                Name = portDTO.Name
            };
            portUnit.PortRepository.Insert(port);
            portUnit.SaveChanges();
        }

        public void UpdatePort(PortDTO portDTO)
        {
            var port = new Port
            {
                Id = portDTO.Id,
                Name = portDTO.Name
            };
            portUnit.PortRepository.Update(port);
            portUnit.SaveChanges();
        }

        public IEnumerable<PortDTO> FindByName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationException("id is null.", "");
            var port = portUnit.PortRepository.Get(p => p.Name.Contains(value));
            if (port == null)
                throw new ValidationException("Port not found", "");
            Mapper.CreateMap<Port, PortDTO>();
            return Mapper.Map<IEnumerable<Port>, List<PortDTO>>(port);
        }
    }
}
