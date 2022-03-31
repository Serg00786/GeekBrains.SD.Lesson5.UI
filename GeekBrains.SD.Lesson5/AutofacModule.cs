using Autofac;
using GeekBrains.SD.Lesson5.BL.Strategy;
using GeekBrains.SD.Lesson5.BL.Strategy.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeekBrains.SD.Lesson5
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StrategyMain>().As<IStrategyMain>()
            .InstancePerLifetimeScope();
        }
    }
}
