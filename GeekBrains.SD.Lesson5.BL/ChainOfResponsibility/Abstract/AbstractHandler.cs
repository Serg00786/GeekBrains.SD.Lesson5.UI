using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Interfaces;
using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Abstract
{
   public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNext(IHandler handler)

    {
        this._nextHandler = handler;

        return handler;
     }

    public virtual void Handle()
    {

    }
}

}
