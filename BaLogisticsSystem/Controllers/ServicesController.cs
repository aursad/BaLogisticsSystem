using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Service.Organizations;
using BaLogisticsSystem.Service.Persons;
using BaLogisticsSystem.Service.Service;

namespace BaLogisticsSystem.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IOrganizationService _organizationService;
        private readonly IPersonsService _personsService;

        public ServicesController(IServiceService serviceService, IOrganizationService organizationService, IPersonsService personsService)
        {
            _serviceService = serviceService;
            _organizationService = organizationService;
            _personsService = personsService;
        }
        // GET: Services
        public ActionResult Index()
        {
            var entities = _serviceService.GetList();
            if (entities != null)
            {
                var serviceViewModels = entities.Select(x => new ServiceViewModel
                {
                    IdService = x.IdService,
                    Title = x.Title,
                    IdOrganization = x.IdOrganization,
                });
                return View(serviceViewModels);
            }
            return View();
        }

        // GET: Services/Details/170e4cee-5335-4edf-aa33-663127c93200
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var serviceEntity = _serviceService.GetSingle((Guid)id);
            if (serviceEntity == null)
            {
                return HttpNotFound();
            }

            var serviceViewModel = new ServiceViewModel
            {
                IdOrganization = serviceEntity.IdOrganization,
                Title = serviceEntity.Title,
                IdService = serviceEntity.IdService,
                Organization = SetOrganization(serviceEntity.IdOrganization)
            };

            return View(serviceViewModel);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create([FromBody]ServiceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var serviceEntity = new ServiceEntity
                    {
                        Title = model.Title,
                        IdOrganization = model.IdOrganization,
                    };

                    var createdEntity = _serviceService.CreateService(serviceEntity);

                    ViewBag.RegisteredUser = true;
                    return RedirectToAction("Details", new { id = createdEntity.IdService });
                }
            }
            catch
            {
                ModelState.AddModelError("", "Nepavyko sukurti vartotojo!");
            }
            return View(model);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Services/Edit/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Services/Delete/5
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

        private OrganizationViewModel SetOrganization(Guid idOrganization)
        {
            var entity = _organizationService.GetSingle(idOrganization);
            if (entity != null)
            {
                return new OrganizationFullViewModel
                {
                    IdOrganization = entity.IdOrganization,
                    Address = entity.Address,
                    Name = entity.Name
                };
            }
            return null;
        }
    }
}
