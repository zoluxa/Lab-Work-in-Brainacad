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

    public class AirlineService : IAirlineService, IDisposable
    {
        readonly AirlineUnit airlineUnit;
        public AirlineService()
        {
            airlineUnit = new AirlineUnit();
        }

        public void DeleteAirline(int id)
        {
            airlineUnit.AirlineRepository.Delete(id.CheckForNull());
            airlineUnit.SaveChanges();
        }

        public void Dispose()
        {
            airlineUnit.Dispose();
        }

        public IEnumerable<AirlineDTO> FindByName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationException("search string is null.", "");
            var airline = airlineUnit.AirlineRepository.Get(p => p.Name.Contains(value));
            Mapper.CreateMap<Airline, AirlineDTO>();
            return Mapper.Map<IEnumerable<Airline>, List<AirlineDTO>>(airline.CheckForNull());
        }

        public AirlineDTO GetAirline(int? id)
        {
            if (id == null)
                throw new ValidationException("id is null.", "");
            var airline = airlineUnit.AirlineRepository.GetByID(id);
            Mapper.CreateMap<Airline, AirlineDTO>();
            return Mapper.Map<Airline, AirlineDTO>(airline.CheckForNull());

        }

        public IEnumerable<AirlineDTO> GetAirlines()
        {
            Mapper.CreateMap<Airline, AirlineDTO>();
            return Mapper.Map<IEnumerable<Airline>, List<AirlineDTO>>(airlineUnit.AirlineRepository.Get());
        }

        public void MakeAirline(AirlineDTO airlineDTO)
        {
            airlineDTO.CheckForNull();
            var airline = new Airline
            {
                Name = airlineDTO.Name
            };
            airlineUnit.AirlineRepository.Insert(airline);
            airlineUnit.SaveChanges();
        }

        public IEnumerable<AirlineDTO> OrderByName(IEnumerable<AirlineDTO> list)
        {
            return list.OrderBy(p => p.Name);
        }

        public IEnumerable<AirlineDTO> OrderByNameDesc(IEnumerable<AirlineDTO> list)
        {
            return list.OrderByDescending(p => p.Name);
        }

        public void UpdateAirline(AirlineDTO airlineDTO)
        {
            airlineDTO.CheckForNull();
            var airline = new Airline
            {
                Id = airlineDTO.Id,
                Name = airlineDTO.Name
            };
            airlineUnit.AirlineRepository.Update(airline);
            airlineUnit.SaveChanges();
        }
    }
}
