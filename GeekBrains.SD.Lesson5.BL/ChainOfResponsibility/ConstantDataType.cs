using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Abstract;
using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Services;
using GeekBrains.SD.Lesson5.BL.Model;
using GeekBrains.SD.Lesson5.BL.Strategy.Interfaces;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Service;
using Unity;

namespace GeekBrains.SD.Lesson5.BL.ChainOfResponsibility
{
    public  class ConstantDataType : IDataType
    {
        public void TransferData()
        {
            ITransactionUnitOfWork unitOfWork = new TransactionUnitOfWork();
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            AbstractHandler handler = new CreateFirstObject(unitOfWork);
            handler.Handle();
            AbstractHandler handler1 = new CreateSecondObject(unitOfWork);
            handler1.Handle();

        }

        public void TransferData(CreateModel_BL model)
        {
            throw new System.NotImplementedException();
        }
    }
}
