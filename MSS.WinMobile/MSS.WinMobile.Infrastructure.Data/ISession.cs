namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ISession
    {
        ITransaction BeginTransaction();
    }
}
