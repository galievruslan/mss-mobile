using System;
using Json;
using MSS.WinMobile.Infrastructure.Common.Translators;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebTranslator<TModel> : BaseTranslator, ITranslator<TModel>
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
                return JsonDeserializer.Deserialize<TModel[]>(source as string);
            }

            throw new ArgumentException("Invalid type passed to Translator", "targetType");
        }
    }
}
