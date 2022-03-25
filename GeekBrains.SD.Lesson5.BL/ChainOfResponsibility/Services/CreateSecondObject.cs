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
    internal class CreateSecondObject : AbstractHandler
    {
        public override void Handle()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>()
            .RegisterType<ITransactionUnitOfWork, TransactionUnitOfWork>();
            ITransactionUnitOfWork writeUnitOfWork = container.Resolve<ITransactionUnitOfWork>();

            var student = writeUnitOfWork.CreateNew<Students>();
            student.FirstName = "Aleks";
            student.LastName = "Alekseev";
            student.Age = 33;
            writeUnitOfWork.Add(student);
            writeUnitOfWork.Commit();

        }
    }
}
