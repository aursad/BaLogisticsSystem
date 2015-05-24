using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Transaction;
using BaLogisticsSystem.Service.Shipment;
using BaLogisticsSystem.Service.Transaction;

namespace BaLogisticsSystem.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService;
        private readonly ITransactionService _transactionService;

        public ShipmentController(IShipmentService shipmentService, ITransactionService transactionService)
        {
            _shipmentService = shipmentService;
            _transactionService = transactionService;
        }
        // GET: Shipment
        public ActionResult Index()
        {
            var entities = _shipmentService.GetList();
            if (entities != null)
            {
                var serviceViewModels = entities.Select(x => new ShipmentViewModel
                {
                    IdService = x.IdService,
                    Title = x.Title,
                    IdShipment = x.IdShipment,
                    Status = x.Status,
                    Created = x.CreatedDate,
                    LastUpdate = x.UpdatedDate
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

            var shipmentEntity = _shipmentService.GetSingle((Guid)id);
            if (shipmentEntity == null)
            {
                return HttpNotFound();
            }

            var serviceViewModel = new ShipmentViewModel
            {
                IdService = shipmentEntity.IdService,
                Title = shipmentEntity.Title,
                IdShipment = shipmentEntity.IdShipment,
                Status = shipmentEntity.Status,
                Created = shipmentEntity.CreatedDate,
                LastUpdate = shipmentEntity.UpdatedDate,
                Latitude = shipmentEntity.Latitude,
                Longitude = shipmentEntity.Longitude,
                StartTime = shipmentEntity.StartTime,
                EndTime = shipmentEntity.StartTime,
                Transactions = _transactionService.GetList(shipmentEntity.IdShipment)
            };

            return View(serviceViewModel);
        }

        // GET: Shipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipment/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create([FromBody]ShipmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var shipmentEntity = new ShipmentEntity
                    {
                        Title = model.Title,
                        IdService = model.IdService
                    };

                    var createdEntity = _shipmentService.CreateShipment(shipmentEntity);

                    ViewBag.RegisteredUser = true;
                    return RedirectToAction("Details", new { id = createdEntity.IdShipment });
                }
            }
            catch
            {
                ModelState.AddModelError("", "Nepavyko sukurti vartotojo!");
            }
            return View(model);
        }

        // GET: Shipment/Edit/5
        public ActionResult Edit(Guid id)
        {
            var shipmentEntity = _shipmentService.GetSingle(id);

            var serviceViewModel = new ShipmentViewModel
            {
                IdService = shipmentEntity.IdService,
                Title = shipmentEntity.Title,
                IdShipment = shipmentEntity.IdShipment,
                Status = shipmentEntity.Status,
                Created = shipmentEntity.CreatedDate,
                LastUpdate = shipmentEntity.UpdatedDate,
                Latitude = shipmentEntity.Latitude,
                Longitude = shipmentEntity.Longitude,
                StartTime = shipmentEntity.StartTime,
                EndTime = shipmentEntity.StartTime
            };

            return View(serviceViewModel);
        }

        // POST: Shipment/Edit/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Guid id, [FromBody]ShipmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var shipmentEntity = _shipmentService.GetSingle(id);
                    shipmentEntity.Title = model.Title;
                    shipmentEntity.IdService = model.IdService;
                    shipmentEntity.Latitude = model.Latitude;
                    shipmentEntity.Longitude = model.Longitude;

                    _shipmentService.Update(shipmentEntity);

                    return RedirectToAction("Details", new { id = shipmentEntity.IdShipment });
                }
            }
            catch
            {
                ModelState.AddModelError("", "Nepavyko sukurti vartotojo!");
            }
            return View(model);
        }

        // GET: Shipment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shipment/Delete/5
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
