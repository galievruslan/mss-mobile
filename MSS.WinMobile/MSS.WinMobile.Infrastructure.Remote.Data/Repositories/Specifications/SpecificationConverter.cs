using System;
using MSS.WinMobile.Domain.Specifications;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Repositories.Specifications
{
    public static class SpecificationConverter<T>
    {
        public static string ToQueryString(Specification<T> specification) {
            string queryString;

            if (specification is AndSpecification<T>) {
                queryString = new AndConverter<T>(specification).Convert();
            }
            else if (specification is RouteByDateSpecification) {
                queryString = new RouteByDateConverter(specification as Specification<Route>).Convert();
            }
            else {
                throw new SpecificationConverterNotFoundException<T>(specification);
            }

            return queryString;
        }
    }

    public class SpecificationConverterNotFoundException<T> : Exception {
        public SpecificationConverterNotFoundException(Specification<T> specification)
            : base(string.Format(@"Converter for specification ""{0}"" not found!", specification.GetType())) {
        }
    }
}