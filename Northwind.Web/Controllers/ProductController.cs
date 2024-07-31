using Microsoft.AspNetCore.Mvc;
using Northwind.Web.IServices;
using Northwind.Web.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Northwind.Web.Result.ProductResult;
using Northwind.Web.Result;

namespace Northwind.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsServices _productService;

        public ProductsController(IProductsServices productService)
        {
            _productService = productService;
        }

        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var productGetListResult = await _productService.GetProductsAsync();
            if (productGetListResult != null && productGetListResult.success)
            {
                return View(productGetListResult.result);
            }

            ViewBag.Message = productGetListResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: ProductsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var productGetResult = await _productService.GetProductByIdAsync(id);
            if (productGetResult != null && productGetResult.success)
            {
                return View(productGetResult.result);
            }

            ViewBag.Message = productGetResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductBaseModel product)
        {
            var result = await _productService.CreateProductAsync(product);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(product);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var productGetResult = await _productService.GetProductByIdAsync(id);
            if (productGetResult != null && productGetResult.success)
            {
                return View(productGetResult.result);
            }

            ViewBag.Message = productGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductBaseModel product)
        {
            var result = await _productService.UpdateProductAsync(id, product);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(product);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var productGetResult = await _productService.GetProductByIdAsync(id);
            if (productGetResult != null && productGetResult.success)
            {
                return View(productGetResult.result);
            }

            ViewBag.Message = productGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}

