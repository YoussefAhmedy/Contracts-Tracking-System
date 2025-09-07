using Contract_Tracking_System.Models;

namespace Contract_Tracking_System.Repository.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Customer> Customers { get; set; }
        IRepository<Contract> Contracts { get; set; }
        IRepository<Guarantee> Guarantees { get; set; }
        void Dispose();
    }
}
