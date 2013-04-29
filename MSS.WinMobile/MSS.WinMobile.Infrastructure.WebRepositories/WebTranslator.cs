using Json;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebTranslator<TModel> : ITranslator<TModel, string>
    {
        public TModel[] Translate(string queryResult)
        {
            return JsonDeserializer.Deserialize<TModel[]>(queryResult);
        }
    }
}
