using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Specifications;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Repositories.Specifications
{
    public class ManagerWithNameConverter : Converter<Manager> {
        public ManagerWithNameConverter(Specification<Manager> specification)
            : base(specification)
        {
        }

        public override string Convert() {
            var managerWithNameSpecification = Specification as ManagerWithNameSpecification;

            string result = string.Empty;
            if (managerWithNameSpecification != null)
            {
                result = string.Format(@"name={0}", Uri.EscapeDataString(managerWithNameSpecification.Name));
            }

            return result;
        }
    }
}
