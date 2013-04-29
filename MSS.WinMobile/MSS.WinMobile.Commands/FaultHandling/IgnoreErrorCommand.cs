using System;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Synchronizer.FaultHandling
{
    public class IgnoreErrorCommand<TS, TD> : Command<TS, TD>
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(IgnoreErrorCommand<TS, TD>));

        private readonly Command<TS, TD> _command;

        public IgnoreErrorCommand(Command<TS, TD> command)
        {
            _command = command;
            _command.Subscribe(this);
        }

        public override void Execute() {
            try {
                _command.Execute();
            }
            catch (Exception exception) {
                Log.Error("Excecution failed. Error will be ignored", exception);
            }
        }

        public override void Notify(INotification notification)
        {
            base.Notify(notification);
            Notificate(notification);
        }
    }
}
