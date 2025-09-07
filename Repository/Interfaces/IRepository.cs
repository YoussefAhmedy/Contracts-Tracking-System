using Azure.Core.GeoJson;
using System.Linq.Expressions;

namespace Contract_Tracking_System.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        enum enMode { add=1 , update=2};
        static enMode Mode { get; set; }
        T Find(Expression<Func<T,bool>> match);
        IQueryable<T> FindAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save(T entity,enMode Mode);
    }
}
