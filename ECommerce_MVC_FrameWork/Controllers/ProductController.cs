using ECommerce_MVC_FrameWork.Models;
using ECommerce_MVC_FrameWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECommerce_MVC_FrameWork.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        // GET: Product
        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllProduct();
            return View(products);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Search(string name)
        {
            var products = await _productService.GetProductByName(name);
            ViewBag.SearchTerm = name; 
            return View("Index", products); 
        }

    }
}