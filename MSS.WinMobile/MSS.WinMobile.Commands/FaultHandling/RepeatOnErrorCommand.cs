using System;
using System.Threading;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Synchronizer.FaultHandling
{
    public class RepeatOnErrorCommand<TS, TD> : Command<TS, TD>
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(RepeatOnErrorCommand<TS, TD>));

        private readonly Command<TS, TD> _command;
        private readonly int _repeatCount;
        private readonly int _repeatDelay;

        public RepeatOnErrorCommand(Command<TS, TD> command, int repeatCount, int repeatDelay)
        {
            _command = command;
            _command.Subscribe(this);
            _repeatCount = repeatCount;
            _repeatDelay = repeatDelay;
        }

        public override void Execute() {
            int tryNo = 1;

            while (true) {

                try {
                    _command.Execute();
                    return;
                }
                catch (Exception exception) {
                    Log.Error(string.Format("Excecution try #{0} failed", tryNo), exception);

                    if (tryNo > _repeatCount) {
                        throw new CommandException<TS, TD>(_command, string.Empty, exception);
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
