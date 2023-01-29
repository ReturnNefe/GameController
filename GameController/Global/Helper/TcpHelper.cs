using System.Net.Sockets;
using System.Net;

namespace GameController.Global.Helper
{
    internal class TcpHelper
    {
        static internal int GetAvailablePort() => GetAvailablePort(IPAddress.Loopback);

        static internal int GetAvailablePort(IPAddress ip)
        {
            var listener = new TcpListener(ip, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}
