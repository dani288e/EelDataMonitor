using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EelDataMonitor.Networking
{
    public class ConnectionManager
    {
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private readonly int _port = Int32.Parse(ConfigurationManager.AppSettings["Port"]);
        private readonly IPAddress _ip = IPAddress.Parse(ConfigurationManager.AppSettings["IP"]);
        public void SendFeed(string ip)
        {
            Debug.Write("Enter a query to the server: ");
            string request = ip;
            byte[] buffer = Encoding.ASCII.GetBytes(request);
            _clientSocket.Send(buffer);

            // {127.0.0.1}
            // receive
            byte[] receivedBuffer = new byte[1024];
            int receive = _clientSocket.Receive(receivedBuffer);
            byte[] data = new byte[receive];
            Array.Copy(receivedBuffer, data, receive);
            Debug.WriteLine("Received: " + Encoding.ASCII?.GetString(data));
        }

        public bool ConnectToServer()
        {
            try
            {
                _clientSocket.Connect(_ip, _port);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
