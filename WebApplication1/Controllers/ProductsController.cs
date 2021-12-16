using Exercice_Intégré.Services;
using Microsoft.AspNetCore.Mvc;
using Northwind_MVC.Model;

namespace Exercice_Intégré.Controllers
{
    public class ProductsController : Controller
    {
        ProductServices productServices;
        public ProductsController(ProductServices productServices) {
            this.productServices = productServices;
        }
        

        public async Task<IActionResult> Index()
        {
            var products = await productServices.getProducts();
            return View(products);
        }

        public async Task<IActionResult> Details(int id) {
            var product = await productServices.getProduct(id);
            return View(product);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await productServices.getProduct(id);
            return View(product);

        }

        [HttpPost]

        public IActionResult Edit(Products model)
        {
            try
            {
                return RedirectToAction("Details",  new {id = model.ProductId});
            }
            catch
            {
                return View();
            }
            /*Console.WriteLine("ok");
            var product = await productServices.getProduct(1);
            return View(product);*/

        }




    }
}
