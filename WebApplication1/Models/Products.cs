using System.ComponentModel.DataAnnotations;

namespace Northwind_MVC.Model
{
    public class Products
    {

        [Key]
        public int ProductId { get; set;}
        public string ProductName { get; set;}

        public int SupplierID { get; set;}
        
        public int CategoryID { get; set;}

        public string? QuantityPerUnit { get; set;}

        public int UnitPrice { get; set;}

        public int UnitsInStock { get; set;}

        public int UnitsOnOrder { get; set;}

        public int ReorderLevel { get; set;}

        public int Discontinued {get; set;}

    }
}
