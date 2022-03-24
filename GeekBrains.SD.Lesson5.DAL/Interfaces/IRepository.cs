using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrains.SD.Lesson5.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        T Get(int id);
        T Save(T Entity);
    }
}
