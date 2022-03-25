using GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces;
using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace GeekBrains.SD.Lesson5.DAL.UnitofWork.Service
{
    public class TransactionUnitOfWork : UnitOfWork, ITransactionUnitOfWork
    {
        #region Variables
        private readonly TransactionScope _transaction;
        private bool _transactionCompleted;
        #endregion
        public TransactionUnitOfWork()
        {
            _transaction = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel =
            IsolationLevel.ReadCommitted
            });
        }
        public void Commit()
        {
            db.SaveChanges();
            if (_transactionCompleted)
                throw new InvalidOperationException("Current transaction is already commited");
                _transaction.Complete();
            _transaction.Dispose();
            _transactionCompleted = true;
        }
        public void Remove<T>(T entity) where T : Entity1
        {
            db.Set<T>().Remove(entity);
        }
        public void RemoveRange<T>(IEnumerable<T> entities) where T : Entity1
        {
            db.Set<T>().RemoveRange(entities);
        }
        public T Add<T>(T entity) where T : Entity1
        {
            return db.Set<T>().Add(entity);
        }
        public IEnumerable<T> AddRange<T>(IEnumerable<T> entities) where T : Entity1
        {
            return db.Set<T>().AddRange(entities);
        }
        public TEntity CreateNew<TEntity>() where TEntity : Entity1
        {
            var set = db.Set<TEntity>();
            var entity = set.Create();
            set.Add(entity);
            return entity;
        }
    }
}
