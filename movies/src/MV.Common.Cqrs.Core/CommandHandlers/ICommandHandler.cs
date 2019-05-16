using System.Threading.Tasks;
using MV.Common.Cqrs.Core.Commands;

namespace MV.Common.Cqrs.Core.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}