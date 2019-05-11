using System;
using System.Threading.Tasks;
using MV.Domain.Commands.User;
using MV.Common.Cqrs.Core.Bus;
using MV.Common.Cqrs.Core.CommandHandlers;
using MV.Common.Repository.Contracts.Core.Repository;

namespace MV.Domain.CommandHandlers.User
{
    public class LoginUserCommandHandler :
        CommandHandler,
        ICommandHandlerTwoWay<LoginUserCommand, Models.User>
    {
        private readonly IRepository<Models.User> userRepository;

        public LoginUserCommandHandler(IRepository<Models.User> userRepository, IMessageBus bus) : base(bus)
        {
            this.userRepository = userRepository;
        }

        public Task<Models.User> Handle(LoginUserCommand command)
        {
            return Task.Run(() =>
            {
                var currentUser = userRepository.Find(x => x.Email == command.Email);

                if (currentUser == null)
                {
                    //Domain Changes
                    currentUser = new Models.User
                    {
                        Name = command.Name,
                        Email = command.Email,
                        LastLogin = DateTime.UtcNow
                    };

                    //Persistence
                    userRepository.Insert(currentUser);
                }
                else
                {
                    var lastLogin = currentUser.LastLogin;

                    currentUser.LastLogin = DateTime.UtcNow;
                    userRepository.Update(currentUser);

                    currentUser.LastLogin = lastLogin;
                }

                return currentUser;
            });
        }
    }
}
