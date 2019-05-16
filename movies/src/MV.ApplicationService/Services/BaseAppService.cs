using AutoMapper;
using MV.ApplicationService.Interfaces;
using MV.Common.Cqrs.Core.Bus;
using MV.Common.WebServer.Server;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace MV.ApplicationService.Services
{
    public class BaseAppService : IBaseAppService
    {
        public BaseAppService(IHttpContextAccessor contextAccessor, IMessageBus bus, IMapper mapper)
        {
            MessageBus = bus;
            Mapper = mapper;

            if (contextAccessor.HttpContext != null)
            {
                var headerUserId = contextAccessor.HttpContext.Request.Headers["UserId"].FirstOrDefault();

                if (headerUserId != null)
                {
                    CurrentUser = new UserContext { Id = Guid.Parse(headerUserId) };
                }
            }
        }

        public IMessageBus MessageBus { get; set; }
        public UserContext CurrentUser { get; set; }
        public IMapper Mapper { get; set; }
    }
}
