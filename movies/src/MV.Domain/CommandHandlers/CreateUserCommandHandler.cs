using System;
using System.Threading.Tasks;
using MV.Domain.Commands.User;
using MV.Common.Cqrs.Core.Bus;
using MV.Common.Cqrs.Core.CommandHandlers;
using MV.Common.Repository.Contracts.Core.Repository;

namespace MV.Domain.CommandHandlers.User
{
    public class CreateUserCommandHandler :
        CommandHandler,
        ICommandHandlerTwoWay<CreateUserCommand, Models.User>
    {
        private readonly IRepository<Models.User> userRepository;

        public CreateUserCommandHandler(IRepository<Models.User> userRepository, IMessageBus bus) : base(bus)
        {
            this.userRepository = userRepository;
        }

        public Task<Models.User> Handle(CreateUserCommand command)
        {
            return Task.Run(() =>
            {
                //Domain Changes
                var user = new Models.User
                {
                    Name = command.Name,
                    Email = command.Email,
                    LastLogin = DateTime.UtcNow
                };

                //Persistence
                userRepository.Insert(user);

                return user;
            });
        }
    }
}
