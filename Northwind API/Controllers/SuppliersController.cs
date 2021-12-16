using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {


        private readonly MyContext _context;
        // GET: SuppliersController
        public SuppliersController(MyContext context)
        {
            _context = context;
        }
        //[HttpGet(Name = "GetSupplier")]
        //public Suppliers Get(int index)
        //{
        //    var supplier = _context.Suppliers.Find(index);
        //    return supplier;
        //}

        [HttpGet("{id}")]
        public ActionResult<Suppliers> GetSupplier(int id)
        {
            var supp = _context.Suppliers.Find(id);
            if (supp == null)
            {
                return BadRequest("Not a valid Supplier id");
            }

            return supp;
        }

        [HttpGet]
        public List<Suppliers> GetSuppliers()
        {
            var supp = _context.Suppliers.ToList();

            return supp;
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, Suppliers supplier) {


            var sup = _context.Suppliers.Find(id);
            if (sup != null)
            {

                sup.SupplierID = supplier.SupplierID;
                sup.CompanyName = supplier.CompanyName;
                sup.ContactName = supplier.ContactName;
                sup.ContactTitle = supplier.ContactTitle;
                sup.Address = supplier.Address;
                sup.City = supplier.City;
                sup.Region = supplier.Region;
                sup.PostalCode = supplier.PostalCode;
                sup.Country = supplier.Country;
                sup.Phone = supplier.Phone;
                sup.Fax = supplier.Fax;
                sup.HomePage = supplier.HomePage;

                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
            

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var supp = _context.Suppliers.Find(id);
 
            if (supp == null) {
                return BadRequest("Not a valid Supplier id");
            }

            else {
                _context.Suppliers.Remove(supp);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult Post(Suppliers supplier) { 
            
            var supp = _context.Suppliers.Where(s => s.SupplierID == supplier.SupplierID).FirstOrDefault();
            if (supp == null)
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return CreatedAtAction("Post", new {id = supplier.SupplierID }, supplier) ;
            }
            else {

                return BadRequest("Supplier id already in database");
            }
        }
    }
}
