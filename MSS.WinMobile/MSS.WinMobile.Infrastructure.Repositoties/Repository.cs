using System.Data.SQLite;
using System.Linq;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObject;
using System.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public abstract class Repository<T> : IRepository<T,string> where T : IModel
    {
        private readonly SqliteUnitOfWork _unitOfWork;
        protected Repository()
        {
            _unitOfWork = SqliteUnitOfWork.Instance;
        }

        public T GetById(int id)
        {
            return Find().Where("Id", new Equals(id)).FirstOrDefault();
        }

        protected abstract QueryObject<T> GetQueryObject();
        public virtual IQueryObject<T, string> Find()
        {
            return GetQueryObject();
        }

        protected abstract string GetSaveQueryFor(T model);
        public virtual void Save(T model)
        {
            SQLiteConnection connection = SqliteConnectionFactory.Instance.GetConnection();
            string saveQuery = GetSaveQueryFor(model);
            if (_unitOfWork.InTransaction)
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = saveQuery;
                    command.ExecuteNonQuery();
                }

                if (model.Id == 0)
                {
                    model.Id = (int)connection.LastInsertRowId;
                }
            }
            else
            {
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = saveQuery;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    if (model.Id == 0)
                    {
                        model.Id = (int) connection.LastInsertRowId;
                    }
                }
            }
        }

        protected abstract string GetDeleteQueryFor(T model);
        public virtual void Delete(T model)
        {
            SQLiteConnection connection = SqliteConnectionFactory.Instance.GetConnection();
            string deleteQuery = GetDeleteQueryFor(model);
            if (_unitOfWork.InTransaction)
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = deleteQuery;
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = deleteQuery;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }
    }
}
