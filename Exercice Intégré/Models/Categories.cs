using System.ComponentModel.DataAnnotations;

namespace Northwind_MVC.Model
{
    public class Categories
    {

        public Categories() {
        }
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }        
       

    }
}
