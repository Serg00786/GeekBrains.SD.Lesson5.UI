using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeekBrains.SD.Lesson5.Entity.Models;

namespace GeekBrains.SD.Lesson5.DAL.Interfaces
{
    public interface IStudentRepository : IRepository<Students>
    {
        IQueryable<Students> GetAll();
        Students GetStudents(int id);

    }
}
