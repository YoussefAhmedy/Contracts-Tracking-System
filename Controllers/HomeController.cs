using System.Diagnostics;
using Contract_Tracking_System.Models;
using Contract_Tracking_System.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contract_Tracking_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork myUnit;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unit)
        {
            _logger = logger;
            myUnit = unit;
        }

        public IActionResult Index()
        {
            ViewBag.CustomersCount = myUnit.Customers.FindAll().Count();
            ViewBag.ContractsActiveCount = myUnit.Contracts.FindAll().Where(x => x.EndContract > DateTime.Now).Count();
            ViewBag.GuaranteesFinished = myUnit.Guarantees.FindAll().Where(x => x.GuaranteeEnd < DateTime.Now).Count();
            ViewBag.ContractsFinishedCount = myUnit.Contracts.FindAll().Where(x => DateTime.Now > x.EndContract && DateTime.Now < x.EndContract.AddDays(10)).Count();

            var Contracts = myUnit.Contracts.FindAll().Where(x => x.StartContract.AddMonths(1) > DateTime.Now).Take(10).Include(x => x.Customer);
            var contractsData = myUnit.Contracts.FindAll()
                                .GroupBy(c => c.ContractKind)
                                .Select(g => new
                                {
                                    ContractKind = g.Key,
                                    Count = g.Count()
                                })
                                .ToList();

            // äãÑÑ ÇÓã ÇáäæÚ ßÜ Labels
            ViewBag.Labels = contractsData.Select(x => x.ContractKind).ToList();

            // äãÑÑ ÚÏÏ ÇáÊßÑÇÑÇÊ ßÜ Data
            ViewBag.Data = contractsData.Select(x => x.Count).ToList();
            return View(Contracts);
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
