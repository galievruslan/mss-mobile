using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IQueryObject<T,TQ> : IEnumerable<T> where T : IModel
    {
        TQ AsQuery();
        ITranslator<T> Translator { get; }
    }
}