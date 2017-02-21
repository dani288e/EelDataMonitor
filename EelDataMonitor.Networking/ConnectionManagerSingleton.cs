using System;

namespace EelDataMonitor.Networking
{
    public class ConnectionManagerSingleton
    {
        private static readonly Lazy<ConnectionManager> lazy;

        static ConnectionManagerSingleton()
        {
            lazy = new Lazy<ConnectionManager>(() => new ConnectionManager());
        }

        public static ConnectionManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
