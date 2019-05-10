using System;
using MV.Common.Repository.Contracts.Core.Entities;

namespace MV.Common.Repository.Contracts.Core.Repository
{
    public interface IRepository<TEntity> :
        IPersistenceService<TEntity>,
        IQueryService<TEntity>, IDisposable where TEntity : IDomainEntity
    {
    }
}