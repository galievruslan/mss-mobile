using System;

namespace MSS.WinMobile.Commands.FaultHandling
{
    public class CommandException<T> : Exception {
        private Command<T> _command; 

        public CommandException(Command<T> command, string message)
            : base(message) {
            _command = command;
        }

        public CommandException(Command<T> command, string message, Exception exception) 
            :base(message, exception) {
            _command = command;
        }
    }
}
