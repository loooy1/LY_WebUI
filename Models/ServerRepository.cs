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
                new Server { ServerId = 3, Name = "Server-3", City = "Guangzhou" },
                new Server { ServerId = 4, Name = "Server-4", City = "Shenzhen" },
                new Server { ServerId = 5, Name = "Server-5", City = "Beijing" },
                new Server { ServerId = 6, Name = "Server-6", City = "Shanghai" },
                new Server { ServerId = 7, Name = "Server-7", City = "Guangzhou" },
                new Server { ServerId = 8, Name = "Server-8", City = "Shenzhen" },
                new Server { ServerId = 9, Name = "Server-9", City = "Chengdu" },
                new Server { ServerId = 10, Name = "Server-10", City = "Chengdu" }
            };
        }

        public static List<Server> GetCityList()
        {
            // 创建副本并按 City 去重，忽略大小写，保留每个城市第一次出现的 Server
            lock (_lock)
            {
                return _servers
                    .GroupBy(s => s.City ?? string.Empty, StringComparer.OrdinalIgnoreCase)
                    .Select(g => g.First())
                    .ToList();
            }
        }


        public static Server? GetById(int id) => _servers.FirstOrDefault(s => s.ServerId == id);

        public static List<Server>? GetByCity(string city) => _servers.Where(s => s.City == city).ToList();

        public static List<Server> GetServersByFilter(string? filter)
        {
            lock (_lock)
            {
                // 仅去掉 filter 两侧的空白（保留中间空格），并将 null 转为空串以避免传入 Contains(null)
                var trimmed = filter?.Trim() ?? string.Empty;

                return _servers
                    .Where(s => (s.Name ?? string.Empty).Contains(trimmed, StringComparison.OrdinalIgnoreCase) ||
                                (s.City ?? string.Empty).Contains(trimmed, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
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

        public static void Update(Server? server)
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
