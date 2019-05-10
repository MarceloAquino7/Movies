using System;
using MV.Common.Repository.Contracts.Core.Entities;

namespace MV.ApplicationService.ViewModels
{
    public abstract class BaseViewModel : IBaseViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string AuditUserName { get; set; }

        public bool IsActive { get; set; }
    }   
}
