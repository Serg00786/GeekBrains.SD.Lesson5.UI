using GeekBrains.SD.Lesson5.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrains.SD.Lesson5.BL.Strategy.Interfaces
{
    public interface IStrategyMain
    {
        void Transfer(CreateModel_BL model);
        void Transfer();
    }
}
