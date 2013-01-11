using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Data.Repositories.Specifications
{
    public abstract class Specification<T> where T : IEntity
    {
        public abstract bool IsSatisfiedBy(T entity);

        public abstract T[] GetSatisfied(T[] entities);

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
