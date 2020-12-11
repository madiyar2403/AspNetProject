using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public interface ITransportsRepository
    {
        IQueryable<Transport> Transport { get; }
        Transport Save(Transport transports);
        void Delete(Transport transports);
    }
}