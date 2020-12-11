using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class EFCategoriesRepository :ICategoriesRepository
    { 
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Category> Category{ get { return context.Categories; } }

        public Category Save(Category category)
        {
            if (category.CategoryId == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                context.Entry(category).State = EntityState.Modified;
            }
            context.SaveChanges();
            return category;
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

    }
}