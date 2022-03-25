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
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>().RegisterType<AbstractHandler, CreateFirstObject>();
           // int id = 0;
            //ITransactionUnitOfWork writeUnitOfWork = container.Resolve<ITransactionUnitOfWork>();
         
            //    var student = writeUnitOfWork.CreateNew<Students>();
            //    student.FirstName = "Aleks";
            //    student.LastName = "Sergeev";
            //    student.Age = 27;
            //    writeUnitOfWork.Add(student);
            //    writeUnitOfWork.Commit();
                //id = student.Id;
            
            using (var unitOfWork = container.Resolve<IUnitOfWork>())
            {
                var sales = unitOfWork.GetStudentRepository().GetAll();

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
