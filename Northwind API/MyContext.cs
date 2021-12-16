using Microsoft.EntityFrameworkCore;
using Northwind_API.Model;

namespace Northwind_API
{
    public partial class MyContext : DbContext
    {

        public  DbSet<Suppliers> Suppliers { get; set; }
        
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Suppliers>().ToTable("Suppliers");

            modelBuilder.Entity<Categories>().ToTable("Categories");

            modelBuilder.Entity<Products>().HasOne(s => s.Supplier).WithMany().HasForeignKey(p => p.SupplierID);

            modelBuilder.Entity<Products>().HasOne(s => s.Category).WithMany().HasForeignKey(p => p.SupplierID);


        }


    }
}
