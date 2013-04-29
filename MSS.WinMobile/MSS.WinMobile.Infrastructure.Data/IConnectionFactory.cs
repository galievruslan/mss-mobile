namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IConnectionFactory<TConnection>
    {
        TConnection GetConnection();
    }
}
