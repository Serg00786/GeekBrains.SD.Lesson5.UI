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
using GeekBrains.SD.Lesson5.DAL.Interfaces;
using GeekBrains.SD.Lesson5.DAL.UnitofWork.Service;

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
            using (var context = new StudentContext())
            {
                var student = new Students();
                student.FirstName = "Aleks";
                student.Age = 27;
                context.Student.Add(student);
                context.SaveChanges();


                IUnityContainer container = new UnityContainer();
                container.RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<ITransactionUnitOfWork, TransactionUnitOfWork>();
                using (var unitOfWork = container.Resolve<IUnitOfWork>())
                {
                    var products = unitOfWork.GetProductRepository().GetAll().ToList();
                    foreach (var prod in products)

                {
                        Console.WriteLine("Name: " + prod.Name + " ,Price: " + prod.Price);
                    }
                    var customer = unitOfWork.GetCustomerRepository().GetAll().First();
                    var sales = unitOfWork.GetSaleRepository().GetAllByCustomerId(customer.Id);
                    foreach (var sale in sales)
                    {
                        Console.WriteLine("Customer name: {0}, TotalCost: {1}",
                        sale.Customer.FirstName, sale.TotalCost);
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
