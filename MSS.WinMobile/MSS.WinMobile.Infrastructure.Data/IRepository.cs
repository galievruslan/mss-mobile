using System.Collections;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IRepository<T,TQ> where T : IModel
    {
        T GetById(int id);
        IQueryObject<T,TQ> Find();

        void Save(T model);
        void Delete(T model);
    }
}
