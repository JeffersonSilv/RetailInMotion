using System.Collections.Generic;

namespace RetailInMotion.Data.Abstract
{
    public interface IPaged<out T> : IEnumerable<T>
    {
        int Count { get; }

        IEnumerable<T> GetRange(int index, int count);
    }
}
