using System;

namespace MSS.WinMobile.Synchronizer.FaultHandling
{
    public class CommandException<TS, TD> : Exception
    {
        private Command<TS, TD> _command;

        public CommandException(Command<TS, TD> command, string message)
            : base(message) {
            _command = command;
        }

        public CommandException(Command<TS, TD> command, string message, Exception exception) 
            :base(message, exception) {
            _command = command;
        }
    }
}
