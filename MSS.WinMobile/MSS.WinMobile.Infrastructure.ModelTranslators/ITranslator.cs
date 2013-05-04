namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public interface ITranslator<TDestination, TSource>
    {
        TDestination Translate(TSource source);
    }
}
