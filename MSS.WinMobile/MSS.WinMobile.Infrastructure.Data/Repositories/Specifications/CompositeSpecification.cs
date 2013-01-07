namespace MSS.WinMobile.Infrastructure.Data.Repositories.Specifications
{
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected Specification<T> Left;
        protected Specification<T> Right;

        protected CompositeSpecification(Specification<T> left, Specification<T> right)
        {
            Left = left;
            Right = right;
        }
    }
}
