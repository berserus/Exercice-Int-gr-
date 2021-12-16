using Exercice_Intégré.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind_MVC.Model;

namespace Exercice_Intégré.Controllers
{
    public class ProductsController : Controller
    {
        ProductServices productServices;
 
      
        public ProductsController(ProductServices productServices) {
            this.productServices = productServices;
     
        }


        public async Task<IActionResult> Index(string SearchString)
        {

            
            if (TempData.ContainsKey("toastrMessage")) {
                var toastrValue = TempData["toastrMessage"].ToString();
                
                ViewBag.ToastrMessage = toastrValue;
            }

            var products = await productServices.getProducts();
            var genre = products.Select(s => s.Supplier.CompanyName).Distinct();
            if (!String.IsNullOrEmpty(SearchString))
            {

                var productsFoundBySearch = products.Where(s => s.ProductName!.Contains(SearchString));
                return View(productsFoundBySearch);
            }
            
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
        public async Task<IActionResult> Edit( Products model)
        {
            try
            {
                TempData["toastrMessage"] = "Product has been updated !";
                return RedirectToAction("Details",  new {id = model.ProductId});
            }
            catch
            {
                return View();
            }

        }


        public async Task<IActionResult> Create()
        {
            return View();
        
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Products model)
        {
            var product = await productServices.Create(model);

          
                return RedirectToAction("Details",new { id = product.ProductId });
            
          

        }


        public async Task<IActionResult> DeletePage(int id)
        {
            var product = await productServices.getProduct(id);
            return View(product);
                

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Products product)
        {
            var prod = await productServices.Delete(product.ProductId);
            TempData["toastrMessage"] = "Products has been correctly deleted";
            return   RedirectToAction("Index");

        }


    }
}
