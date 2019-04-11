using System.Collections.Generic;
using BaseJWT.Domain.Entity;
using BaseJWT.Domain.Entity.Orders;
using BaseJWT.Domain.Entity.Shop;
using Microsoft.AspNetCore.Mvc;

namespace BaseJWT.Domain.Interface
{
  public interface IStoreRepository
  {
    IEnumerable<Product> GetAllProducts();
    IEnumerable<Product> GetProductsByCategory(string category);

    IEnumerable<Order> GetAllOrders(bool includeItems);
    IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
    Order GetOrderById(string username, int id);
    void AddOrder(Order newOrder);

    bool SaveAll();
    void AddEntity(object model);
  }
}