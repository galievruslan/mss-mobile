namespace MSS.WinMobile.Common.FaultHandling
{
    public static class CommandExtensions
    {
        public static Command<TReturn> RepeatOnError<TReturn>(this Command<TReturn> command, int repeatCount, int repeatDelay)
        {
            return new RepeatOnErrorCommand<TReturn>(command, repeatCount, repeatDelay);
        }

        public static Command<TReturn> RepeatOnError<TReturn>(this Command<TReturn> command)
        {
            return new RepeatOnErrorCommand<TReturn>(command, 5, 30000);
        }

        public static Command<TReturn> IgnoreOnError<TReturn>(this Command<TReturn> command, TReturn @default)
        {
            return new IgnoreErrorCommand<TReturn>(command, @default);
        }
    }
}
