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

        public static string AppVersion {
            get {
                return string.Format("{0}.{1}.{2}.{3}",
                                     Assembly.GetExecutingAssembly().GetName().Version.Major,
                                     Assembly.GetExecutingAssembly().GetName().Version.Minor,
                                     Assembly.GetExecutingAssembly().GetName().Version.Build,
                                     Assembly.GetExecutingAssembly().GetName().Version.Revision);
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
