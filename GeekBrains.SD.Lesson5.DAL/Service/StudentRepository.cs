using GeekBrains.SD.Lesson5.DAL.Interfaces;
using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekBrains.SD.Lesson5.DAL.Service
{
    public class StudentRepository : Repository<Students>, IStudentRepository
    {
        public StudentRepository(StudentContext context) : base(context)
        {
        }
        public IQueryable<Students> GetAll()
        {
            try
            {
                return _db.Student;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAll() failed: {0}", ex);
                throw;
            }
        }
        public Students GetStudents(int id)
        {
            try
            {
                return _db.Student.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCustomer() failed: {0}", ex);
                throw;
            }
        }

    }
}
