using GeekBrains.SD.Lesson5.DAL.Interfaces;
using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        IStudentRepository GetStudentRepository();
        List<T> ExecuteCustomQuery<T>(string command, params KeyValuePair<string, object>[] parameters);
        T Get<T>(int id) where T : Entity1;
        IQueryable<T> GetAll<T>() where T : Entity1;
        void AsNoLazyLoading();
    }
}
