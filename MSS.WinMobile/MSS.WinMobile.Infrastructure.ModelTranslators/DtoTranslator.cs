namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public abstract class DtoTranslator<TModel, TDto> : ITranslator<TModel, TDto>
    {
        public abstract TModel Translate(TDto source);
    } 
}
