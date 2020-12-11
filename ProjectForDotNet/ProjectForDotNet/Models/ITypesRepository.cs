using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjectForDotNet.Models
{
    public interface ITypesRepository
    {
        IQueryable<Type> Type { get; }
        Type Save(Type types);
        void Delete(Type types);

    }
}