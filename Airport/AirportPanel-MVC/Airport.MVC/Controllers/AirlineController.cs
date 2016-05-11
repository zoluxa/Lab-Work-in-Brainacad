
namespace Airport.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Mvc;
    using AutoMapper;
    using BLL.DTO;
    using BLL.Services;
    using Models;

    [Authorize]
    public class AirlineController : Controller, IDisposable
    {
        AirlineService airlineService;

        public AirlineController()
        {
            airlineService = new AirlineService();
        }

        // GET: Airline
        [HttpGet]
        public ActionResult Index(string searchString, string sortOrder)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) || sortOrder == "Name" ? "name_desc" : "Name";

            Mapper.CreateMap<AirlineDTO, AirlineModel>();
            var list = airlineService.GetAirlines();
            if (!string.IsNullOrEmpty(searchString))
            {
                list = airlineService.FindByName(searchString);
            }

            switch (sortOrder)
            {
                case "Name":
                    {
                        list = airlineService.OrderByName(list);
                        break;
                    }
                case "name_desc":
                    {
                        list = airlineService.OrderByNameDesc(list);
                        break;
                    }
            }

            return View(Mapper
                .Map<IEnumerable<AirlineDTO>, List<AirlineModel>>(list));
        }

        // GET: Airline/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            Mapper.CreateMap<AirlineDTO, AirlineModel>();
            return View(Mapper.Map<AirlineDTO, AirlineModel>(airlineService.GetAirline(id)));
        }

        // GET: Airline/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new AirlineModel();
            return View(model);
        }

        // POST: Airline/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]AirlineModel airline)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    airlineService.MakeAirline(new AirlineDTO
                    {
                        Name = airline.Name
                    });
                }

                return RedirectToAction("Index");
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("",
                    $"Unable to save changes. Try again and if problem persist, see your system administrator ({ex.Message})");
            }
            return View(airline);

        }

        // GET: Airline/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Mapper.CreateMap<AirlineDTO, AirlineModel>();
            return View(Mapper.Map<AirlineDTO, AirlineModel>(airlineService.GetAirline(id)));
        }

        // POST: Airline/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name")] AirlineModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    airlineService.UpdateAirline(new AirlineDTO
                    {
                        Name = model.Name
                    });
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    $@"Unable to update airline model in database.
                    Try again and if an error persist see administrator. ({ex.Message})");
            }
            return View(model);
        }

        // GET: Airline/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = new AirlineModel();
            try
            {
                Mapper.CreateMap<AirlineDTO, AirlineModel>();
                model = Mapper.Map<AirlineDTO, AirlineModel>(airlineService.GetAirline(id));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("",
                    $"Unable to find item to delete. ({ex.Message})");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: Airline/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Name")]AirlineModel model)
        {
            try
            {
                airlineService.DeleteAirline(model.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete item.");
                return View(model);
            }
        }

        protected new void Dispose(bool disposing)
        {
            airlineService.Dispose();
        }

    }
}
