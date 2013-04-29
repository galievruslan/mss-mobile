namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ITranslator<TModel, TQueryResult>
    {
        TModel[] Translate(TQueryResult queryResult);
    }
}