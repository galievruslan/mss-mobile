using System.IO;
using MSS.WinMobile.Common;

namespace MSS.WinMobile.Updater.Commands {
    public class DeleteTemporaryFolder : Command<bool> {
        private readonly string _temporaryFolder;
        public DeleteTemporaryFolder(string temporaryFolder) {
            _temporaryFolder = temporaryFolder;
        }

        public override bool Execute() {
            if (Directory.Exists(_temporaryFolder))
                Directory.Delete(_temporaryFolder, true);
            return true;
        }
    }
}
