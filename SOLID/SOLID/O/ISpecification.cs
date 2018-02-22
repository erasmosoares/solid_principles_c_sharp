using System.Collections.Generic;

namespace SOLID.O
{
    // we introduce two new interfaces that are open for extension

    public interface ISpecification<T>
    {
        bool IsSatisfied(Product p);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}
