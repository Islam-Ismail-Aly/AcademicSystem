using Academic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Core.Interfaces
{
    public interface IElementRepository<T> where T: class
    {
        public T? GetElement(Func<T, bool> predicate, string? include);
        public List<T>? GetElements(Func<T, bool> predicate, string? include);

        public void DeleteElement(T? element);
    }
}
