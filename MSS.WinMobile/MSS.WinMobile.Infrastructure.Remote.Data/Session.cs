using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class Session : ISession
    {
        private readonly string _address;
        private readonly int _port;

        public Session(string address, int port)
        {
            _address = address;
            _port = port;
        }

        public ITransaction BeginTransaction()
        {
            var dispatcher = new RequestDispatcher(_address, _port);
            return new Transaction(dispatcher);
        }
    }
}
