using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility;
using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Abstract;
using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Services;
using GeekBrains.SD.Lesson5.BL.Model;
using GeekBrains.SD.Lesson5.BL.Strategy.Interfaces;
using GeekBrains.SD.Lesson5.BL.Strategy.Services;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace GeekBrains.SD.Lesson5.BL.Strategy
{
    public class StrategyMain : IStrategyMain
    {
        public IDataType DataType { private get; set; }
        ITransactionUnitOfWork unitOfWork = new TransactionUnitOfWork();
        IDataType datatype = new ConstantDataType();
        


        public void Transfer(CreateModel_BL model)
        {
            IDataType datatype = new ManualDataType(unitOfWork);
            datatype.TransferData(model);
        }

        public void Transfer()
        {
            datatype.TransferData();
        }
    }
}
