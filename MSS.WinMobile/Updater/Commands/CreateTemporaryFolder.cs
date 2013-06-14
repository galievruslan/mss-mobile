using System.IO;
using MSS.WinMobile.Common;
using Envirommet = MSS.WinMobile.Application.Environment.Environment;

namespace Updater.Commands {
    public class CreateTemporaryFolder : Command<string> {
        private const string FolderName = "Temp";

        public override string Execute() {
            string temporaryFullPath = Path.Combine(Envirommet.AppPath, FolderName);
            if (Directory.Exists(temporaryFullPath))
                Directory.Delete(temporaryFullPath, true);

            Directory.CreateDirectory(temporaryFullPath);
            return temporaryFullPath;
        }
    }
}
