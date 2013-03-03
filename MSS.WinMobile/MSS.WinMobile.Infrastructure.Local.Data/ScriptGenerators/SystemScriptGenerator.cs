using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MSS.WinMobile.Infrastructure.Local.Attributes;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts.System;

namespace MSS.WinMobile.Infrastructure.Local.Data.ScriptGenerators
{
    public static class SystemScriptGenerator
    { 
        public static Script GenearteCreateTableFor<T>()
        {
            Type type = typeof (T);
            var createTableScript = new CreateTableScript();
            TableAttribute tableAttribute = type.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
            if (tableAttribute == null)
                throw new CanNotGenerateFromTypeException(type);

            createTableScript.TableName(tableAttribute.Name);

            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(true).OfType<ColumnAttribute>().ToArray();
                if (!attributes.Any() || attributes.OfType<ReferenceAttribute>().Any())
                    continue;

                var createColumnScript = new CreateColumnScript();
                createColumnScript
                    .ColumnName(attributes.First().Name);

                createColumnScript = createColumnScript.AsType(propertyInfo);

                KeyAttribute keyAttribute =
                        attributes.OfType<KeyAttribute>().FirstOrDefault();
                if (keyAttribute != null)
                {
                    createColumnScript = createColumnScript.AsPrimaryKey();
                }

                createTableScript.AddColumn(createColumnScript);
            }

            return createTableScript;
        }

        public static Script[] GenerateAlterTableFor<T>()
        {
            Type type = typeof(T);
            TableAttribute tableAttribute = type.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
            if (tableAttribute == null)
                throw new CanNotGenerateFromTypeException(type);
            
            var scripts = new List<Script>();

            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var alterTableScript = new AlterTableScript();
                alterTableScript.TableName(tableAttribute.Name);
                var referenceAttribute =
                    propertyInfo.GetCustomAttributes(true).OfType<ReferenceAttribute>().FirstOrDefault();
                if (referenceAttribute == null)
                    continue;

                TableAttribute referenceTableAttribute =
                    referenceAttribute.ReferencedType.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
                if (referenceTableAttribute == null)
                    throw new CanNotGenerateFromTypeException(type);

                var createColumnScript = new CreateColumnScript();
                createColumnScript
                    .ColumnName(referenceAttribute.Name);

                createColumnScript = createColumnScript.AsType(propertyInfo);

                createColumnScript = createColumnScript.AsReference(referenceTableAttribute.Name);
                alterTableScript.AddColumn(createColumnScript);
                scripts.Add(alterTableScript);
            }

            return scripts.ToArray();
        }

        private static CreateColumnScript AsType(this CreateColumnScript createColumnScript, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(int) ||
                propertyInfo.PropertyType == typeof(int?))
            {
                createColumnScript = createColumnScript.AsInteger();
            }
            else if (propertyInfo.PropertyType == typeof(DateTime))
            {
                createColumnScript = createColumnScript.AsDatetime();
            }
            else if (propertyInfo.PropertyType == typeof(bool))
            {
                createColumnScript = createColumnScript.AsBoolean();
            }
            else if (propertyInfo.PropertyType == typeof(string))
            {
                StringColumnAttribute stringColumnAttribute =
                    propertyInfo.GetCustomAttributes(true).OfType<StringColumnAttribute>().FirstOrDefault();
                if (stringColumnAttribute != null)
                {
                    createColumnScript = createColumnScript.AsString(stringColumnAttribute.Lenght);
                }
            }
            else if (propertyInfo.PropertyType == typeof(decimal))
            {
                DecimalColumnAttribute decimalColumnAttribute =
                    propertyInfo.GetCustomAttributes(true).OfType<DecimalColumnAttribute>().FirstOrDefault();
                if (decimalColumnAttribute != null)
                {
                    createColumnScript = createColumnScript.AsDecimal(decimalColumnAttribute.Precision,
                                                                      decimalColumnAttribute.Scale);
                }
            }

            return createColumnScript;
        }
    }

    public class CanNotGenerateFromTypeException : Exception
    {
        public CanNotGenerateFromTypeException(Type type)
            : base(string.Format("Attribute Table not found for type {0}", type.FullName))
        {
        }
    }
}
