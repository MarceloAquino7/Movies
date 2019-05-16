using System;

namespace MV.Common.Repository.Contracts.Core.Entities
{
    public interface IDomainEntity :
        IEntityWithPrimaryKey<Guid>,
        IEntityWithAudit
    {
    }
}