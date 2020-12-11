using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class EFTransportsRepository:ITransportsRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Transport> Transport { get { return context.Transports; } }

        public Transport Save(Transport transport)
        {
            if (transport.TransportId == 0)
            {
                context.Transports.Add(transport);
            }
            else
            {
                context.Entry(transport).State = EntityState.Modified;
            }
            context.SaveChanges();
            return transport;
        }

        public void Delete(Transport transport)
        {
            context.Transports.Remove(transport);
            context.SaveChanges();
        }
    }
}