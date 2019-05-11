using System.Threading.Tasks;
using MV.Domain.Commands.User;
using MV.Common.Cqrs.Core.Bus;
using MV.Common.Cqrs.Core.CommandHandlers;
using MV.Common.Repository.Contracts.Core.Repository;

namespace MV.Domain.CommandHandlers.User
{
    internal class UpdateUserCommandHandler :
        CommandHandler,
        ICommandHandlerTwoWay<UpdateUserCommand, Models.User>
    {
        private readonly IRepository<Models.User> userLibRepository;

        public UpdateUserCommandHandler(IRepository<Models.User> userLibRepository, IMessageBus bus) : base(bus)
        {
            this.userLibRepository = userLibRepository;
        }

        public Task<Models.User> Handle(UpdateUserCommand command)
        {
            return Task.Run(() =>
            {
                //Domain Changes
                var user = userLibRepository.FindById(command.Id);
                user.Name = command.Name;
                user.Email = command.Email;
                user.LastLogin = command.LastLogin;

                //Persistence
                userLibRepository.Update(user);

                return user;
            });
        }
    }
}
