using System;
using System.Threading;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Common.FaultHandling
{
    public class RepeatOnErrorCommand<TReturn> : Command<TReturn>
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(RepeatOnErrorCommand<TReturn>));

        private readonly Command<TReturn> _command;
        private readonly int _repeatCount;
        private readonly int _repeatDelay;

        public RepeatOnErrorCommand(Command<TReturn> command, int repeatCount, int repeatDelay)
        {
            _command = command;
            _command.Subscribe(this);
            _repeatCount = repeatCount;
            _repeatDelay = repeatDelay;
        }

        public override TReturn Execute() {
            int tryNo = 1;

            while (true) {

                try {
                    return _command.Execute();
                }
                catch (Exception exception) {
                    Log.Error(string.Format("Excecution try #{0} failed", tryNo), exception);

                    if (tryNo >= _repeatCount) {
                        throw new CommandException<TReturn>(_command, string.Empty, exception);
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
