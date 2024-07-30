using Microsoft.AspNetCore.Mvc;
using Northwind.Web.IServices;
using Northwind.Web.Models;


namespace ShopMicroServices.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersServices _supplierService;

        public SuppliersController(ISuppliersServices supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: SuppliersController
        public async Task<ActionResult> Index()
        {
            var supplierGetListResult = await _supplierService.GetSuppliersAsync();
            if (supplierGetListResult != null && supplierGetListResult.success)
            {
                return View(supplierGetListResult.result);
            }

            ViewBag.Message = supplierGetListResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: SuppliersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var supplierGetResult = await _supplierService.GetSupplierByIdAsync(id);
            if (supplierGetResult != null && supplierGetResult.success)
            {
                return View(supplierGetResult.result);
            }

            ViewBag.Message = supplierGetResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SuppliersBaseModel supplier)
        {
            var result = await _supplierService.CreateSupplierAsync(supplier);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(supplier);
        }

        // GET: SuppliersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var supplierGetResult = await _supplierService.GetSupplierByIdAsync(id);
            if (supplierGetResult != null && supplierGetResult.success)
            {
                return View(supplierGetResult.result);
            }

            ViewBag.Message = supplierGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SuppliersBaseModel supplier)
        {
            var result = await _supplierService.UpdateSupplierAsync(id, supplier);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(supplier);
        }

        // GET: SuppliersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var supplierGetResult = await _supplierService.GetSupplierByIdAsync(id);
            if (supplierGetResult != null && supplierGetResult.success)
            {
                return View(supplierGetResult.result);
            }

            ViewBag.Message = supplierGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: SuppliersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _supplierService.DeleteSupplierAsync(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
