using ECommerce_MVC_FrameWork.Models;
using ECommerce_MVC_FrameWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult GetAllProduct()
        {
            try
            {
                return View(_productService.GetAllProduct());
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return an error view or message
                return View("Error", new HandleErrorInfo(ex, "Product", "GetAllProduct"));
            }
        }

        public ActionResult GetProduct(int id)
        {
            try
            {
                return View(_productService.GetProduct(id));
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return an error view or message
                return View("Error", new HandleErrorInfo(ex, "Product", "GetProduct"));
            }
        }

        public ActionResult GetProductByName(string name)
        {
            try
            {
                return View(_productService.GetProductByName(name));
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return an error view or message
                return View("Error", new HandleErrorInfo(ex, "Product", "GetProductByName"));
            }
        }

        public ActionResult AddProduct(Product product)
        {
            try
            {
                _productService.AddProduct(product);
                return RedirectToAction("GetAllProduct");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return an error view or message
                return View("Error", new HandleErrorInfo(ex, "Product", "AddProduct"));
            }
        }

        public ActionResult EditProduct(Product product)
        {
            try
            {
                _productService.UpdateProduct(product);
                return RedirectToAction("GetAllProduct");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return an error view or message
                return View("Error", new HandleErrorInfo(ex, "Product", "EditProduct"));
            }
        }

        public ActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return RedirectToAction("GetAllProduct");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return an error view or message
                return View("Error", new HandleErrorInfo(ex, "Product", "DeleteProduct"));
            }
        }
    }
}