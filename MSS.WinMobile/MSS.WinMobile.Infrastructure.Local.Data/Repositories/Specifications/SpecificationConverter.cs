using System;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories.Specifications
{
    public static class SpecificationConverter<T>
    {
        public static FilterCondition ToExpression(Specification<T> specification) {
            
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

    public class SpecificationConverterNotFoundException<T> : Exception {
        public SpecificationConverterNotFoundException(Specification<T> specification)
            : base(string.Format(@"Converter for specification ""{0}"" not found!", specification.GetType())) {
        }
    }
}