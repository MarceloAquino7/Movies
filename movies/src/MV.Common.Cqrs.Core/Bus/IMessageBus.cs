using MV.Common.Cqrs.Core.Commands;
using MV.Common.Cqrs.Core.Events;

namespace MV.Common.Cqrs.Core.Bus
{
    public interface IMessageBus : ICommandDispatcher, IEventPublisher
    {
    }
}