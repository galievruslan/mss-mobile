using System;
using System.Collections.Generic;
using MSS.WinMobile.Commands.FaultHandling;
using MSS.WinMobile.Commands.Synchronization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Remote.Data;
using log4net;

namespace MSS.WinMobile.Services
{
    public class Synchronizer : IObservable {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Synchronizer));

        private readonly Uri _serverUri;
        private readonly string _userName;
        private readonly string _password;

        private readonly ISession _destinationSession;

        public Synchronizer()
        {
            
        }

        public void Start()
        {
            
        }
    }
}
