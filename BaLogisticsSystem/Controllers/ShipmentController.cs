using System.Linq;
using System.Web.Mvc;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Service.Shipment;

namespace BaLogisticsSystem.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
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

        // GET: Shipment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Shipment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shipment/Edit/5
        [HttpPost]
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

        // GET: Shipment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shipment/Delete/5
        [HttpPost]
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
