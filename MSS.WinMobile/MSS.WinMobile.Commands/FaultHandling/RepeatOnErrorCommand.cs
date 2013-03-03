using System;
using System.Threading;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Commands.FaultHandling
{
    public class RepeatOnErrorCommand<T> : Command<T> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(RepeatOnErrorCommand<T>));

        private readonly Command<T> _command;
        private readonly int _repeatCount;
        private readonly int _repeatDelay;

        public RepeatOnErrorCommand(Command<T> command, int repeatCount, int repeatDelay) {
            _command = command;
            _command.Subscribe(this);
            _repeatCount = repeatCount;
            _repeatDelay = repeatDelay;
        }

        protected override T Execute() {
            int tryNo = 1;

            while (true) {

                try {
                    return _command.Do();
                }
                catch (Exception exception) {
                    Log.Error(string.Format("Excecution try #{0} failed", tryNo), exception);

                    if (tryNo > _repeatCount) {
                        throw new CommandException<T>(_command, string.Empty, exception);
                    }

                    tryNo++;
                    Thread.Sleep(_repeatDelay);
                }
            }
        }

        public override void Notify(INotification notification)
        {
            base.Notify(notification);
            Notificate(notification);
        }
    }
}
