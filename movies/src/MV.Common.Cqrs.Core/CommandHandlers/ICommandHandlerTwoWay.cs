using System.Threading.Tasks;
using MV.Common.Cqrs.Core.Commands;
using MV.Common.Repository.Contracts.Core.Entities;

namespace MV.Common.Cqrs.Core.CommandHandlers
{
    public interface ICommandHandlerTwoWay<in TCommand, TDomainEntity>
        where TCommand : ICommand
        where TDomainEntity : IDomainEntity
    {
        Task<TDomainEntity> Handle(TCommand command);
    }
}