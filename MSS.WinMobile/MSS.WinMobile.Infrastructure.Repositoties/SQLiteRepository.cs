using System.Linq;
using System.Data;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public abstract class SqLiteStorageRepository<T> : IStorageRepository<T> where T : IModel
    {
        protected readonly IStorage Storage;
        protected SqLiteStorageRepository(IStorage storage) {
            Storage = storage;
        }

        public T GetById(int id) {
            var withIdSpec = new WithIdSpec<T>(id);
            return Find().Where(withIdSpec).FirstOrDefault();
        }

        protected abstract QueryObject<T> GetQueryObject();

        public virtual IQueryObject<T> Find()
        {
            return GetQueryObject();
        }

        protected abstract string GetSaveQueryFor(T model);

        public virtual T Save(T model)
        {
            IStorageConnection connection = Storage.Connect();
            string saveQuery = GetSaveQueryFor(model);
            using (IDbCommand command = connection.CreateCommand()) {
                command.CommandText = saveQuery;
                command.ExecuteNonQuery();
            }

            return model.Id == 0 ? (GetById((int) connection.LastInsertRowId)) : model;
        }

        protected abstract string GetDeleteQueryFor(T model);

        public virtual void Delete(T model) {
            IStorageConnection connection = Storage.Connect();
            string deleteQuery = GetDeleteQueryFor(model);
            using (IDbCommand command = connection.CreateCommand()) {
                command.CommandText = deleteQuery;
                command.ExecuteNonQuery();
            }
        }
    }
}
