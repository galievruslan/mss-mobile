using MSS.WinMobile.Commands.FaultHandling;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeAll : Command<bool> {
        private readonly Server _server;
               
        public SynchronizeAll(Server server) {

            _server = server;
        }

        protected override bool Execute() {
            try {
                Notificate(new ProgressNotification(0));
                var command = new SynchronizeCustomers(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(10));
                command = new SynchronizeManagers(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(20));
                command = new SynchronizeStatuses(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(30));
                command = new SynchronizeWarehouses(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(40));
                command = new SynchronizeUnitsOfMeasure(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(50));
                command = new SynchronizeCategories(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(60));
                command = new SynchronizePriceLists(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(80));
                command = new SynchronizeProducts(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(90));
                command = new SynchronizeRouteTemplates(_server).RepeatOnError();
                command.Subscribe(this);
                command.Do();
                command.Unsubscribe(this);
                Notificate(new ProgressNotification(100));

                return true;
            }
            catch (CommandException<bool>) {
                return false;
            }
        }

        public override void Notify(INotification notification)
        {
            if (notification is TextNotification)
            {
                Notificate(notification);
            }
        }
    }
}
