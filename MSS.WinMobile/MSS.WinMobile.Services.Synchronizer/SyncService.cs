using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Services.Synchronizer
{
    public class SyncService {
        private readonly ISession _sourceSession;
        private readonly ISession _destinationSession;

        public SyncService(ISession sourceSession,
                           ISession destinationSession) {
            _sourceSession = sourceSession;
            _destinationSession = destinationSession;
        }

        public void SyncAll() {
            SyncEntity<Customer>();
            SyncEntity<Manager>();
            SyncEntity<Status>();
            SyncEntity<Route>();
            SyncEntity<RoutePoint>();
        }

        public void SyncEntity<T>() where T : IEntity {
            var entities = new List<T>();
            using (ITransaction sourceTransaction = _sourceSession.BeginTransaction()) {
                IGenericRepository<T> repository = sourceTransaction.Resolve<T>();
                entities.AddRange(repository.Find());
            }

            using (ITransaction destinationTransaction = _destinationSession.BeginTransaction()) {
                IGenericRepository<T> repository = destinationTransaction.Resolve<T>();
                foreach (var entity in entities) {
                    repository.Add(entity);
                }

                destinationTransaction.Commit();
            }
        }
    }
}
