using System.Data.SQLite;
using System.Linq;
using MSS.WinMobile.Infrastructure.Data;
using System.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public abstract class Repository<T> : IGetRepository<T>, ISearchRepository<T, string, SQLiteConnection>, ISaveRepository<T>, IDeleteRepository<T> where T : IModel
    {
        private readonly SQLiteUnitOfWork _unitOfWork;
        protected readonly IConnectionFactory<SQLiteConnection> ConnectionFactory;

        protected Repository(IConnectionFactory<SQLiteConnection> connectionFactory, SQLiteUnitOfWork unitOfWork)
        {
            ConnectionFactory = connectionFactory;
            _unitOfWork = unitOfWork;
        }

        public T GetById(int id)
        {
            return Find().Where("Id", new Equals(id)).FirstOrDefault();
        }

        protected abstract QueryObject<T> GetQueryObject();

        public virtual IQueryObject<T, string, SQLiteConnection> Find()
        {
            return GetQueryObject();
        }

        protected abstract string GetSaveQueryFor(T model);

        public virtual T Save(T model)
        {
            SQLiteConnection connection = ConnectionFactory.GetConnection();
            string saveQuery = GetSaveQueryFor(model);
            if (_unitOfWork.InTransaction)
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = saveQuery;
                    command.ExecuteNonQuery();
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
                }
            }

            return model.Id == 0 ? (GetById((int) connection.LastInsertRowId)) : model;
        }

        protected abstract string GetDeleteQueryFor(T model);

        public virtual void Delete(T model)
        {
            SQLiteConnection connection = ConnectionFactory.GetConnection();
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
