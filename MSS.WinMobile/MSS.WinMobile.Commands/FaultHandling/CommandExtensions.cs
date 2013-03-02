namespace MSS.WinMobile.Commands.FaultHandling
{
    public static class CommandExtensions
    {
        public static Command<T> RepeatOnError<T>(this Command<T> command, int repeatCount, int repeatDelay) {
            return new RepeatOnErrorCommand<T>(command, repeatCount, repeatDelay);
        }

        public static Command<T> RepeatOnError<T>(this Command<T> command)
        {
            return new RepeatOnErrorCommand<T>(command, 5, 30000);
        }

        public static Command<T> IgnoreOnError<T>(this Command<T> command, T defaultResult)
        {
            return new IgnoreErrorCommand<T>(command, defaultResult);
        }
    }
}
