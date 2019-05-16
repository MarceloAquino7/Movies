using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MV.Common.Repository.Contracts.Core.Entities;

namespace MV.Common.Repository.Contracts.Core.Repository
{
    public interface IQueryService<TEntity> where TEntity : IEntityWithPrimaryKey<Guid>
    {
        TEntity FindById(Guid id);

        TEntity Find(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> All();

        IQueryable<TEntity> AllQueryable();

        IEnumerable<TEntity> FindList(Expression<Func<TEntity, bool>> expression);
    }
}