namespace MSS.WinMobile.Infrastructure.Web
{
    public interface IConnectionFactory<TConnection>
    {
        TConnection CurrentConnection { get; }
    }
}
