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
using GeekBrains.SD.Lesson5.UI.Models;
using AutoMapper;
using GeekBrains.SD.Lesson5.BL.Model;

namespace GeekBrains.SD.Lesson5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStrategyMain _strategyMain;
        private readonly IMapper _mapper;

        public HomeController(IStrategyMain strategyMain, IMapper mapper)
        {
            _strategyMain = strategyMain;
            _mapper = mapper;

        }

        public IActionResult Index(CreateModel cm)
        {
            IDataType dataType = new ConstantDataType();
            var model = _mapper.Map<CreateModel_BL>(cm);
            //_strategyMain.Transfer(model);
            _strategyMain.Transfer();


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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateModel cm)
        {
            try
            {

                return RedirectToAction("Index", cm);

            }
            catch
            {
                return View();
            }

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
