using GeekBrains.SD.Lesson5.DAL.Interfaces;
using GeekBrains.SD.Lesson5.DAL.Service;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces;
using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GeekBrains.SD.Lesson5.DAL.UnitofWork.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private IStudentRepository studentRepository;
        protected readonly StudentContext db;

        public UnitOfWork()
        {
            db= new StudentContext();
        }

        public void AsNoLazyLoading()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public void Dispose()
        {
            if(studentRepository !=null)
                studentRepository.Dispose();
        }

        public List<T> ExecuteCustomQuery<T>(string command, params KeyValuePair<string, object>[] parameters)
        {
            var _params = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; ++i)
                _params[i] = new SqlParameter(parameters[i].Key,
                parameters[i].Value);
            return db.ExecuteStoreQuery<T>(command, _params).ToList();

        }

        public T Get<T>(int id) where T : Entity1
        {
            var result = db.Set<T>().Find(id);
            if (result == null)
                {
                    Console.WriteLine("Entity {0}:{1} not found in database", typeof(T),
                    id);
                    throw new Exception(string.Format("Entity {0}:{1} not found in database", typeof(T), id));
                }
                return result;
            }

        public IQueryable<T> GetAll<T>() where T : Entity1
        {
            var result = db.Set<T>();
            if (result == null)
            {
                Console.WriteLine("Entity type {0} not found in database",
                typeof(T));
                throw new Exception(string.Format("Entity type {0} not found in database", typeof(T)));
            }
            return result;
        }

        public IStudentRepository GetStudentRepository()
        {
            return studentRepository ?? (studentRepository = new StudentRepository(db));

        }
    }
}
