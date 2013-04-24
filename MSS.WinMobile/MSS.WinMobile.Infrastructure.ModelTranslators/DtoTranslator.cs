using System;
using MSS.WinMobile.Infrastructure.Common.Translators;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public abstract class DtoTranslator<TModel, TDto> : BaseTranslator
    {
        public override bool CanTranslate(Type targetType, Type sourceType)
        {
            return (targetType == typeof(TModel) && sourceType == typeof(TDto)) ||
                        (targetType == typeof(TDto) && sourceType == typeof(TModel));
        }

        public TTarget Translate<TTarget>(object source)
        {
            return (TTarget)Translate(typeof(TTarget), source);
        }

        public override object Translate(Type targetType, object source)
        {
            if (targetType == typeof(TModel))
            {
                return DtoToModel((TDto)source);
            }

            if (targetType == typeof(TDto))
            {
                return ModelToDto((TModel)source);
            }

            throw new ArgumentException("Invalid type passed to Translator", "targetType");
        }

        protected abstract TDto ModelToDto(TModel value);

        protected abstract TModel DtoToModel(TDto value);
    } 
}
