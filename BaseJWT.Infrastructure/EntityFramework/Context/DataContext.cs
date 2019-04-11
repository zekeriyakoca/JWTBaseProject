using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseJWT.Domain.Entity;
using BaseJWT.Domain.Entity.Orders;
using BaseJWT.Domain.Entity.Shop;
using BaseJWT.Infrastructure.EntityFramework.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaseJWT.Infrastructure.EntityFramework.Context
{
  public class DataContext : IdentityDbContext<User>
  {
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderItemConfig());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
        }

  }
}
