using System;
using System.IO;
using log4net;

namespace MSS.WinMobile.Infrastructure.Web.Repositories.Utilites {
    public class Downloader {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Downloader));

        private readonly IWebServer _webServer;
        public Downloader(IWebServer webServer) {
            _webServer = webServer;
        }

        public bool DownloadFile(string url, string destination) {
            bool success;

            System.Net.WebResponse response = null;
            Stream responseStream = null;
            FileStream fileStream = null;

            try {
                IWebConnection webConnection = _webServer.Connect();
                var request = RequestFactory.CreateGetRequest(webConnection, url);
                request.Method = "GET";
                request.Timeout = 300000; // 5 minutes
                response = request.GetResponse();

                responseStream = response.GetResponseStream();

                fileStream = File.Open(destination, FileMode.Create, FileAccess.Write, FileShare.None);

                // read up to ten kilobytes at a time
                const int maxRead = 10240;
                var buffer = new byte[maxRead];
                int bytesRead;

                // loop until no data is returned
                while (responseStream != null && (bytesRead = responseStream.Read(buffer, 0, maxRead)) > 0) {
                    fileStream.Write(buffer, 0, bytesRead);
                }

                // we got to this point with no exception. Ok.
                success = true;
            }
            catch (Exception exp) {
                // something went terribly wrong.
                success = false;
                Log.Error(exp);
            }
            finally {
                // cleanup all potentially open streams.

                if (null != responseStream)
                    responseStream.Close();
                if (null != response)
                    response.Close();
                if (null != fileStream)
                    fileStream.Close();
            }

            // if part of the file was written and the transfer failed, delete the partial file
            if (!success && File.Exists(destination))
                File.Delete(destination);

            return success;
        }
    }
}
