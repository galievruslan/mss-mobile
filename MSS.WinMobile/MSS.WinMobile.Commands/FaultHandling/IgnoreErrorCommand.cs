using System;

using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Commands.FaultHandling
{
    public class IgnoreErrorCommand<T> : Command<T> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(IgnoreErrorCommand<T>));

        private readonly Command<T> _command;
        private readonly T _defaultReturn;

        public IgnoreErrorCommand(Command<T> command, T defaultReturn) {
            _command = command;
            _defaultReturn = defaultReturn;
        }

        protected override T Execute() {
            try {
                return _command.Do();
            }
            catch (Exception exception) {
                Log.Error("Excecution failed. Error will be ignored", exception);
            }

            return _defaultReturn;
        }
    }
}
