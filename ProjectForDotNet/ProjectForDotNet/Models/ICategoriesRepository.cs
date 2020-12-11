using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> Category { get; }
        Category Save(Category categories);
        void Delete(Category categories);

    }
}