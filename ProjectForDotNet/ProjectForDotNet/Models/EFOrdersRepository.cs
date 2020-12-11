using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class EFOrdersRepository:IOrdersRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Order> Order { get { return context.Orders; } }

        public Order Save(Order order)
        {
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                context.Entry(order).State = EntityState.Modified;
            }
            context.SaveChanges();
            return order;
        }

        public void Delete(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }
    }
}