using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Abstract;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Service;
using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Services
{
    public class CreateSecondObject : AbstractHandler
    {
        private readonly ITransactionUnitOfWork writeUnitOfWork;

        public CreateSecondObject(ITransactionUnitOfWork transactionUnitOfWork)
        {
            writeUnitOfWork = transactionUnitOfWork;
        }
        public override void Handle()
        {
            var student = writeUnitOfWork.CreateNew<Students>();
            student.FirstName = "Kaks";
            student.LastName = "Lee";
            student.Age = 33;
            writeUnitOfWork.Add(student);
            writeUnitOfWork.Commit();

        }
    }
}
