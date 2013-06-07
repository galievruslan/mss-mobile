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

        public static string ReturnWithNewLine  {
            get { return "\r\n"; }
        }

        public static char Return {
            get { return '\r'; }
        }

        public static char NewLine {
            get { return '\n'; }
        }

        public static char Tab {
            get { return '\t'; }
        }
    }
}
