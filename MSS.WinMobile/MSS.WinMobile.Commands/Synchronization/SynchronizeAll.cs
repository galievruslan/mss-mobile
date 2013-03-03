using MSS.WinMobile.Commands.FaultHandling;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Remote.Data;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeAll : Command<bool> {
        private readonly Server _server;
        private readonly ISession _session;
               
        public SynchronizeAll(Server server, ISession session) {

            _server = server;
            _session = session;
        }

        protected override bool Execute() {
            try {
                Notificate(new ProgressNotification(0));
                var command = new SynchronizeCustomers(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(10));
                command = new SynchronizeManagers(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(20));
                command = new SynchronizeStatuses(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(30));
                command = new SynchronizeWarehouses(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(40));
                command = new SynchronizeUnitsOfMeasure(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(50));
                command = new SynchronizeCategories(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(60));
                command = new SynchronizePriceLists(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(80));
                command = new SynchronizeProducts(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(90));
                command = new SynchronizeRoutes(_server, _session).RepeatOnError();
                command.Do();
                Notificate(new ProgressNotification(100));

                return true;
            }
            catch (CommandException<bool>) {
                return false;
            }
        }
    }
}
