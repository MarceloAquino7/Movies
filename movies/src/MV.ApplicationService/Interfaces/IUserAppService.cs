using System;
using System.Collections.Generic;
using MV.ApplicationService.ViewModels;
using MV.Domain.CommandHandlers.User;

namespace MV.ApplicationService.Interfaces
{
    public interface IUserAppService
    {
        UserViewModel Get(Guid id);
        IEnumerable<UserViewModel> GetAll();        
        UserViewModel Login(UserViewModel viewModel);
    }
}
