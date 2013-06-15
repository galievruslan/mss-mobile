using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Updater.Commands {
    public class ExtractDistributive : Command<string> {
        private readonly string _archivedDistributive;
        private readonly string _destination;
        public ExtractDistributive(string archivedDistributive, string destination) {
            _archivedDistributive = archivedDistributive;
            _destination = destination;
        }

        public override string Execute() {
            try {
                Notificate(new TextNotification("Extracting..."));
                string cabPath = string.Empty;
                using (var s = new ZipInputStream(File.OpenRead(_archivedDistributive))) {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null) {
                        string fileName = Path.GetFileName(theEntry.Name);

                        if (fileName != String.Empty) {
                            cabPath = Path.Combine(_destination, theEntry.Name);
                            using (FileStream streamWriter = File.Create(cabPath)) {
                                var data = new byte[2048];
                                while (true) {
                                    int size = s.Read(data, 0, data.Length);
                                    if (size > 0) {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                Notificate(new CommandResultNotification("OK"));
                return cabPath;
            }
            catch (Exception) {
                Notificate(new CommandResultNotification("failed"));
                throw;
            }
        }
    }
}
