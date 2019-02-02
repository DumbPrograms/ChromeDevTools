using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools
{
    public class ChromeProcessHelper : IDisposable
    {
        private Process Chrome;

        public int DebuggingPort { get; }
        public bool Headless { get; }
        public bool DisableGpu { get; }

        public ChromeProcessHelper(int debuggingPort = 9222, bool headless = false, bool disableGpu = false)
        {
            DebuggingPort = debuggingPort;
            Headless = headless;
            DisableGpu = disableGpu;
        }

        public async Task<ChromeDevToolsClient> StartDevToolsClient(string url = null)
        {
            var psi = new ProcessStartInfo(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "--remote-debugging-port=9222");
            Chrome = Process.Start(psi);

            var client = new ChromeDevToolsClient(DebuggingPort);

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

                    Chrome.CloseMainWindow();
                    Chrome.Dispose();
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
