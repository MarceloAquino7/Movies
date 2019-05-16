using System;
using MV.Common.WebServer.Server.Interfaces;

namespace MV.Common.WebServer.Server
{
    public class UserContext : IUserContext
    {
        public Guid Id { get; set; }
    }
}