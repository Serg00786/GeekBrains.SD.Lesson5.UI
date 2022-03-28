using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Abstract;
using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Services;
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
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            AbstractHandler handler = new CreateFirstObject();
            handler.Handle();
            AbstractHandler handler1 = new CreateSecondObject();
            handler1.Handle();
        }
    }
}
