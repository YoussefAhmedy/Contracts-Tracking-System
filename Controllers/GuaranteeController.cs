using Contract_Tracking_System.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Contract_Tracking_System.Controllers
{
    public class GuaranteeController : Controller
    {
        private readonly IUnitOfWork myUnit;

        private const int PageSize = 5;
        public GuaranteeController(IUnitOfWork unit)
        {
            myUnit = unit;
        }

        public IActionResult Index(int page = 1)
        {
            var totalCustomers = myUnit.Guarantees.FindAll().Count();
            var totalPages = (int)Math.Ceiling(totalCustomers / (double)PageSize);

            var guarantees = myUnit.Guarantees.FindAll()
                            .Include(c => c.Contract)   // هنا تربط العقود بالعميل
                            .OrderBy(c => c.ID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize)
                            .ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(guarantees);
        }

        public IActionResult AddOrEdit(int? Id)
        {
            ViewBag.Contracts = myUnit.Contracts.FindAll().Select(x => new { id = x.ID, name = x.Name }).ToList();
            if (Id == null || Id == 0)
            {
                IRepository<Models.Guarantee>.Mode = IRepository<Models.Guarantee>.enMode.add;
                return View();
            }

            var contract = myUnit.Guarantees.Find(x => x.ID == Id);

            if (contract == null)
            {
                return NotFound();
            }


            IRepository<Models.Guarantee>.Mode = IRepository<Models.Guarantee>.enMode.update;
            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Models.Guarantee guarantee)
        {
            if (ModelState.IsValid)
            {
                //if(!myUnit.Contracts.FindAll().Any(x => x.CustomerID == contract.CustomerID))
                //{
                //    ModelState.AddModelError("custom", "هذا العميل غير موجود في النظام");
                //    return View(contract);
                //}

                myUnit.Guarantees.Save(guarantee, IRepository<Models.Guarantee>.Mode);
                return RedirectToAction("Index");
            }

            ViewBag.Customers = myUnit.Customers.FindAll().Select(x => new { id = x.ID, name = x.Name }).ToList();
            return View(guarantee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var guarantee = myUnit.Guarantees.Find(x => x.ID == id);

            if (guarantee == null)
            {
                return NotFound();
            }

            myUnit.Guarantees.Delete(guarantee);
            return RedirectToAction("Index");
        }
    }
}
