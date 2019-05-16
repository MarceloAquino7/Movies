using System.Threading.Tasks;

namespace MV.Common.Cqrs.Core.Events
{
    public interface IEventPublisher
    {
        Task PublishEvent<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}