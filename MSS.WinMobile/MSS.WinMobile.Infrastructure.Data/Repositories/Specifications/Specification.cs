using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Data.Repositories.Specifications
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfiedBy(T entity);

        public abstract IEnumerable<T> GetSatisfied(IEnumerable<T> entities);

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
    }
}
