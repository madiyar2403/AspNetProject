using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForDotNet.Models
{
    public interface IOrdersRepository
    {
        IQueryable<Order> Order { get; }
        Order Save(Order orders);
        void Delete(Order orders);
    }
}
