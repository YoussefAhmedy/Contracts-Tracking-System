using Contract_Tracking_System.Models;
using Contract_Tracking_System.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contract_Tracking_System.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork myUnit;

        private const int PageSize = 5; // عدد العملاء في الصفحة

        public CustomerController(IUnitOfWork unit)
        {
            myUnit = unit;
        }

        public IActionResult Index(int page = 1)
        {
            var totalCustomers = myUnit.Customers.FindAll().Count();
            var totalPages = (int)Math.Ceiling(totalCustomers / (double)PageSize);

            var customers = myUnit.Customers.FindAll()
                .OrderBy(c => c.ID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(customers);
        }

        public IActionResult AddOrEdit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                IRepository<Customer>.Mode = IRepository<Customer>.enMode.add;
                return View();
            }

            var customer = myUnit.Customers.Find(c => c.ID == Id);

            if(customer == null)
            {
                return NotFound();
            }

            IRepository<Customer>.Mode = IRepository<Customer>.enMode.update;
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                myUnit.Customers.Save(customer,IRepository<Customer>.Mode);
                return RedirectToAction("Index");
            }

            else
            {
                return View(customer);
            }
        }

        [HttpPost]
        public IActionResult Delete(int? ID)
        {
            if(ID == 0 || ID == null)
            {
                return NotFound();
            }

            var customer = myUnit.Customers.Find(x => x.ID == ID);

            if( customer == null)
            {
                return NotFound();
            }

            myUnit.Customers.Delete(customer);
            return RedirectToAction("Index");
        }
    }
}
