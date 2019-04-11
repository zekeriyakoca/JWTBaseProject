using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseJWT.Domain.Entity;
using BaseJWT.Domain.Entity.Orders;
using BaseJWT.Domain.Entity.Shop;
using BaseJWT.Domain.Interface;
using BaseJWT.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BaseJWT.Infrastructure.Repository
{
  public class DutchRepository : IStoreRepository
  {
    private readonly DataContext _ctx;
    private readonly ILogger<DutchRepository> _logger;

    public DutchRepository(DataContext ctx, ILogger<DutchRepository> logger)
    {
      _ctx = ctx;
      _logger = logger;
    }

    public void AddEntity(object model)
    {
      _ctx.Add(model);
    }

        public void AddOrder(Order newOrder)
        {
            // Convert new products to lookup of product
            foreach (var item in newOrder.Items)
            {
                item.Product = _ctx.Products.Find(item.Product.Id);
            }

            AddEntity(newOrder);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {

                return _ctx.Orders
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Product)
                           .ToList();

            }
            else
            {
                return _ctx.Orders.ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {

                return _ctx.Orders
                           .Where(o => o.Customer.UserName == username)
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Product)
                           .ToList();

            }
            else
            {
                return _ctx.Orders
                           .Where(o => o.Customer.UserName == username)
                           .ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");

                return _ctx.Products
                          // .OrderBy(p => p.Title)
                           .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders
                       .Include(o => o.Items)
                       .ThenInclude(i => i.Product)
                       .Where(o => o.Id == id && o.Customer.UserName == username)
                       .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                      // .Where(p => p.Category == category)
                       .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
