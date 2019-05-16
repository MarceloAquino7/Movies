using AutoMapper;
using MV.Common.Cqrs.Core.Bus;
using MV.Common.WebServer.Server;

namespace MV.ApplicationService.Interfaces
{
    public interface IBaseAppService
    {
        IMessageBus MessageBus { get; set; }
        UserContext CurrentUser { get; set; }
        IMapper Mapper { get; set; }
    }
}
