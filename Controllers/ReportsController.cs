using Contract_Tracking_System.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Contract_Tracking_System.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork myUnit;

        public ReportsController(IUnitOfWork unit)
        {
            myUnit = unit;
        }
        public IActionResult Index()
        {
            ViewBag.ActiveContracts = myUnit.Contracts.FindAll().Where(x => x.EndContract > DateTime.Now.AddMonths(1)).Count();
            ViewBag.FinishedContracts = myUnit.Contracts.FindAll().Where(x => x.EndContract < DateTime.Now).Count();
            ViewBag.SoonFinishedContracts = myUnit.Contracts.FindAll().Where(x => x.EndContract > DateTime.Now && DateTime.Now.AddDays(20) > x.EndContract).Count();

            var contracts = myUnit.Contracts.FindAll().Include(x => x.Customer).
                Select(x => new
                {
                    number = x.ContractNumber,
                    CustomerName = x.Customer.Name,
                    Kind = x.ContractKind,
                    start = x.StartContract,
                    end = x.EndContract,
                    Status = x.EndContract > DateTime.Now.AddMonths(1) ? "نشط" : x.EndContract > DateTime.Now.AddDays(10) ? "ستنتهي قريبا" : "منتهي"
                }).Take(5);

            var guarantees = myUnit.Guarantees.FindAll().Include(x => x.Contract).
                Select(g => new
                {
                    Name = g.Name,
                    ContractCount = (myUnit.Contracts.FindAll().Where(x => x.ID == g.ContractID).Count()),
                    start = g.GuaranteeStart,
                    end = g.GuaranteeEnd,
                    status = g.GuaranteeEnd > DateTime.Now.AddMonths(1) ? "نشط" : g.GuaranteeEnd > DateTime.Now.AddDays(10) ? "ستنتهي قريبا" : "منتهي"
                }).Take(5);


            var customers = myUnit.Customers.FindAll().
                Select(x => new
                {
                    Name = x.Name,
                    ContractsCount = (myUnit.Contracts.FindAll().Where(c => c.CustomerID == x.ID).Count()),
                    ActiveContracts = (myUnit.Contracts.FindAll().Where(c => c.EndContract > DateTime.Now && c.CustomerID == x.ID).Count()),
                    FinishedContracts = (myUnit.Contracts.FindAll().Where(c => c.EndContract < DateTime.Now && c.CustomerID == x.ID).Count())
                });


            var ContractsChart = (myUnit.Contracts.FindAll().
                Select(x => new { Name = x.EndContract > DateTime.Now.AddMonths(1) ? "نشط" : x.EndContract > DateTime.Now ? "ستنتهي قريبا" : "منتهية" })).
                GroupBy(c => c.Name).Select(g => new
                {
                    status = g.Key,
                    count = g.Count()
                }).OrderByDescending(x => x.count).ToList();

            var guaranteesChart = myUnit.Guarantees.FindAll()
                .Select(x => new
                {
                    Name = x.Name,
                    Days = x.GuaranteeEnd.Subtract(DateTime.Now).TotalDays
                }).ToList();

            ViewBag.guaranteeLables = guaranteesChart.Select(x => x.Name).ToList();
            ViewBag.guaranteeData = guaranteesChart.Select(x => x.Days).ToList();
            ViewBag.contractChartLables = ContractsChart.Select(x => x.status).ToList();
            ViewBag.contractChartData = ContractsChart.Select(x => x.count).ToList();
            ViewBag.CustomersTable = customers;
            ViewBag.GuaranteesTable = guarantees;
            ViewBag.ContractsTable = contracts;

            return View();
        }
    }
}
