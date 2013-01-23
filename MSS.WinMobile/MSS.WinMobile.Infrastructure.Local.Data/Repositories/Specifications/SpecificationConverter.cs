using System;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories.Specifications
{
    public static class SpecificationConverter<T> where T : IEntity
    {
        public static string ToExpression(Specification<T> specification) {
            
            //if (specification is AndSpecification<T>) {
            //    queryString = new AndConverter<T>(specification).Convert();
            //}
            //else if (specification is RouteByDateSpecification) {
            //    queryString = new RouteByDateConverter(specification as Specification<Route>).Convert();
            //}
            //else {
            //    throw new SpecificationConverterNotFoundException<T>(specification);
            //}

            return null;
        }
    }

    public class SpecificationConverterNotFoundException<T> : Exception where T : IEntity
    {
        public SpecificationConverterNotFoundException(Specification<T> specification)
            : base(string.Format(@"Converter for specification ""{0}"" not found!", specification.GetType())) {
        }
    }
}