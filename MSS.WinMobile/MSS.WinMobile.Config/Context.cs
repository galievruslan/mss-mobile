using System.IO;
using System.Reflection;

namespace MSS.WinMobile
{
    public static class Context
    {
        public static string GetAppPath()
        {
            //return Path.GetDirectoryName(
            //    Assembly.GetExecutingAssembly().GetName().CodeBase);
            return System.IO.Directory.GetCurrentDirectory();
        }

        public static int ManagerId { get; set; }
    }
}
