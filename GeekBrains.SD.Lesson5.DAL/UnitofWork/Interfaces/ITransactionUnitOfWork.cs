using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces
{
    public interface ITransactionUnitOfWork
    {
            void Commit();
            void Remove<T>(T entity) where T : Entity1;
            void RemoveRange<T>(IEnumerable<T> entities) where T : Entity1;
            T Add<T>(T entity) where T : Entity1;
            IEnumerable<T> AddRange<T>(IEnumerable<T> entities) where T : Entity1;
            TEntity CreateNew<TEntity>() where TEntity : Entity1;
        
    }
}
