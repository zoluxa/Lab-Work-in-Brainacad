
namespace Airport.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using BLL.DTO;
    using BLL.Services;
    using Models;

    [Authorize]
    public class PortController : Controller
    {
        readonly PortService portService;

        public PortController()
        {
            portService = new PortService();
        }

        // GET: Port
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameOrderParam = string.IsNullOrEmpty(sortOrder)|| sortOrder == "Name" ? "name_desc" : "Name";


            Mapper.CreateMap<PortDTO, PortModel>();

            var list = portService.GetPorts();

            if (!string.IsNullOrEmpty(searchString))
            {
                list = portService.FindByName(searchString);
            }

            // Handle ordering
            switch (sortOrder)
            {
                case "Name":
                    {
                        list = portService.OrderByName(list);
                        break;
                    }
                case "name_desc":
                    {
                        list = portService.OrderByNameDesc(list);
                        break;
                    }
            }

            return View(Mapper
                .Map<IEnumerable<PortDTO>, List<PortModel>>(list));
        }


        // GET: Port/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Mapper.CreateMap<PortDTO, PortModel>();
                return View(Mapper
                    .Map<PortDTO, PortModel>(portService.GetPort(id)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    $"Unable to find item to see details. ({ex.Message})");
                return RedirectToAction("Index");

            }
        }

        // GET: Port/Create
        public ActionResult Create()
        {
            var model = new PortModel();
            return View(model);
        }

        // POST: Port/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name")] PortModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    portService.MakePort(
                        new PortDTO
                        {
                            Name = model.Name
                        });                    
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    $"Unable to save item. Try again or see your administrator.({ex.Message})");
            }
            return View(model);
        }

        // GET: Port/Edit/5
        public ActionResult Edit(int Id)
        {
            var model = new PortModel();
            try
            {
                Mapper.CreateMap<PortDTO, PortModel>();
                return View(Mapper
                    .Map<PortDTO, PortModel>(portService.GetPort(Id)));

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("",
                    $"Unable to find item to edit. ({ex.Message})");
                return RedirectToAction("Index");
            }
        }

        // POST: Port/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name")] PortModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    portService.UpdatePort(new PortDTO
                    {
                        Id = model.Id,
                        Name = model.Name
                    });                    
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("",
                    $"Unable to edit item. ({ex.Message})");
            }
            return View(model);
        }

        // GET: Port/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new PortModel();
            try
            {
                Mapper.CreateMap<PortDTO, PortModel>();
                return View(Mapper
                    .Map<PortDTO, PortModel>(portService.GetPort(id)));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("",
                    $"Unable to find item to delete. ({ex.Message})");
                return RedirectToAction("Index");
            }
        }

        // POST: Port/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Name")]PortModel model)
        {
            try
            {
                portService.DeletePort(model.Id);                
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete item.");
                return View(model);
            }
        }

        public new void Dispose()
        {
            portService.Dispose();
        }
    }
}
