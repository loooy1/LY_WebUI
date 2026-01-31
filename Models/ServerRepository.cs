using System;
using System.Collections.Generic;
using System.Linq;

namespace LY_WebUI.Models
{
    public class ServerRepository
    {
        private static readonly List<Server> _servers;
        private static readonly object _lock = new();

        static ServerRepository()
        {
            _servers = new List<Server>
            {
                new Server { ServerId = 1, Name = "Server-1", City = "Beijing" },
                new Server { ServerId = 2, Name = "Server-2", City = "Shanghai" },
                new Server { ServerId = 3, Name = "Server-3", City = "Guangzhou" }
            };
        }

        public static IReadOnlyList<Server> GetAll() => _servers.AsReadOnly();

        public static Server? GetById(int id) => _servers.FirstOrDefault(s => s.ServerId == id);

        public static void Add(Server server)
        {
            if (server is null) throw new ArgumentNullException(nameof(server));

            lock (_lock)
            {
                server.ServerId = _servers.Any() ? _servers.Max(s => s.ServerId) + 1 : 1;
                _servers.Add(server);
            }
        }

        public static bool Delete(int id)
        {
            lock (_lock)
            {
                var item = GetById(id);
                if (item == null) return false;
                return _servers.Remove(item);
            }
        }

        public static void Update(Server server)
        {
            if (server is null) throw new ArgumentNullException(nameof(server));

            lock (_lock)
            {
                var idx = _servers.FindIndex(s => s.ServerId == server.ServerId);
                if (idx >= 0) _servers[idx] = server;
                else
                {
                    server.ServerId = _servers.Any() ? _servers.Max(s => s.ServerId) + 1 : 1;
                    _servers.Add(server);
                }
            }
        }
    }
}
