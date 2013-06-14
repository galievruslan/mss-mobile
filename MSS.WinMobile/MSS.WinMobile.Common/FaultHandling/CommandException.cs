using System;

namespace MSS.WinMobile.Common.FaultHandling
{
    public class CommandException<TReturn> : Exception
    {
        private Command<TReturn> _command;
        public CommandException(Command<TReturn> command, string message)
            : base(message) {
            _command = command;
        }

        public CommandException(Command<TReturn> command, string message, Exception exception) 
            :base(message, exception) {
            _command = command;
        }
    }
}
