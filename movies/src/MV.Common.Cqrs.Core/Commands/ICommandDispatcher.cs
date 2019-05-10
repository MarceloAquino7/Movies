using System.Threading.Tasks;
using MV.Common.Repository.Contracts.Core.Entities;

namespace MV.Common.Cqrs.Core.Commands
{
    public interface ICommandDispatcher
    {
        Task<TEntity> DispatchCommandTwoWay<TCommand, TEntity>(TCommand command)
            where TCommand : ICommand
            where TEntity : IDomainEntity;

        Task DispatchCommand<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}