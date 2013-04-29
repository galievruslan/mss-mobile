namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public interface ITranslator<TDestination, TSource>
    {
        TDestination Translate(TSource source);
    }
}
