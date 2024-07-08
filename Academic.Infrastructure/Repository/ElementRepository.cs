using Academic.Core.Entities;
using Academic.Core.Interfaces;
using Academic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Infrastructure.Repository
{
    public class ElementRepository<T> : IElementRepository<T> where T:class
    {
        private readonly ApplicationDbContext context;
        public ElementRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteElement(T? element)
        {
            context.Set<T>().Remove(element);
        }

        public T? GetElement(Func<T, bool> predicate, string? include)
        {
            if (include == null)
            {
                return  context.Set<T>().Where(predicate).FirstOrDefault();
            }

            return context.Set<T>().Include(include).Where(predicate).FirstOrDefault();
        }

        public List<T>? GetElements(Func<T, bool> predicate, string? include)
        {
            if (include == null)
            {
                return context.Set<T>().Where(predicate).ToList();
            }
            return context.Set<T>().Include(include).Where(predicate).ToList();
        }
    }
}
