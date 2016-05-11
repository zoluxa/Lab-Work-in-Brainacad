namespace Airport.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BusinessModels;
    using DAL.Model.Entities;
    using DTO;
    using Infrastructure;
    using Interfaces;
    using UnitOfWork.Catalogs;

    public class FlightService : IFlightService, IDisposable
    {
        readonly FlightUnit flightUnit;
        public FlightService()
        {
            flightUnit = new FlightUnit();
        }


        public void MakeFlight(FlightDTO flightDTO)
        {
            if (!new CheckFlightDates(flightDTO).DatesIsValid())
                throw new ValidationException("Flight can not arrive earlier then derive", "ArrivalDate");
            var flight = new Flight
            {
                FlightNumber = flightDTO.FlightNumber,
                AirlineId = flightDTO.AirlineId,
                DepartureDate = flightDTO.DepartureDate,
                DeparturePortId = flightDTO.DeparturePortId,
                ArrivalDate = flightDTO.ArrivalDate,
                ArrivalPortId = flightDTO.ArrivalPortId,
                Gate = flightDTO.Gate,
                PlaceQty = flightDTO.PlaceQty,
                Status = (DAL.Model.Enums.FlightStatus)flightDTO.Status,
                Terminal = flightDTO.Terminal
            };
            flightUnit.FlightRepository.Insert(flight);
            flightUnit.SaveChanges();
        }
        public FlightDTO GetFlight(int? id)
        {
            var flight = flightUnit.FlightRepository.GetByID(id);
            if (flight == null)
                throw new ValidationException("Flight not found", "");
            Mapper.CreateMap<Flight, FlightDTO>();
            var item = Mapper.Map<Flight, FlightDTO>(flight);
            item.AirlineName = flight.Airline.Name;
            item.ArrivalPortName = flight.ArrivalPort.Name;
            item.DeparturePortName = flight.DeparturePort.Name;
            if (new CheckFlightDates(item).DatesIsValid())
                return item;
            throw new ValidationException("Flight can not arrive earlier then derive", "ArrivalDate");

        }

        public IEnumerable<FlightDTO> GetFlights()
        {
            Mapper.CreateMap<Flight, FlightDTO>();
            return ConvertToListDTO(flightUnit.FlightRepository.Get(includeProperties: "Airline, DeparturePort, ArrivalPort"));
        }

        List<FlightDTO> ConvertToListDTO(IEnumerable<Flight> flights)
        {
            var list = new List<FlightDTO>();
            foreach (var item in flights)
            {
                var flight = Mapper.Map<Flight, FlightDTO>(item);
                flight.AirlineName = item.Airline.Name;
                flight.ArrivalPortName = item.ArrivalPort.Name;
                flight.DeparturePortName = item.DeparturePort.Name;
                list.Add(flight);
            }

            return list;
        }

        public void UpdateFlight(FlightDTO flightDTO)
        {
            if (!new CheckFlightDates(flightDTO).DatesIsValid())
                throw new ValidationException("Flight can not arrive earlier then derive", "ArrivalDate");
            var flight = new Flight
            {
                Id = flightDTO.Id,
                FlightNumber = flightDTO.FlightNumber,
                AirlineId = flightDTO.AirlineId,
                DepartureDate = flightDTO.DepartureDate,
                DeparturePortId = flightDTO.DeparturePortId,
                ArrivalDate = flightDTO.ArrivalDate,
                ArrivalPortId = flightDTO.ArrivalPortId,
                Gate = flightDTO.Gate,
                PlaceQty = flightDTO.PlaceQty,
                Status = (DAL.Model.Enums.FlightStatus)flightDTO.Status,
                Terminal = flightDTO.Terminal
            };
            flightUnit.FlightRepository.Update(flight);
            flightUnit.SaveChanges();
        }
        public void DeleteFlight(int id)
        {
            flightUnit.FlightRepository.Delete(id);
            flightUnit.SaveChanges();
        }

        public void Dispose()
        {
            flightUnit.Dispose();
        }

        public IEnumerable<FlightDTO> FindByAirline(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new ValidationException("airline not selected", "");
            var collection = flightUnit.FlightRepository.Get(p => p.Airline.Name.Contains(searchString));
            if (collection == null)
                throw new ValidationException("Flights not found", "");
            Mapper.CreateMap<Flight, FlightDTO>();

            return ConvertToListDTO(collection);
        }
        public IEnumerable<FlightDTO> FindByDeparturePort(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new ValidationException("airline not selected", "");
            var collection = flightUnit.FlightRepository.Get(p => p.DeparturePort.Name.Contains(searchString));
            if (collection == null)
                throw new ValidationException("Flights not found", "");
            Mapper.CreateMap<Flight, FlightDTO>();
            return ConvertToListDTO(collection);
        }

        public IEnumerable<FlightDTO> FindByArrivalPort(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new ValidationException("airline not selected", "");
            var collection = flightUnit.FlightRepository.Get(p => p.ArrivalPort.Name.Contains(searchString));
            if (collection == null)
                throw new ValidationException("Flights not found", "");
            Mapper.CreateMap<Flight, FlightDTO>();
            return ConvertToListDTO(collection);
        }
        public IEnumerable<FlightDTO> FindByDepartureDate(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new ValidationException("airline not selected", "");
            DateTime date;
            if (!DateTime.TryParse(searchString, out date))
            {
                throw new ValidationException("search string is not date", "");
            }
            var startDate = date.StartOfDay();
            var endDate = date.EndOfDay();
            var collection = flightUnit.FlightRepository
                .Get(p => p.DepartureDate >= startDate
                && p.DepartureDate <= endDate);
            if (collection == null)
                throw new ValidationException("Flights not found", "");
            Mapper.CreateMap<Flight, FlightDTO>();
            return ConvertToListDTO(collection);
        }

        public IEnumerable<FlightDTO> FindByArrivalDate(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new ValidationException("airline not selected", "");
            DateTime date;
            if (!DateTime.TryParse(searchString, out date))
            {
                throw new ValidationException("search string is not date", "");
            }
            var startDate = date.StartOfDay();
            var endDate = date.EndOfDay();
            var collection = flightUnit.FlightRepository
                .Get(p => p.ArrivalDate >= startDate
                && p.ArrivalDate <= endDate);
            if (collection == null)
                throw new ValidationException("Flights not found", "");
            Mapper.CreateMap<Flight, FlightDTO>();
            return ConvertToListDTO(collection);
        }

        public IEnumerable<FlightDTO> OrderByAirline(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderBy(p => p.AirlineName);
        }

        public IEnumerable<FlightDTO> OrderByAirlineDesc(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderByDescending(p => p.AirlineName);
        }

        public IEnumerable<FlightDTO> OrderByDeparturePort(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderBy(p => p.DeparturePortName);
        }

        public IEnumerable<FlightDTO> OrderByDeparturePortDesc(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderByDescending(p => p.DeparturePortName);
        }

        public IEnumerable<FlightDTO> OrderByDepartureDate(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderBy(p => p.DepartureDate);
        }

        public IEnumerable<FlightDTO> OrderByDepartureDateDesc(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderByDescending(p => p.DepartureDate);
        }

        public IEnumerable<FlightDTO> OrderByArrivalPort(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderBy(p => p.ArrivalPortName);
        }

        public IEnumerable<FlightDTO> OrderByArrivalPortDesc(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderByDescending(p => p.ArrivalPortName);
        }

        public IEnumerable<FlightDTO> OrderByArrivalDate(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderBy(p => p.ArrivalDate);
        }

        public IEnumerable<FlightDTO> OrderByArrivalDateDesc(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderByDescending(p => p.ArrivalDate);
        }

        public IEnumerable<FlightDTO> OrderByFlightNumber(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderBy(p => p.FlightNumber);
        }

        public IEnumerable<FlightDTO> OrderByFlightNumberDesc(IEnumerable<FlightDTO> flights)
        {
            return flights.OrderByDescending(p => p.FlightNumber);
        }
    }

}

