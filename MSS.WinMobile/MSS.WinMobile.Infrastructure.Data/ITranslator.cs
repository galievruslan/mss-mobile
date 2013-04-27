using System;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ITranslator<TModel>
    {
        bool CanTranslate(Type targetType, Type sourceType);
        TTarget Translate<TTarget>(object source);
        bool CanTranslate<TTarget, TSource>();
    }
}