using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Repository.DataTransactions
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        Task<bool> IsExist(Expression<Func<TEntity,bool>>condition);
        void Save();
    }
}
