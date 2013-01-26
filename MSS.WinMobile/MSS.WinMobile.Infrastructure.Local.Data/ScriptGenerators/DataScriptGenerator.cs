using System;
using System.Linq;
using System.Reflection;
using MSS.WinMobile.Infrastructure.Local.Attributes;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions;

namespace MSS.WinMobile.Infrastructure.Local.Data.ScriptGenerators
{
    public static class DataScriptGenerator
    {
        public static InsertScript GenerateInsertFor<T>(T entity)
        {
            Type type = typeof (T);
            TableAttribute tableAttribute = type.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
            if (tableAttribute == null)
                throw new CanNotGenerateFromTypeException(type);

            var insertIntoExpression = new InsertExpression();
            var valuesExpression = new ValuesExpression();

            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(true).OfType<ColumnAttribute>().ToArray();
                if (!attributes.Any())
                    continue;

                insertIntoExpression.Where(new ItemExpression(attributes.First().Name));
                valuesExpression.What(new ValueExpression(propertyInfo.GetValue(entity, null)));
            }

            return new InsertScript(tableAttribute.Name).How(insertIntoExpression).What(valuesExpression);
        }

        public static SelectScript ScriptGenerateSelectFor<T>()
        {
            Type type = typeof(T);
            TableAttribute tableAttribute = type.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
            if (tableAttribute == null)
                throw new CanNotGenerateFromTypeException(type);
            
            var fromExpression = new FromExpression(tableAttribute.Name);
            var selectExpression = new SelectExpression();

            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(true).OfType<ColumnAttribute>().ToArray();
                if (!attributes.Any())
                    continue;

                selectExpression.What(new ItemExpression(attributes.First().Name));
            }

            return new SelectScript().From(fromExpression).What(selectExpression);
        }

        public static UpdateScript GenerateUpdateFor<T>(T entity)
        {
            Type type = typeof(T);
            TableAttribute tableAttribute = type.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
            if (tableAttribute == null)
                throw new CanNotGenerateFromTypeException(type);

            var uprateExpression = new UpdateExpression();

            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(true).OfType<ColumnAttribute>().ToArray();
                if (!attributes.Any() || attributes.OfType<KeyAttribute>().Any())
                    continue;
                
                uprateExpression.Update(new ItemExpression(attributes.First().Name),
                    new ValueExpression(propertyInfo.GetValue(entity, null)));
            }

            return new UpdateScript(tableAttribute.Name).How(uprateExpression);
        }

        public static DeleteScript GenerateDeleteFor<T>(T entity)
        {
            Type type = typeof(T);
            TableAttribute tableAttribute = type.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
            if (tableAttribute == null)
                throw new CanNotGenerateFromTypeException(type);

            return new DeleteScript(tableAttribute.Name);
        }
    }
}
