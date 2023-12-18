using NetSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetSharp
{
    internal class Manager
    {
        private static Server _server;
        public Manager(Server server) => _server = server;
        public static TypeSend Execute(Message msg, IPEndPoint iPEndPoint)
        {
            switch (msg.command)
            {
                case Commands.Delete:
                    Delete(msg.NicknameFrom);
                    break;
                case Commands.Register:
                    Register(msg.NicknameFrom, iPEndPoint);

                    break;
                default: return Send(msg);

            }
            return TypeSend.defaultmes;
        }

        public static TypeSend Send(Message msg)
        {
            if (string.IsNullOrEmpty(msg.NicknameTo))
                return TypeSend.ToAll;
            return TypeSend.ToOne;
        }


        public static void Register(string user, IPEndPoint iPEndPoint)
        {
            if (_server.Users == null)
                _server.Users = new Dictionary<string, IPEndPoint>();
            if (!_server.Users.ContainsKey(user))
            {
                _server.Users.Add(user, iPEndPoint);
                Console.WriteLine($"Пользователь {user} создан");
            }
        }
        public static void Delete(string user)
        {
            _server.Users.Remove(user);
            Console.WriteLine($"Пользователь {user} удален");
        }
    }
}
