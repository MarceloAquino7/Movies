using System;
using System.Collections.Generic;
using MV.Common.Repository.Contracts.Core.Entities;

namespace MV.Common.Repository.Contracts.Core.Repository
{
    public interface IPersistenceService<in TEntity> where TEntity : IDomainEntity
    {
        void Insert(TEntity instance);

        void Insert(IEnumerable<TEntity> instances);

        void Delete(IEnumerable<Guid> ids);

        void Delete(Guid id);

        void Update(TEntity instance);

        void Update(IEnumerable<TEntity> instances);
    }
}