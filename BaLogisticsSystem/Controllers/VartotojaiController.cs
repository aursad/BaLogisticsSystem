using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Service.Persons;

namespace BaLogisticsSystem.Controllers
{
    public class VartotojaiController : Controller
    {
        private readonly IPersonsService _personsService;

        public VartotojaiController(IPersonsService personsService)
        {
            _personsService = personsService;
        }
        // GET: Vartotojai
        public ActionResult Index()
        {
            var userList = _personsService.GetList();

            return View(userList.ToList());
        }

        // GET: Vartotojai/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var personModel = _personsService.GetSingle((Guid)id);
            if (personModel == null)
            {
                return HttpNotFound();
            }

            return View(personModel);
        }

        // GET: Vartotojai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vartotojai/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create([FromBody]PersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var personEntity = new PersonEntity
                    {
                        Name = model.Name,
                        LastName = model.LastName,
                        Email = model.Email,
                        Address = model.Address,
                        MobilePhone = model.MobilePhone,
                        Birthday = model.Birthday
                    };

                    _personsService.CreatePerson(personEntity);

                    ViewBag.RegisteredUser = true;
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Nepavyko sukurti vartotojo!");
            }
            return View(model);
        }

        // GET: Vartotojai/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Vartotojai/Edit/5
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, [FromBody] PersonEntity model)
        {
            if (ModelState.IsValid)
            {
            }
            return null;
        }

        // GET: Vartotojai/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        public ActionResult BlockUser(Guid id)
        {
            if (id != Guid.Empty)
            {
                var entity = _personsService.GetSingle(id);

                if (entity != null)
                {
                    return View(entity);
                }
            }

            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult BlockUser(Guid id, FormCollection collection)
        {
            try
            {
                _personsService.BlockUser(id);

                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // POST: Vartotojai/Delete/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
