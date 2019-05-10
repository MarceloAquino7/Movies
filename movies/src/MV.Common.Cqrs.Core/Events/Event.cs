using MV.Common.Cqrs.Core.Bus;

namespace MV.Common.Cqrs.Core.Events
{
    public abstract class Event : Message, IEvent
    {
    }
}