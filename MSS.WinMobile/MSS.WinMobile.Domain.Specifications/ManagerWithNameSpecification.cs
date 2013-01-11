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

        public override Manager[] GetSatisfied(Manager[] entities)
        {
            var satisfyed = new List<Manager>();
            for (int i = 0; i < entities.Length; i++)
            {
                if (IsSatisfiedBy(entities[i]))
                    satisfyed.Add(entities[i]);
            }

            return satisfyed.ToArray();
        }
    }
}