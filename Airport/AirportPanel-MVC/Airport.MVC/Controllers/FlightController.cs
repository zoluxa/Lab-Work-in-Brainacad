namespace Airport.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using BLL.DTO;
    using BLL.DTO.EnumsDTO;
    using BLL.Services;
    using Models;

    [Authorize]
    public class FlightController : Controller
    {
        FlightService flightService;
        public FlightController()
        {
            flightService = new FlightService();
        }
        // GET: Flight
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(string sortOrder, string searchParam, string searchString)
        {
            ViewBag.FlightNumberSortParam = string.IsNullOrEmpty(sortOrder) ? "flightNumber_desc" : "FlightNumber";
            ViewBag.DepartureDateSortParam = sortOrder == "DepartureDate" ? "departureDate_desc" : "DepartureDate";
            ViewBag.ArrivalDateSortParam = sortOrder == "ArrivalDate" ? "arrivalDate_desc" : "ArrivalDate";
            ViewBag.DeparturePortSortParam = sortOrder == "DeparturePort" ? "departurePort_desc" : "DeparturePort";
            ViewBag.ArrivalPortSortParam = sortOrder == "ArrivalPort" ? "arrivalPort_desc" : "ArrivalPort";
            ViewBag.AirlineSortParam = sortOrder == "Airline" ? "airline_desc" : "Airline";

            PopulateDropDownSearchParam();

            var model = new List<FlightModel>();
            try
            {
                var items = flightService.GetFlights();

                if (!string.IsNullOrEmpty(searchString) & !string.IsNullOrEmpty(searchParam))
                {
                    items = FindBy(searchParam, searchString);
                }

                switch (sortOrder)
                {
                    case "FlightNumber":
                        {
                            items = flightService.OrderByFlightNumber(items);
                            break;
                        }
                    case "flightNumber_desc":
                        {
                            items = flightService.OrderByFlightNumberDesc(items);
                            break;
                        }
                    case "DepartureDate":
                        {
                            items = flightService.OrderByDepartureDate(items);
                            break;
                        }
                    case "departureDate_desc":
                        {
                            items = flightService.OrderByDepartureDateDesc(items);
                            break;
                        }
                    case "ArrivalDate":
                        {
                            items = flightService.OrderByArrivalDate(items);
                            break;
                        }
                    case "arrivalDate_desc":
                        {
                            items = flightService.OrderByArrivalDateDesc(items);
                            break;
                        }
                    case "DeparturePort":
                        {
                            items = flightService.OrderByDeparturePort(items);
                            break;
                        }
                    case "departurePort_desc":
                        {
                            items = flightService.OrderByDeparturePortDesc(items);
                            break;
                        }
                    case "ArrivalPort":
                        {
                            items = flightService.OrderByArrivalPort(items);
                            break;
                        }
                    case "arrivalPort_desc":
                        {
                            items = flightService.OrderByArrivalPortDesc(items);
                            break;
                        }
                    case "Airline":
                        {
                            items = flightService.OrderByAirline(items);
                            break;
                        }
                    case "airline_desc":
                        {
                            items = flightService.OrderByAirlineDesc(items);
                            break;
                        }
                    default:
                        {
                            items = flightService.OrderByFlightNumber(items);
                            break;
                        }
                }

                Mapper.CreateMap<FlightDTO, FlightModel>();
                model = Mapper.Map<IEnumerable<FlightDTO>, List<FlightModel>>(items);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    $"Unable to get flights. Try again or contact to administrator. {ex.Message}");
            }
            return View(model);
        }

        void PopulateDropDownSearchParam()
        {
            ViewData["SearchParam"] = new SelectList(new Dictionary<string, string>
            {
                ["Airline"] = "Airline",
                ["ArrivalDate"] = "Arrival date",
                ["DepartureDate"] = "Departure date",
                ["ArrivalPort"] = "Arrival port",
                ["DeparturePort"] = "Departure port"
            }, "Key", "Value");
        }

        IEnumerable<FlightDTO> FindBy(string seacrhParam, string searchString)
        {
            
            switch (seacrhParam)
            {
                case "Airline":
                    {
                        return flightService.FindByAirline(searchString);
                    }
                case "ArrivalDate":
                    {
                        return flightService.FindByArrivalDate(searchString);
                    }
                case "ArrivalPort":
                    {
                        return flightService.FindByArrivalPort(searchString);
                    }
                case "DepartureDate":
                    {
                        return flightService.FindByDepartureDate(searchString);
                    }
                case "DeparturePort":
                    {
                        return flightService.FindByDeparturePort(searchString);
                    }
                default:
                    return null;
            }
        }

        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var item = flightService.GetFlight(id);
                Mapper.CreateMap<FlightDTO, FlightModel>();
                var model = Mapper.Map<FlightDTO, FlightModel>(item);
                model.ArrivalTime = item.ArrivalDate;
                model.DepartureTime = item.DepartureDate;
                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    $"Unable to open details to id {id}");
            }
            return RedirectToAction("Index");
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            var model = new FlightModel();
            PopulateDropDownLists(model.AirlineId, model.ArrivalPortId, model.DeparturePortId);

            return View(model);
        }

        void PopulateDropDownLists(object selectedAirline = null,
            object selectedArrivalPort = null,
            object selectedDeparturePort = null)
        {
            // Select list for Departure port
            var DeparturePortModels = new List<PortModel>();
            using (var portService = new PortService())
            {
                var departurePortItems = portService.GetPorts();
                foreach (var item in departurePortItems)
                {
                    DeparturePortModels.Add(new PortModel
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
                ViewData["DeparturePortId"] = new SelectList(DeparturePortModels, "Id", "Name", selectedDeparturePort);

                // Select list for Arrival port
                var arrivalPortItems = portService.GetPorts();
                var ArrivalPortModels = new List<PortModel>();
                foreach (var item in arrivalPortItems)
                {
                    ArrivalPortModels.Add(new PortModel
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
                ViewData["ArrivalPortId"] = new SelectList(ArrivalPortModels, "Id", "Name", selectedArrivalPort);

            }

            // Select list for Airline
            using (var airlineService = new AirlineService())
            {
                var airlines = new List<AirlineModel>();
                var airlinesItems = airlineService.GetAirlines();
                foreach (var item in airlinesItems)
                {
                    airlines.Add(new AirlineModel
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
                ViewData["AirlineId"] = new SelectList(airlines, "Id", "Name", selectedAirline);
            }
        }


        // POST: Flight/Create
        [HttpPost]
        public ActionResult Create(
            [Bind(Exclude = "Id")]
            FlightModel flight)
        {
            try
            {
                flightService.MakeFlight(
                    ConvertToFlight(flight));
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateDropDownLists(flight.AirlineId, flight.ArrivalPortId, flight.DeparturePortId);
                return View(flight);
            }
        }

        static FlightDTO ConvertToFlight(FlightModel flight)
        {
            return new FlightDTO
            {
                FlightNumber = flight.FlightNumber,
                Id = flight.Id,
                AirlineId = flight.AirlineId,
                ArrivalDate = flight.ArrivalDate,
                ArrivalPortId = flight.ArrivalPortId,
                DepartureDate = flight.DepartureDate,
                DeparturePortId = flight.DeparturePortId,
                Gate = flight.Gate,
                Terminal = flight.Terminal,
                Status = (FlightStatusDTO)flight.Status,
                PlaceQty = flight.PlaceQty

            };
        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new FlightModel();
            try
            {
                var item = flightService.GetFlight(id);
                Mapper.CreateMap<FlightDTO, FlightModel>();

                model = Mapper.Map<FlightDTO, FlightModel>(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    $"Unable to edit.{ex.Message}");

            }
            PopulateDropDownLists(model.AirlineId, model.ArrivalPortId, model.DeparturePortId);
            return View(model);
        }

        // POST: Flight/Edit/5
        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, FlightNumber,AirlineId, ArrivalPortId, DeparturePortId, ArrivalDate, DepartureDate, Terminal, Gate, PlaceQty, Status")]
            FlightModel flight)
        {
            try
            {
                var item = ConvertToFlight(flight);
                flightService.UpdateFlight(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                PopulateDropDownLists(flight.AirlineId, flight.ArrivalPortId, flight.DeparturePortId);
                ModelState.AddModelError("",
                    $"Unable to edit.{ex.Message}");
                return View(flight);
            }
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new FlightModel();
            try
            {
                var item = flightService.GetFlight(id);
                Mapper.CreateMap<FlightDTO, FlightModel>();
                model = Mapper.Map<FlightDTO, FlightModel>(item);
            }
            catch
            {
                ModelState.AddModelError("",
                    "Unable to delete.");

            }
            return View(model);
        }

        // POST: Flight/Delete/5
        [HttpPost]
        public ActionResult Delete(
            [Bind(Include = "Id, FlightNumber,AirlineId, ArrivalPortId, DeparturePortId, ArrivalDate, DepartureDate, Terminal, Gate, PlaceQty, Status")]
            FlightModel flight)
        {
            try
            {
                flightService.DeleteFlight(flight.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(flight);
            }
        }


        protected bool disposed;
        protected new void Dispose(bool disposing)
        {
            if (!disposed)
            {
                flightService.Dispose();
            }
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
