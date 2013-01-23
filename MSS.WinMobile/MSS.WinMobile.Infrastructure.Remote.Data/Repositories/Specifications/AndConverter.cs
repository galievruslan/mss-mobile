using System;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Repositories.Specifications
{
    public class AndConverter<T> : Converter<T> where T : IEntity
    {
        public AndConverter(Specification<T> specification) : base(specification) {
            if (!(specification is CompositeSpecification<T>))
                throw new ArgumentException();
        }

        public override string Convert() {
            var compositeSpecification = Specification as CompositeSpecification<T>;

            string result = string.Empty;
            if (compositeSpecification != null) {
                string leftParam = SpecificationConverter<T>.ToQueryString(compositeSpecification.Left);
                string rightParam = SpecificationConverter<T>.ToQueryString(compositeSpecification.Right);
                result = string.Format(@"{0}&{1}", leftParam, rightParam);
            }

            return result;
        }
    }
}
