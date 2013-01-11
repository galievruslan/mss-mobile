using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Data.Repositories.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T> where T : IEntity
    {
        public OrSpecification(Specification<T> left, Specification<T> right)
            : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return Left.IsSatisfiedBy(entity) || Right.IsSatisfiedBy(entity);
        }

        public override T[] GetSatisfied(T[] entities)
        {
            var leftSatisfied = Left.GetSatisfied(entities);
            var rightSatisfied = Right.GetSatisfied(entities);

            var union = new List<T>(leftSatisfied);
            for (int i = 0; i < rightSatisfied.Length; i++)
            {
                if (!union.Exists(e => e.Id == rightSatisfied[i].Id))
                    union.Add(rightSatisfied[i]);
            }

            return union.ToArray();
        }
    }
}
