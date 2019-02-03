using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools
{
    public class ChromeProcessHelper : IDisposable
    {
        private Process Chrome;

        public string PathToChrome { get; }
        public int DebuggingPort { get; }
        public bool Headless { get; }
        public bool DisableGpu { get; }
        public string UserDataDirectory { get; private set; }
        public string AdditionalArguments { get; }

        public static ChromeProcessHelper StartNew(
            string pathToChrome = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
            int debuggingPort = 9222,
            bool headless = false,
            bool disableGpu = false,
            string userDataDirectory = null,
            string additionalArguments = null)
        {
            var helper = new ChromeProcessHelper(pathToChrome, debuggingPort, headless, disableGpu, userDataDirectory, additionalArguments);

            helper.StartChromeProcess();

            return helper;
        }

        private ChromeProcessHelper(
            string pathToChrome, int debuggingPort, bool headless, bool disableGpu, string userDataDirectory, string additionalArguments)
        {
            PathToChrome = pathToChrome;
            DebuggingPort = debuggingPort;
            Headless = headless;
            DisableGpu = disableGpu;
            UserDataDirectory = userDataDirectory;
            AdditionalArguments = additionalArguments;
        }

        private void StartChromeProcess()
        {
            var args = new StringBuilder($"--remote-debugging-port={DebuggingPort}");

            if (Headless)
            {
                args.Append(" --headless");
            }

            if (DisableGpu)
            {
                args.Append(" --disable-gpu");
            }

            if (!String.IsNullOrWhiteSpace(UserDataDirectory))
            {
                args.Append($" --user-data-dir=\"{UserDataDirectory}\"");
            }

            if (!String.IsNullOrWhiteSpace(AdditionalArguments))
            {
                args.Append(" ").Append(AdditionalArguments);
            }

            var psi = new ProcessStartInfo(PathToChrome, args.ToString());
            Chrome = Process.Start(psi);
        }

        public async Task<DevToolsClient> GetDevTools(string url = null)
        {
            var client = new DevToolsClient(DebuggingPort);

            if (!String.IsNullOrWhiteSpace(url))
            {
                await client.NewTab(url);
            }

            return client;
        }

        #region IDisposable Support

        private bool Disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).

                    try
                    {
                        Chrome.CloseMainWindow();

                        if (!Chrome.WaitForExit(milliseconds: 1000))
                        {
                            Chrome.Kill();
                        }
                    }
                    finally
                    {
                        Chrome.Dispose();
                    }
                }

                // set large fields to null.
                Chrome = null;

                Disposed = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        #endregion
    }
}
