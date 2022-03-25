using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Interfaces
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void Handle();

    }
}
