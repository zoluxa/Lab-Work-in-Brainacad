using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Airport.BLL.DTO;
using Airport.BLL.Services;
using Airport.WebAPI.Models;
using AutoMapper;

namespace Airport.WebAPI.Controllers
{
    public class FlightController : ApiController
    {
        FlightService flightService;
        public FlightController()
        {
            flightService = new FlightService();
        }

        [HttpGet]
        public IEnumerable<Flight> GetFlights()
        {
            var items = flightService.GetFlights();
            Mapper.CreateMap<FlightDTO, Flight>();
            return Mapper.Map<IEnumerable<FlightDTO>, List<Flight>>(items);
        }

        new void Dispose()
        {
            flightService.Dispose();
        }
    }
}
