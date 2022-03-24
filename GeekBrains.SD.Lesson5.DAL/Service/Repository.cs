using GeekBrains.SD.Lesson5.DAL.Interfaces;
using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace GeekBrains.SD.Lesson5.DAL.Service
{
    public abstract class Repository<T> : IRepository<T> where T: Entity1
    {
        protected readonly StudentContext _db;
        protected Repository(StudentContext db)
        {
            _db = db;
        }

        public void Dispose()
        {

        }

        public T Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id");
            T entity = null;
            try
            {
                entity = GetEntity(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("db.Set<{2}>().Find({0}) threw exception: {1}",
                id, ex, typeof(T).Name);
                throw;
            }
            return entity;

        }

        public T Save(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Console.WriteLine("Saving '{0}'", entity);
            return entity.Id == 0 ? Add(entity) : Update(entity);
        }

        protected virtual T GetEntity(int id)
        {
            return _db.Set<T>().Find(id);
        }

        private T Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        }
        private T Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return entity;
        }

    }
}
