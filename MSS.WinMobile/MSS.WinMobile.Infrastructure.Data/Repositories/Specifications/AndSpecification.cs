using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Data.Repositories.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T> where T : IEntity
    {
        public AndSpecification(Specification<T> left, Specification<T> right) : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return Left.IsSatisfiedBy(entity) && Right.IsSatisfiedBy(entity);
        }

        public override T[] GetSatisfied(T[] entities)
        {
            var intersection = new List<T>();

            var leftSatisfied = Left.GetSatisfied(entities);
            var rightSatisfied = Right.GetSatisfied(entities);
            for (int i = 0; i < leftSatisfied.Length; i++)
            {
                for (int j = 0; j < rightSatisfied.Length; j++)
                {
                    if (leftSatisfied[i].Id == rightSatisfied[j].Id)
                    {
                        intersection.Add(leftSatisfied[i]);
                        break;
                    }
                }
            }

            return intersection.ToArray();
        }
    }
}
