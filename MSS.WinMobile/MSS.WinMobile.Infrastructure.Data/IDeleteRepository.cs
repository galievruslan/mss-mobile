namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IDeleteRepository<TM> where TM : IModel
    {
        void Delete(TM model);
    }
}
