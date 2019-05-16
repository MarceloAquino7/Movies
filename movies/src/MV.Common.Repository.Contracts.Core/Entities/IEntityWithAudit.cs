using System;

namespace MV.Common.Repository.Contracts.Core.Entities
{
    public interface IEntityWithAudit
    {
        DateTime CreateDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string AuditUserName { get; set; }
        bool IsActive { get; set; }
    }
}