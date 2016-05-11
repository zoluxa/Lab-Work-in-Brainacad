namespace Airport.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using DAL.Model.Entities;
    using DTO;
    using Infrastructure;
    using Interfaces;
    using UnitOfWork.Catalogs;

    public class FlightPlaceService : IFlightPlaceService, IDisposable
    {
        readonly FlightPlaceUnit flightPlaceUnit;
        public FlightPlaceService()
        {
            flightPlaceUnit = new FlightPlaceUnit();
        }

        public void DeleteFlightPlace(int id)
        {
            flightPlaceUnit.FlightPlaceRepository.Delete(id.CheckForNull());
            flightPlaceUnit.SaveChanges();
        }

        public void Dispose()
        {
            flightPlaceUnit.Dispose();
        }

        public FlightPlaceDTO GetFlightPlace(int? id)
        {
            var flightPlace = flightPlaceUnit.FlightPlaceRepository.GetByID(id.CheckForNull());
            Mapper.CreateMap<FlightPlace, FlightPlaceDTO>();
            return Mapper.Map<FlightPlace, FlightPlaceDTO>(flightPlace.CheckForNull());

        }

        public IEnumerable<FlightPlaceDTO> GetFlightPlaces()
        {
            Mapper.CreateMap<FlightPlace, FlightPlaceDTO>();
            return Mapper.Map<IEnumerable<FlightPlace>, List<FlightPlaceDTO>>(flightPlaceUnit.FlightPlaceRepository.Get());
        }

        public void MakeFlightPlace(FlightPlaceDTO flightPlaceDTO)
        {
            flightPlaceDTO.CheckForNull();
            var flightPlace = new FlightPlace
            {
                FlightId = flightPlaceDTO.FlightId,
                Price = flightPlaceDTO.Price,
                Quantity = flightPlaceDTO.Quantity,
                PlaceClass = (DAL.Model.Enums.PlaceClass)flightPlaceDTO.PlaceClass
            };
            flightPlaceUnit.FlightPlaceRepository.Insert(flightPlace);
            flightPlaceUnit.SaveChanges();
        }

        public void UpdateFlightPlace(FlightPlaceDTO flightPlaceDTO)
        {
            flightPlaceDTO.CheckForNull();
            var flightPlace = new FlightPlace
            {
                Id = flightPlaceDTO.Id,
                FlightId = flightPlaceDTO.FlightId,
                Price = flightPlaceDTO.Price,
                Quantity = flightPlaceDTO.Quantity,
                PlaceClass = (DAL.Model.Enums.PlaceClass)flightPlaceDTO.PlaceClass
            };
            flightPlaceUnit.FlightPlaceRepository.Update(flightPlace);
            flightPlaceUnit.SaveChanges();
        }
    }
}
