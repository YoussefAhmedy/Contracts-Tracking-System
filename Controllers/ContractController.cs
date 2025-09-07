using Contract_Tracking_System.Models;
using Contract_Tracking_System.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Contract = System.Diagnostics.Contracts.Contract;

namespace Contract_Tracking_System.Controllers
{
    public class ContractController : Controller
    {
        private readonly IUnitOfWork myUnit;

        private const int PageSize = 5;

        public ContractController(IUnitOfWork unit)
        {
            myUnit = unit;
        }
        public IActionResult Index(int page=1)
        {
            var totalCustomers = myUnit.Contracts.FindAll().Count();
            var totalPages = (int)Math.Ceiling(totalCustomers / (double)PageSize);

            var contracts = myUnit.Contracts.FindAll()
                            .Include(c => c.Customer)   // هنا تربط العقود بالعميل
                            .OrderBy(c => c.ID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize)
                            .ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(contracts);
        }

        public IActionResult AddOrEdit(int? Id)
        {
            ViewBag.Customers = myUnit.Customers.FindAll().Select(x => new { id = x.ID, name = x.Name }).ToList();
            if(Id == null || Id == 0)
            {
                IRepository<Models.Contract>.Mode = IRepository<Models.Contract>.enMode.add;
                return View();
            }

            var contract = myUnit.Contracts.Find(x => x.ID == Id);

            if(contract == null)
            {
                return NotFound();
            }


            IRepository<Models.Contract>.Mode = IRepository<Models.Contract>.enMode.update;
            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Models.Contract contract)
        {
            if(ModelState.IsValid)
            {
                //if(!myUnit.Contracts.FindAll().Any(x => x.CustomerID == contract.CustomerID))
                //{
                //    ModelState.AddModelError("custom", "هذا العميل غير موجود في النظام");
                //    return View(contract);
                //}

                myUnit.Contracts.Save(contract,IRepository<Models.Contract>.Mode);
                return RedirectToAction("Index");
            }

            ViewBag.Customers = myUnit.Customers.FindAll().Select(x => new { id = x.ID, name = x.Name }).ToList();
            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var contract = myUnit.Contracts.Find(x => x.ID == id);

            if (contract == null)
            {
                return NotFound();
            }

            myUnit.Contracts.Delete(contract);
            return RedirectToAction("Index");
        }
    }
}
