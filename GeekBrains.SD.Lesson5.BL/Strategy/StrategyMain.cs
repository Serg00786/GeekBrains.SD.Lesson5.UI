using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Abstract;
using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Services;
using GeekBrains.SD.Lesson5.BL.Strategy.Interfaces;
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
        private readonly IDataType _dataType;
        public StrategyMain(IDataType datatype)
        {
            _dataType = datatype;
        }
        public IDataType DataType { private get; set; }
        public void Transfer()
        {
            _dataType.TransferData();
        }
    }
}
