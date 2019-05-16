using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MV.Common.Repository.Contracts.Core.Entities;
using MV.Common.Repository.Contracts.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace MV.Common.Repository.EFCore
{
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : DomainEntity
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbSet;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Cleanup
                context.Dispose();
            }
        }

        public EfCoreRepository(DbContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.context.ChangeTracker.LazyLoadingEnabled = false;

            dbSet = this.context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return dbSet.AsEnumerable();
        }

        public IQueryable<TEntity> AllQueryable()
        {
            return dbSet.AsQueryable();
        }

        public void Delete(IEnumerable<Guid> ids)
        {
            foreach (var id in ids) DeleteInstance(id);

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            DeleteInstance(id);
            context.SaveChanges();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            var query = dbSet.Where(expression);
            return query.FirstOrDefault(x => x.IsActive);
        }

        public TEntity FindById(Guid id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> FindList(Expression<Func<TEntity, bool>> expression)
        {
            var query = dbSet.Where(expression);
            return query.Where(x => x.IsActive).ToArray();
        }

        public void Insert(TEntity instance)
        {
            instance.Id = Guid.NewGuid();
            instance.CreateDate = DateTime.Now;
            instance.IsActive = true;

            dbSet.Add(instance);
            context.SaveChanges();
        }

        public void Insert(IEnumerable<TEntity> instances)
        {
            foreach (var instance in instances) dbSet.Add(instance);

            context.SaveChanges();
        }

        public void Update(TEntity instance)
        {
            UpdateInstance(instance);
            context.SaveChanges();
        }

        public void Update(IEnumerable<TEntity> instances)
        {
            foreach (var instance in instances) UpdateInstance(instance);

            context.SaveChanges();
        }

        private void DeleteInstance(Guid id)
        {
            dbSet.Remove(dbSet.Find(id));
        }

        private void UpdateInstance(TEntity instance)
        {
            instance.ModifiedDate = DateTime.Now;
            dbSet.Update(instance);
        }
    }
}