using System.Threading.Tasks;

namespace MV.Common.Cqrs.Core.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}