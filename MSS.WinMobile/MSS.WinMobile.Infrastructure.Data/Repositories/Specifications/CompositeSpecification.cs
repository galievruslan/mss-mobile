namespace MSS.WinMobile.Infrastructure.Data.Repositories.Specifications
{
    public abstract class CompositeSpecification<T> : Specification<T> where T : IEntity
    {
        public Specification<T> Left { get; protected set; }
        public Specification<T> Right { get; protected set; }

        protected CompositeSpecification(Specification<T> left, Specification<T> right)
        {
            Left = left;
            Right = right;
        }
    }
}
