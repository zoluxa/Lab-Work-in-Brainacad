
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
    using Models.Enums;

    [Authorize]
    public class PassengerController : Controller
    {
        readonly PassengerService passengerService;
        public PassengerController()
        {
            passengerService = new PassengerService();
        }
        // GET: Passenger
        public ActionResult Index(string sortOrder, string searchParam, string searchString)
        {
            ViewBag.FirstNameSortParam = string.IsNullOrEmpty(sortOrder)
                || sortOrder == "FirstName" ? "firstName_desc" : "FirstName";
            ViewBag.LastNameSortParam = sortOrder == "LastName" ? "lastName_desc" : "LastName";
            ViewBag.NationalitySortParam = sortOrder == "Nationality" ? "nationality_desc" : "Nationality";
            ViewBag.PassportSortParam = sortOrder == "Passport" ? "passport_desc" : "Passport";
            ViewBag.DateOfBirthdaySortParam = sortOrder == "DateOfBirthday" ? "dateOfBirthday_desc" : "DateOfBirthday";
            ViewBag.SexSortParam = sortOrder == "Sex" ? "sex_desc" : "Sex";
            ViewBag.PlaceClassSortParam = sortOrder == "PlaceClass" ? "placeClass_desc" : "PlaceClass";
            PopulateDropDownSearchParams();
            var items = passengerService.GetPassengers();

            items = SortItems(sortOrder, items);

            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(searchParam))
                items = HandleSearch(searchParam, searchString);

            Mapper.CreateMap<PassengerDTO, PassengerModel>();
            return View(Mapper.Map<IEnumerable<PassengerDTO>, List<PassengerModel>>(items));
        }

        IEnumerable<PassengerDTO> HandleSearch(string searchParam, string searchString)
        {
            switch (searchParam)
            {
                case "First Name":
                    {
                        return passengerService.FindByFirstName(searchString);
                    }
                case "Last Name":
                    {
                        return passengerService.FindByLastName(searchString);
                    }
                case "Full Name":
                    {
                        return passengerService.FindByFullName(searchString);
                    }
                case "Nationality":
                    {
                        return passengerService.FindByNationality(searchString);
                    }
                case "Passport":
                    {
                        return passengerService.FindByPassport(searchString);
                    }
                case "DateOfBirthday":
                    {
                        DateTime date;
                        if (DateTime.TryParse(searchString, out date))
                        {
                            return passengerService.FindByDateOfBirthday(date);
                        }
                        ModelState.AddModelError("", "Invalid search string");
                        return null;
                    }
                default:
                    return null;
    
            }
        }

        void PopulateDropDownSearchParams()
        {
            ViewBag.SearchParam = new SelectList(new List<string>
            {
                "First Name",
                "Last Name",
                "Full Name",
                "Nationality",
                "Passport",
                "Date of Birthday"
            });
        }

        IEnumerable<PassengerDTO> SortItems(string sortOrder, IEnumerable<PassengerDTO> items)
        {
            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "FirstName":
                        {
                            items = passengerService.OrderByFirstName(items);
                            break;
                        }
                    case "firstName_desc":
                        {
                            items = passengerService.OrderByFirstNameDesc(items);
                            break;
                        }
                    case "LastName":
                        {
                            items = passengerService.OrderByLastName(items);
                            break;
                        }
                    case "lastName_desc":
                        {
                            items = passengerService.OrderByLastNameDesc(items);
                            break;
                        }
                    case "Nationality":
                        {
                            items = passengerService.OrderByNationality(items);
                            break;
                        }
                    case "nationality_desc":
                        {
                            items = passengerService.OrderByNationalityDesc(items);
                            break;
                        }
                    case "Passport":
                        {
                            items = passengerService.OrderByPassport(items);
                            break;
                        }
                    case "passport_desc":
                        {
                            items = passengerService.OrderByPassportDesc(items);
                            break;
                        }
                    case "DateOfBirthday":
                        {
                            items = passengerService.OrderByDateOfBirthday(items);
                            break;
                        }
                    case "dateOfBirthday_desc":
                        {
                            items = passengerService.OrderByDateOfBirthdayDesc(items);
                            break;
                        }
                    case "Sex":
                        {
                            items = passengerService.OrderBySex(items);
                            break;
                        }
                    case "sex_desc":
                        {
                            items = passengerService.OrderBySexDesc(items);
                            break;
                        }
                    case "PlaceClass":
                        {
                            items = passengerService.OrderByPlaceClass(items);
                            break;
                        }
                    case "placeClass_desc":
                        {
                            items = passengerService.OrderByPlaceClassDesc(items);
                            break;
                        }
                }
            }

            return items;
        }


        // GET: Passenger/Details/5
        public ActionResult Details(int id)
        {
            Mapper.CreateMap<PassengerDTO, PassengerModel>();
            return View(Mapper.Map<PassengerDTO, PassengerModel>(passengerService.GetPassenger(id)));
        }

        // GET: Passenger/Create
        public ActionResult Create(int? id)
        {
            var model = new PassengerModel();
            PopulateDropDownMenues();
            return View(model);
        }

        void PopulateDropDownMenues()
        {
            using (var flightService = new FlightService())
            {
                Mapper.CreateMap<FlightDTO, FlightModel>();
                ViewData["FlightId"] = GetSelectedListOfFlights(Mapper
                    .Map<IEnumerable<FlightDTO>, List<FlightModel>>(flightService.GetFlights()));
            }


            var sex = new List<SelectListItem>();
            sex.Add(new SelectListItem { Value = "0", Text = nameof(Sex.male) });
            sex.Add(new SelectListItem { Value = "1", Text = nameof(Sex.female) });
            ViewData["Sex"] = new SelectList(sex, "Value", "Text");

            var placeClass = new List<SelectListItem>();
            placeClass.Add(new SelectListItem { Value = "0", Text = nameof(PlaceClass.Business) });
            placeClass.Add(new SelectListItem { Value = "1", Text = nameof(PlaceClass.Economy) });

            ViewData["PlaceClass"] = new SelectList(placeClass, "Value", "Text");
        }

        private SelectList GetSelectedListOfFlights(IEnumerable<FlightModel> items)
        {
            var flights = new List<SelectListItem>();
            foreach (var item in items)
            {
                flights.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FlightNumber });
            }
            return new SelectList(flights, "Value", "Text");
        }

        // POST: Passenger/Create
        [HttpPost]
        public ActionResult Create(
            [Bind(Exclude = "Id")]
            PassengerModel passenger)
        {
            try
            {
                passengerService.MakePassenger(
                    ConvertToDALModel(passenger));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(passenger);
            }
        }

        static PassengerDTO ConvertToDALModel(PassengerModel passenger)
        {
            return new PassengerDTO
            {
                FlightId = passenger.FlightId,
                FirstName = passenger.FirstName,
                DateOfBirthday = passenger.DateOfBirthday,
                LastName = passenger.LastName,
                Nationality = passenger.Nationality,
                Passport = passenger.Passport,
                PlaceClass = (PlaceClassDTO)passenger.PlaceClass,
                Sex = (SexDTO)passenger.Sex
            };
        }

        // GET: Passenger/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                Mapper.CreateMap<PassengerDTO, PassengerModel>();
                return View(Mapper.Map<PassengerDTO, PassengerModel>(passengerService.GetPassenger(id)));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Passenger/Edit/5
        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, FlightId, FirstName, LastName, Nationality, Passport, Sex, PlaceClass, DateOfBirthday")]
            PassengerModel passenger)
        {
            try
            {

                var model = ConvertToDALModel(passenger);
                model.Id = passenger.Id;
                passengerService.UpdatePassenger(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(passenger);
            }
        }

        // GET: Passenger/Delete/5
        public ActionResult Delete(int id)
        {
            Mapper.CreateMap<PassengerDTO, PassengerModel>();
            return View(Mapper.Map<PassengerDTO, PassengerModel>(passengerService.GetPassenger(id)));
        }

        // POST: Passenger/Delete/5
        [HttpPost]
        public ActionResult Delete(
            [Bind(Include = "Id, FlightId, FirstName, LastName, Nationality, Passport, Sex, PlaceClass, DateOfBirthday")]
            PassengerModel passenger)
        {
            try
            {
                passengerService.DeletePassenger(passenger.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(passenger);
            }
        }

        public new void Dispose()
        {
            passengerService.Dispose();
        }
    }
}
