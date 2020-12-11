using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class EFTypesRepository: ITypesRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Type> Type { get { return context.Types; } }

        public Type Save(Type type) {
            if (type.TypeId == 0) 
            {
                context.Types.Add(type);
            }
            else 
            {
                context.Entry(type).State = EntityState.Modified;
            }
            context.SaveChanges();
            return type;
        }

        public void Delete(Type type) 
        {
            context.Types.Remove(type);
            context.SaveChanges();
        }

    }
}