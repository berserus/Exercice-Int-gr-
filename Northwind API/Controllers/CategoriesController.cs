using Microsoft.AspNetCore.Mvc;
using Northwind_API.Model;

namespace Northwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly MyContext _context;
        // GET: SuppliersController
        public CategoriesController(MyContext context)
        {
            _context = context;
        }
      

        [HttpGet("{id}")]
        public ActionResult<Categories> GetCategory(int id)
        {


            var supp = _context.Categories.Find(id);
            if (supp == null)
            {
                return BadRequest("Not a valid Category id");
            }

            return supp;
        }

        [HttpGet]
        public List<Categories> GetCategories()
        {
            var supp = _context.Categories.ToList();

            return supp;
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id,  Categories categories)
        {

            var sup = _context.Categories.Find(id);
            if (sup != null)
            {
                sup.CategoryID = categories.CategoryID;
                sup.CategoryName = categories.CategoryName;
                sup.Description = categories.Description;
   

                _context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var supp = _context.Categories.Find(id);
            if (supp == null)
            {
                return BadRequest("Not a valid Category id");
            }

            else
            {
                _context.Categories.Remove(supp);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult Post(Categories categories)
        {

            var supp = _context.Categories.Where(s => s.CategoryID == categories.CategoryID).FirstOrDefault();
            if (supp == null)
            {
                _context.Categories.Add(categories);
                _context.SaveChanges();
                return CreatedAtAction("Post", new { id = categories.CategoryID }, categories);
            }
            else
            {

                return BadRequest("Categories id exists already");
            }
        }
    }
}
