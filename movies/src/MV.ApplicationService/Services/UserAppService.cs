using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MV.ApplicationService.Interfaces;
using MV.ApplicationService.ViewModels;
using MV.Domain.Commands.User;
using MV.Domain.Models;
using MV.Common.Cqrs.Core.Bus;
using MV.Common.Repository.Contracts.Core.Exceptions;
using MV.Common.Repository.Contracts.Core.Repository;
using MV.Common.Repository.Contracts.Core.Validations;
using Microsoft.AspNetCore.Http;

namespace MV.ApplicationService.Services
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> userRepository;

        public UserAppService(
            IHttpContextAccessor contextAccessor,
            IMessageBus bus,
            IMapper mapper,
            IRepository<User> userRepository) : base(contextAccessor, bus, mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        
        public void Delete(DeleteUserCommand commandDelete)
        {
            MessageBus.DispatchCommand(commandDelete);
        }

        public UserViewModel Get(Guid id)
        {
            return mapper.Map<UserViewModel>(userRepository.FindById(id));
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<UserViewModel>>(userRepository.All());
        }

        public UserViewModel Login(UserViewModel viewModel)
        {
            if (viewModel.ValidateModelAnnotations().Count > 0)
                throw new ModelException(
                    "This object instance is not valid based on DataAnnotation definitions. See more details on Errors list.",
                    viewModel.ValidateModelAnnotations());

            var command = new LoginUserCommand(viewModel.Name, viewModel.Email);
            var user = Mapper.Map<UserViewModel>(MessageBus.DispatchCommandTwoWay<LoginUserCommand, User>(command)
                .Result);

            return user;
        }    
    }
}
