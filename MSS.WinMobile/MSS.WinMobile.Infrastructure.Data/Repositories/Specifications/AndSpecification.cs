using System.Collections.Generic;
using System.Linq;

namespace MSS.WinMobile.Infrastructure.Data.Repositories.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(Specification<T> left, Specification<T> right) : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return Left.IsSatisfiedBy(entity) && Right.IsSatisfiedBy(entity);
        }

        public override IEnumerable<T> GetSatisfied(IEnumerable<T> entities)
        {
            var entitiesToTest = entities.ToArray();
            var leftSatisfied = Left.GetSatisfied(entitiesToTest);
            var rightSatisfied = Right.GetSatisfied(entitiesToTest);
            return leftSatisfied.Intersect(rightSatisfied);
        }
    }
}
