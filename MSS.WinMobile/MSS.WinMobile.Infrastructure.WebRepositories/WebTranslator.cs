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

        public override object Translate(Type targetType, object source) {
            if (targetType == typeof(TModel) ||
                targetType == typeof(TModel[]))
            return JsonDeserializer.Deserialize<TModel>(source.ToString());

            throw new InvalidOperationException();
        }

        public TTarget Translate<TTarget>(object source) {
            if (typeof (TTarget) == typeof (TModel) ||
                typeof (TTarget) == typeof (TModel[]))
                return JsonDeserializer.Deserialize<TTarget>(source.ToString());

            throw new InvalidOperationException();
        }
    }
}
