﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Data.Context;
using Infrastructure.Options.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected DbContext Context { get; }
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(SuperDigitalDbContext dbContext)
        {
            this.Context = dbContext;
            DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> GetAllActive()
        {
            return DbSet.AsNoTracking().Where(x => x.Active);
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return expression == null ? DbSet.AsNoTracking() : DbSet.Where(expression).AsNoTracking();
        }

        public int Total(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
                return DbSet.AsNoTracking().Count();

            return DbSet.Where(expression).AsNoTracking().Count();
        }

        public void Add(TEntity obj)
        {
            obj.Active = true;
            obj.RegistrationDate = DateTime.Now;
            
            DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void AddOrUpdate(TEntity entity)
        {
            if (entity == null) return;

            if (entity.Id.GetHashCode() == 0)
                Add(entity);
            else
                Update(entity);
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }
        
        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Rollback()
        {
            try
            {
                if (Context != null)
                {
                    Context.ChangeTracker.Entries()
                        .ToList()
                        .ForEach(entry => entry.State = EntityState.Unchanged);
                }
            }
            catch
            {
            }
        }


    }
}
