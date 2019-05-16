using AutoMapper;
using MV.ApplicationService.ViewModels;
using MV.Domain.Models;

namespace MV.ApplicationService.Mappings
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {            
            CreateMap<User, UserViewModel>();
        }
    }
}
