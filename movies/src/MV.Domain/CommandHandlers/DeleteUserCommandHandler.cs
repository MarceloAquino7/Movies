using System.Threading.Tasks;
using MV.Domain.Commands.User;
using MV.Common.Cqrs.Core.Bus;
using MV.Common.Cqrs.Core.CommandHandlers;
using MV.Common.Repository.Contracts.Core.Repository;

namespace MV.Domain.CommandHandlers.User
{
    public class DeleteUserCommandHandler :
        CommandHandler,
        ICommandHandler<DeleteUserCommand>
    {
        private readonly IRepository<Models.User> userRepository;

        public DeleteUserCommandHandler(IRepository<Models.User> userRepository, IMessageBus bus) : base(bus)
        {
            this.userRepository = userRepository;
        }

        public Task Handle(DeleteUserCommand command)
        {
            //Persistence
            userRepository.Delete(command.Id);

            return Task.CompletedTask;
        }
    }
}
