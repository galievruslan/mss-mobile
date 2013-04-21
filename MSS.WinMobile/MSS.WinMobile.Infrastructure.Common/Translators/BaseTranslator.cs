using System;

namespace MSS.WinMobile.Infrastructure.Common.Translators
{
    public abstract class BaseTranslator
    {
        public abstract bool CanTranslate(Type targetType, Type sourceType);

        public bool CanTranslate<TTarget, TSource>()
        {
            return CanTranslate(typeof(TTarget), typeof(TSource));
        }

        public abstract object Translate(Type targetType, object source);

    } 
}
