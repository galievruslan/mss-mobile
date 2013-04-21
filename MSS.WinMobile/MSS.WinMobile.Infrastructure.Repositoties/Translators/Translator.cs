using System;
using System.Data;
using MSS.WinMobile.Infrastructure.Common.Translators;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public abstract class Translator<TModel> : BaseTranslator, ITranslator<TModel>
    {
        public override bool CanTranslate(Type targetType, Type sourceType)
        {
            return true;
        }

        public TTarget Translate<TTarget>(object source)
        {
            return (TTarget)Translate(typeof(TTarget), source);
        }

        public override object Translate(Type targetType, object source)
        {
            if (targetType == typeof(TModel))
            {
                return DataRecordToModel(source as IDataRecord);
            }

            throw new ArgumentException("Invalid type passed to Translator", "targetType");
        }

        protected abstract TModel DataRecordToModel(IDataRecord value);
    } 
}
