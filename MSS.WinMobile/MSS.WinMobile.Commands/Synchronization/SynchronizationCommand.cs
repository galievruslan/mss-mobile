using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;

namespace MSS.WinMobile.Commands.Synchronization
{
    public abstract class SynchronizationCommand : Command<bool> {

        private readonly ISession _session;

        protected SynchronizationCommand(ISession session) {
            _session = session;
        }

        protected void SynchronizeEntity<T>(IEnumerable<T> entities) where T : IEntity
        {
            using (ITransaction destinationTransaction = _session.BeginTransaction())
            {
                IGenericRepository<T> repository = destinationTransaction.Resolve<T>();
                foreach (var entity in entities)
                {
                    if (repository.GetById(entity.Id).Id == 0)
                        repository.Add(entity);
                    else
                        repository.Update(entity);
                }

                destinationTransaction.Commit();
            }
        }
    }
}
