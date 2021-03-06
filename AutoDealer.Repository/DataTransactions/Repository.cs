﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoDealer.Data.BaseType;
using AutoDealer.Repository.ApplicationContext;

namespace AutoDealer.Repository.DataTransactions
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private AutoDealerContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(AutoDealerContext autoDealerContext)
        {
            _context = autoDealerContext;
            _dbSet = _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = _dbSet.Where(filter);
            }

            return query;
        }

        public  TEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(c => c.ID == id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async void Delete(int id)
        {
            var entity =await _dbSet.FindAsync(id);
            Delete(entity);
        }

        public bool  IsExist(Expression<Func<TEntity, bool>> condition)
        {
            return _dbSet.Any(condition);
        }

        public void Save()
        {
          _context.SaveChanges();
        }
        #region Dispose

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
