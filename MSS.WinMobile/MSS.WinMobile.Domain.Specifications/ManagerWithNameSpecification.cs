using System.Linq;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Domain.Specifications
{
    public class ManagerWithNameSpecification : Specification<Manager>
    {
        public ManagerWithNameSpecification(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override bool IsSatisfiedBy(Manager entity)
        {
            return entity.Name.Equals(Name);
        }

        public override IEnumerable<Manager> GetSatisfied(IEnumerable<Manager> entities)
        {
            return entities.Where(IsSatisfiedBy);
        }
    }
}