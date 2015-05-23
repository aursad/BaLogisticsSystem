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
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;
        private readonly IPersonsService _personsService;
        private readonly IServiceService _serviceService;

        public OrganizationController(IOrganizationService organizationService, IPersonsService personsService, IServiceService serviceService)
        {
            _organizationService = organizationService;
            _personsService = personsService;
            _serviceService = serviceService;
        }
        // GET: Organization
        public ActionResult Index()
        {
            var entities = _organizationService.GetList();
            var organizationEntities = entities.Select(x => new OrganizationViewModel
            {
                IdOrganization = x.IdOrganization,
                Name = x.Name,
                Address = x.Address,
                IsActive = x.IsActive,
                OrganizationType = x.OrganizationType
            });
            return View(organizationEntities);
        }

        // GET: Organization/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var organizationEntity = _organizationService.GetSingle((Guid)id);
            if (organizationEntity == null)
            {
                return HttpNotFound();
            }

            var organizationViewModel = new OrganizationFullViewModel
            {
                IdOrganization = organizationEntity.IdOrganization,
                Name = organizationEntity.Name,
                Address = organizationEntity.Address,
                IsActive = organizationEntity.IsActive,
                OrganizationType = organizationEntity.OrganizationType,
                Persons = _personsService.PersonsInOrganization(organizationEntity.IdOrganization),
                Services = _serviceService.GetServicesByOrganization(organizationEntity.IdOrganization)
            };

            return View(organizationViewModel);
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create([FromBody]OrganizationViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
