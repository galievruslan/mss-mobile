using System;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Common.FaultHandling
{
    public class IgnoreErrorCommand<TReturn> : Command<TReturn>
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(IgnoreErrorCommand<TReturn>));

        private readonly Command<TReturn> _command;
        private readonly TReturn _default;

        public IgnoreErrorCommand(Command<TReturn> command, TReturn @default)
        {
            _command = command;
            _command.Subscribe(this);
            _default = @default;
        }

        public override TReturn Execute() {
            try {
                return _command.Execute();
            }
            catch (Exception exception) {
                Log.Error("Excecution failed. Error will be ignored", exception);
            }

            return _default;
        }

        public override void Notify(INotification notification)
        {
            base.Notify(notification);
            Notificate(notification);
        }
    }
}
