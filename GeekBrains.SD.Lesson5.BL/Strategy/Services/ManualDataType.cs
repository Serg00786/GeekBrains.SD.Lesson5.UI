using GeekBrains.SD.Lesson5.BL.Model;
using GeekBrains.SD.Lesson5.BL.Strategy.Interfaces;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Service;
using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace GeekBrains.SD.Lesson5.BL.Strategy.Services
{
    internal class ManualDataType : IDataType
    {
        private readonly ITransactionUnitOfWork _writeUnitOfWork;

        public ManualDataType(ITransactionUnitOfWork writeUnitOfWork)
        {
            _writeUnitOfWork = writeUnitOfWork;
        }

        public void TransferData(CreateModel_BL model)
        {
            //var student = _writeUnitOfWork.CreateNew<Students>();
            //student.FirstName = "Aleks";
            //student.LastName = "Sergeev";
            //student.Age = 27;
            //_writeUnitOfWork.Add(student);
            //_writeUnitOfWork.Commit();

        }

        public void TransferData()
        {
            throw new NotImplementedException();
        }
    }
}
