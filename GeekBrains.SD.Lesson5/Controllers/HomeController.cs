using GeekBrains.SD.Lesson5.DAL;
using GeekBrains.SD.Lesson5.Entity.Models;
using GeekBrains.SD.Lesson5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Unity;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Interfaces;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Service;
using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Services;
using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility.Abstract;
using GeekBrains.SD.Lesson5.BL.Strategy.Interfaces;
using GeekBrains.SD.Lesson5.BL.Strategy;
using GeekBrains.SD.Lesson5.BL.ChainOfResponsibility;

namespace GeekBrains.SD.Lesson5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IDataType dataType = new ConstantDataType();
            IStrategyMain strategyMain = new StrategyMain(dataType);
            strategyMain.Transfer();


            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            using (var unitOfWork = container.Resolve<IUnitOfWork>())
            {
                var sales = unitOfWork.GetStudentRepository().GetAll().ToList();
                for (int i = 0; i < sales.Count(); i++)
                {
                    Console.WriteLine(sales[i].FirstName, sales[i].Age);
                }

            }


            return View();
        }
    


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
