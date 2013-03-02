using MSS.WinMobile.Commands.FaultHandling;
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
                var command = new SynchronizeCustomers(_server, _session).RepeatOnError();
                command.Do();

                command = new SynchronizeManagers(_server, _session).RepeatOnError();
                command.Do();

                command = new SynchronizeStatuses(_server, _session).RepeatOnError();
                command.Do();

                command = new SynchronizeWarehouses(_server, _session).RepeatOnError();
                command.Do();

                command = new SynchronizeUnitsOfMeasure(_server, _session).RepeatOnError();
                command.Do();

                command = new SynchronizeCategories(_server, _session).RepeatOnError();
                command.Do();

                command = new SynchronizePriceLists(_server, _session).RepeatOnError();
                command.Do();

                command = new SynchronizeProducts(_server, _session).RepeatOnError();
                command.Do();

                command = new SynchronizeRoutes(_server, _session).RepeatOnError();
                command.Do();

                return true;
            }
            catch (CommandException<bool>) {
                return false;
            }
        }
    }
}
