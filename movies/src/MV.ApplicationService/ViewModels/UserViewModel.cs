using System;

namespace MV.ApplicationService.ViewModels
{
    public class UserViewModel : BaseViewModel
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
