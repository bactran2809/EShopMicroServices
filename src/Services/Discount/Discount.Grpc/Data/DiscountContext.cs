using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> contextOptions): base(contextOptions)
        {
            
        }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id=1, ProductName="Product A", Description="Product A", Amount = 1000000},
                new Coupon { Id=2, ProductName="Product B", Description="Product B", Amount = 1500000}
                );
        }
    }
}
