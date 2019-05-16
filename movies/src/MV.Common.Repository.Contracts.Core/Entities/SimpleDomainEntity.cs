using System;
using System.ComponentModel.DataAnnotations;

namespace MV.Common.Repository.Contracts.Core.Entities
{
    public abstract class SimpleDomainEntity : IEntityWithPrimaryKey<Guid>
    {
        [Key] public Guid Id { get; set; }
    }
}