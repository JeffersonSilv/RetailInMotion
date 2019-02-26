using RetailInMotion.Data.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailInMotion.Data.Concrete
{
    public class Paged<T> : IPaged<T>
    {
        private readonly IQueryable<T> source;

        public Paged(IQueryable<T> source)
        {
            this.source = source;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return source.GetEnumerator();
        }

        public int Count
        {
            get { return source.Count(); }
        }

        public IEnumerable<T> GetRange(int index, int count)
        {
            return source.Skip(index - 1).Take(count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
