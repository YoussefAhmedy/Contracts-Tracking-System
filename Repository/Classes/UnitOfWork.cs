using Contract_Tracking_System.Data;
using Contract_Tracking_System.Models;
using Contract_Tracking_System.Repository.Interfaces;

namespace Contract_Tracking_System.Repository.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext Context;
        public UnitOfWork(AppDbContext context)
        {
            Context = context;
            Customers = new MainRepository<Customer>(Context);
            Contracts = new MainRepository<Contract>(Context);
            Guarantees = new MainRepository<Guarantee>(Context);
        }

        public IRepository<Customer> Customers { get; set; }
        public IRepository<Contract> Contracts { get; set; }
        public IRepository<Guarantee> Guarantees { get; set; }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
