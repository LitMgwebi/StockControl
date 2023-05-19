using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockControl.Models;

namespace StockControl.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Department>? Departments { get; set; }
        public virtual DbSet<Employee>? Employees { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<Purchase_Order>? Purchase_Order { get; set; }
        public virtual DbSet<Purchase_Order_Detail>? Purchase_Order_Detail { get; set; }
        public virtual DbSet<Purchase_Request>? Purchase_Request { get; set; }
        public virtual DbSet<Purchase_Request_Detail>? Purchase_Request_Detail { get; set; }
        public virtual DbSet<Supplier>? Suppliers { get; set; }
    }
}