using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Reflection;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using MSS.WinMobile.Infrastructure.Local.Attributes;
using MSS.WinMobile.Infrastructure.Local.Data.ScriptGenerators;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        private readonly SqlCeConnection _sqlCeConnection;

        public GenericRepository(SqlCeConnection sqlCeConnection)
        {
            _sqlCeConnection = sqlCeConnection;
        }

        #region IGenericRepository<T> Members

        public T GetById(int id)
        {
            IDataReader reader;
            using (_sqlCeConnection.BeginTransaction())
            {
                SelectScript script = DataScriptGenerator.ScriptGenerateSelectFor<T>();
                script.Where(new WhereExpression(new ItemExpression("Id")).Equals(new ValueExpression(id)));
                
                try
                {
                    IDbCommand command = _sqlCeConnection.CreateCommand();
                    command.CommandText = script.Text;
                    reader = command.ExecuteReader(CommandBehavior.SingleRow);
                }
                catch
                {
                    throw new Exception("GetById exception");
                }
            }

            IDictionary<string, object> entityDictionary = new Dictionary<string, object>();
            if (reader != null && reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    entityDictionary.Add(reader.GetName(i), reader.GetValue(i));
                }
            }

            Type type = typeof(T);
            var entity = Activator.CreateInstance<T>();

            TableAttribute tableAttribute = type.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
            if (tableAttribute == null)
                throw new CanNotGenerateFromTypeException(type);

            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(true).OfType<ColumnAttribute>().ToArray();
                if (!attributes.Any())
                    continue;

                if (entityDictionary.ContainsKey(attributes.First().Name))
                {
                    propertyInfo.SetValue(entity, entityDictionary[attributes.First().Name], null);
                }
            }

            return entity;
        }

        public T[] Find()
        {
            IDataReader reader;
            using (_sqlCeConnection.BeginTransaction())
            {
                SelectScript script = DataScriptGenerator.ScriptGenerateSelectFor<T>();

                try
                {
                    IDbCommand command = _sqlCeConnection.CreateCommand();
                    command.CommandText = script.Text;
                    reader = command.ExecuteReader();
                }
                catch
                {
                    throw new Exception("Find exception");
                }
            }

            var entities = new List<T>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    IDictionary<string, object> entityDictionary = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        entityDictionary.Add(reader.GetName(i), reader.GetValue(i));
                    }

                    Type type = typeof(T);
                    var entity = Activator.CreateInstance<T>();

                    PropertyInfo[] propertyInfos = type.GetProperties();
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        var attributes = propertyInfo.GetCustomAttributes(true).OfType<ColumnAttribute>().ToArray();
                        if (!attributes.Any())
                            continue;

                        if (entityDictionary.ContainsKey(attributes.First().Name))
                        {
                            propertyInfo.SetValue(entity, entityDictionary[attributes.First().Name], null);
                        }
                    }

                    entities.Add(entity);
                }
            }

            return entities.ToArray();
        }

        public T[] Find(Specification<T> specification)
        {
            IDataReader reader;
            using (_sqlCeConnection.BeginTransaction())
            {
                SelectScript script = DataScriptGenerator.ScriptGenerateSelectFor<T>();

                try
                {
                    IDbCommand command = _sqlCeConnection.CreateCommand();
                    command.CommandText = script.Text;
                    reader = command.ExecuteReader();
                }
                catch
                {
                    throw new Exception("Find exception");
                }
            }

            var entities = new List<T>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    IDictionary<string, object> entityDictionary = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        entityDictionary.Add(reader.GetName(i), reader.GetValue(i));
                    }

                    Type type = typeof(T);
                    var entity = Activator.CreateInstance<T>();

                    PropertyInfo[] propertyInfos = type.GetProperties();
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        var attributes = propertyInfo.GetCustomAttributes(true).OfType<ColumnAttribute>().ToArray();
                        if (!attributes.Any())
                            continue;

                        if (entityDictionary.ContainsKey(attributes.First().Name))
                        {
                            propertyInfo.SetValue(entity, entityDictionary[attributes.First().Name], null);
                        }
                    }

                    entities.Add(entity);
                }
            }

            return entities.ToArray();
        }

        public void Add(T entity)
        {
            using (IDbTransaction transaction = _sqlCeConnection.BeginTransaction())
            {
                Script script = DataScriptGenerator.GenerateInsertFor(entity);
                try
                {
                    IDbCommand command = _sqlCeConnection.CreateCommand();
                    command.CommandText = script.Text;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public void Update(T entity)
        {
            using (IDbTransaction transaction = _sqlCeConnection.BeginTransaction())
            {
                UpdateScript script = DataScriptGenerator.GenerateUpdateFor(entity);
                script.Where(new WhereExpression(new ItemExpression("Id")).Equals(new ValueExpression(entity.Id)));
                try
                {
                    IDbCommand command = _sqlCeConnection.CreateCommand();
                    command.CommandText = script.Text;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public void Delete(T entity)
        {
            using (IDbTransaction transaction = _sqlCeConnection.BeginTransaction())
            {
                DeleteScript script = DataScriptGenerator.GenerateDeleteFor(entity);
                script.Where(new WhereExpression(new ItemExpression("Id")).Equals(new ValueExpression(entity.Id)));
                try
                {
                    IDbCommand command = _sqlCeConnection.CreateCommand();
                    command.CommandText = script.Text;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
        #endregion
    }
}
