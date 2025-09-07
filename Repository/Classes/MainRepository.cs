using Contract_Tracking_System.Data;
using Contract_Tracking_System.Models;
using Contract_Tracking_System.Repository.Interfaces;
using System.Linq.Expressions;

namespace Contract_Tracking_System.Repository.Classes
{
    public class MainRepository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext Context;
        
        public MainRepository(AppDbContext context)
        {
            Context = context;
        }

        public bool Add(T entity)
        {
            Context.Set<T>().Add(entity);
            int rowAffected = Context.SaveChanges();

            return rowAffected > 0;
        }

        public bool Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            int deletedAffected = Context.SaveChanges();

            return deletedAffected > 0;
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().SingleOrDefault(match);
        }

        public IQueryable<T> FindAll()
        {
            return Context.Set<T>();
        }

        public bool Save(T entity,IRepository<T>.enMode Mode)
        {
            
            switch(Mode)
            {
                case IRepository<T>.enMode.add:

                    if(Add(entity))
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                    break;

                case IRepository<T>.enMode.update:

                    return (Update(entity));
                    break;
            }

            return false;
        }

        public bool Update(T entity)
        {
            Context.Set<T>().Update(entity);
            int rowUpdated = Context.SaveChanges();

            return rowUpdated > 0;
        }
    }
}
