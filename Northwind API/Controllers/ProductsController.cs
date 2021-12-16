using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind_API.Model;

namespace Northwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {

        private readonly MyContext _context;

        
        // GET: SuppliersController
        public ProductsController(MyContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public ActionResult<Products> GetProduct(int id)
        {

           

            var supp = _context.Products.Include(p =>p.Category).Include(p => p.Supplier).FirstOrDefault(p => p.ProductId == id);

      
            if (supp == null)
            {
                return BadRequest("Not a valid Product id");
            }
            
            return supp;
        }

        [HttpGet]
        public List<Products> GetProducts()
        {
       
            var supp = _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();

            return supp;
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, Products products)
        {

            var sup = _context.Products.Find(id);
            if (sup != null)
            {
                sup.ProductId = products.ProductId;
                sup.ProductName = products.ProductName;
                sup.SupplierID = products.SupplierID;
                sup.CategoryID = products.CategoryID;
                sup.QuantityPerUnit = products.QuantityPerUnit;
                sup.UnitPrice = products.UnitPrice;
                sup.UnitsInStock = products.UnitsInStock;
                sup.UnitsOnOrder = products.UnitsOnOrder;
                sup.ReorderLevel = products.ReorderLevel;
                sup.Discontinued = products.Discontinued;
                _context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var supp = _context.Products.Find(id);
            if (supp == null)
            {
                return BadRequest("Not a valid Product id");
            }

            else
            {
                _context.Products.Remove(supp);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult Post(Products products)
        {

            var supp = _context.Products.Where(s => s.ProductId == products.ProductId).FirstOrDefault();
            if (supp == null)
            {
                _context.Products.Add(products);
                _context.SaveChanges();
                return CreatedAtAction("Post", new { id = products.ProductId }, products);
            }
            else
            {

                return BadRequest("Product id exists already");
            }
        }
    }
}
