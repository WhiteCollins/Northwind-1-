using Microsoft.AspNetCore.Mvc;
using Northwind.Web.IServices;
using Northwind.Web.Models;


namespace Northwind.Web.Controllers
{
    public class ShippersController : Controller
    {
        private readonly IShippersServices _shipperService;

        public ShippersController(IShippersServices shipperService)
        {
            _shipperService = shipperService;
        }

        // GET: ShippersController
        public async Task<ActionResult> Index()
        {
            var shipperGetListResult = await _shipperService.GetShippersAsync();
            if (shipperGetListResult != null && shipperGetListResult.success)
            {
                return View(shipperGetListResult.result);
            }

            ViewBag.Message = shipperGetListResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: ShippersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var shipperGetResult = await _shipperService.GetShipperByIdAsync(id);
            if (shipperGetResult != null && shipperGetResult.success)
            {
                return View(shipperGetResult.result);
            }

            ViewBag.Message = shipperGetResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: ShippersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShippersBaseModel shipper)
        {
            var result = await _shipperService.CreateShipperAsync(shipper);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(shipper);
        }

        // GET: ShippersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var shipperGetResult = await _shipperService.GetShipperByIdAsync(id);
            if (shipperGetResult != null && shipperGetResult.success)
            {
                return View(shipperGetResult.result);
            }

            ViewBag.Message = shipperGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: ShippersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ShippersBaseModel shipper)
        {
            var result = await _shipperService.UpdateShipperAsync(id, shipper);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(shipper);
        }

        // GET: ShippersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var shipperGetResult = await _shipperService.GetShipperByIdAsync(id);
            if (shipperGetResult != null && shipperGetResult.success)
            {
                return View(shipperGetResult.result);
            }

            ViewBag.Message = shipperGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: ShippersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _shipperService.DeleteShipperAsync(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
