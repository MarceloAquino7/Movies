using System;
using System.ComponentModel.DataAnnotations;

namespace MV.Common.Repository.Contracts.Core.Entities
{
    public abstract class DomainEntity : IDomainEntity
    {
        [Key] public Guid Id { get; set; }

        [Required] public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string AuditUserName { get; set; }

        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Type:{GetType().Name} - Id:{Id}";
        }
    }
}