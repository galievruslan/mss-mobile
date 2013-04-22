using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IQueryObject<TM,TQ,TC> : IEnumerable<TM> where TM : IModel
    {
        TQ AsQuery();
        IConnectionFactory<TC> ConnectionFactory { get; }
        ITranslator<TM> Translator { get; }
    }
}