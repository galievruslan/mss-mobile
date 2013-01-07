using System;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class Transaction : ITransaction
    {
        private RequestDispatcher _requestDispatcher;

        public Transaction(RequestDispatcher requestDispatcher)
        {
            _requestDispatcher = requestDispatcher;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
