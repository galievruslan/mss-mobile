namespace MSS.WinMobile.Synchronizer.FaultHandling
{
    public static class CommandExtensions
    {
        public static Command<TS, TD> RepeatOnError<TS, TD>(this Command<TS, TD> command, int repeatCount, int repeatDelay)
        {
            return new RepeatOnErrorCommand<TS, TD>(command, repeatCount, repeatDelay);
        }

        public static Command<TS, TD> RepeatOnError<TS, TD>(this Command<TS, TD> command)
        {
            return new RepeatOnErrorCommand<TS, TD>(command, 5, 30000);
        }

        public static Command<TS, TD> IgnoreOnError<TS, TD>(this Command<TS, TD> command)
        {
            return new IgnoreErrorCommand<TS, TD>(command);
        }
    }
}
