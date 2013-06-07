using System.IO;
using System.Reflection;

namespace MSS.WinMobile.Application.Environment
{
    public static class Environment
    {
        public static string AppPath {
            get {
                return Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().GetName().CodeBase) + '/';
            }
        }
    }
}
