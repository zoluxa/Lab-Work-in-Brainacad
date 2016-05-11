namespace Airport.MVC.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using BLL.DTO;
    using BLL.DTO.EnumsDTO;
    using BLL.Services;
    using Models;
    using Models.Enums;

    public class FlightPlaceController : Controller
    {
        readonly FlightPlaceService flightPlaceService;

        public FlightPlaceController()
        {
            flightPlaceService = new FlightPlaceService();
        }
        // GET: FlightPlace
        public ActionResult Index()
        {
            Mapper.CreateMap<FlightPlaceDTO, FlightPlaceModel>();
            return View(Mapper.Map<IEnumerable<FlightPlaceDTO>, List<FlightPlaceModel>>(flightPlaceService.GetFlightPlaces()));
        }

        // GET: FlightPlace/Details/5
        public ActionResult Details(int id)
        {
            Mapper.CreateMap<FlightPlaceDTO, FlightPlaceModel>();

            return View(Mapper.Map<FlightPlaceDTO, FlightPlaceModel>(flightPlaceService.GetFlightPlace(id)));
        }

        // GET: FlightPlace/Create
        public ActionResult Create()
        {
            PopulateDropDownMenues();
            return View();
        }

        private void PopulateDropDownMenues(object selectedPlaceClass = null, object selectedFlightId = null)
        {
            Mapper.CreateMap<FlightDTO, FlightModel>();
            using (var flightService = new FlightService())
            {
                ViewData["FlightId"] = GetSelectedListOfFlights(
                        Mapper.Map<IEnumerable<FlightDTO>, 
                        List<FlightModel>>(flightService.GetFlights()), selectedFlightId);
            }            var placeClass = new List<SelectListItem>();
            placeClass.Add(new SelectListItem { Value = "0", Text = nameof(PlaceClass.Business) });
            placeClass.Add(new SelectListItem { Value = "1", Text = nameof(PlaceClass.Economy) });

            ViewData["PlaceClass"] = new SelectList(placeClass, "Value", "Text", selectedPlaceClass);
        }

        SelectList GetSelectedListOfFlights(IEnumerable<FlightModel> items, object selectedFlightId)
        {
            var flights = new List<SelectListItem>();
            foreach (var item in items)
            {
                flights.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FlightNumber });
            }
            return new SelectList(flights, "Value", "Text", selectedFlightId);
        }

        // POST: FlightPlace/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] FlightPlaceModel flightPlaceModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    flightPlaceService.MakeFlightPlace(
                        new FlightPlaceDTO
                        {
                            FlightId = flightPlaceModel.FlightId,
                            Price = flightPlaceModel.Price,
                            PlaceClass = (PlaceClassDTO)flightPlaceModel.PlaceClass,
                            Quantity = flightPlaceModel.Quantity
                        });                    
                    return RedirectToAction("Index");
                }
                throw new HttpException("Model is not valid.");

            }
            catch
            {
                return View(flightPlaceModel);
            }
        }

        // GET: FlightPlace/Edit/5
        public ActionResult Edit(int id)
        {
            Mapper.CreateMap<FlightPlaceDTO, FlightPlaceModel>();
            var model = Mapper.Map<FlightPlaceDTO, FlightPlaceModel>(flightPlaceService.GetFlightPlace(id));
            PopulateDropDownMenues(model.PlaceClass, model.FlightId);
            return View(model);
        }

        // POST: FlightPlace/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind]FlightPlaceModel flightPlaceModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    flightPlaceService.UpdateFlightPlace(
                        new FlightPlaceDTO
                        {
                            FlightId = flightPlaceModel.FlightId,
                            Price = flightPlaceModel.Price,
                            PlaceClass = (PlaceClassDTO)flightPlaceModel.PlaceClass,
                            Quantity = flightPlaceModel.Quantity
                        });
                    return RedirectToAction("Index");
                }
                throw new HttpException("Model is not valid.");
            }
            catch
            {
                return View(flightPlaceModel);
            }
        }

        // GET: FlightPlace/Delete/5
        public ActionResult Delete(int id)
        {
            Mapper.CreateMap<FlightPlaceDTO, FlightPlaceModel>();
            return View(Mapper.Map<FlightPlaceDTO, FlightPlaceModel>(flightPlaceService.GetFlightPlace(id)));
        }

        // POST: FlightPlace/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind]FlightPlaceModel flightPlaceModel)
        {
            try
            {
                flightPlaceService.DeleteFlightPlace(flightPlaceModel.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(flightPlaceModel);
            }
        }

        public new void Dispose()
        {
            flightPlaceService.Dispose();
        }
    }
}
