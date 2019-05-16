using MV.Common.Cqrs.Core.Bus;

namespace MV.Common.Cqrs.Core.Commands
{
    public abstract class Command : Message, ICommand
    {
    }
}