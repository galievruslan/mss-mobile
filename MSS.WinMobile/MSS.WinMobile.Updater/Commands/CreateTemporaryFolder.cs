using System.IO;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Common;

namespace MSS.WinMobile.Updater.Commands {
    public class CreateTemporaryFolder : Command<string> {
        private const string FolderName = "Temp";

        public override string Execute() {
            string temporaryFullPath = Path.Combine(Environment.AppPath, FolderName);
            if (Directory.Exists(temporaryFullPath))
                Directory.Delete(temporaryFullPath, true);

            Directory.CreateDirectory(temporaryFullPath);
            return temporaryFullPath;
        }
    }
}
