using System.Linq.Expressions;

namespace Villa.Repository
{
    public interface IRepository <T>where T:class
    {
        public Task<T> CreateAsync(T villa);
        public Task<List<T>> GetAllAsync(Expression<Func<T,bool>>?filter=null,bool tracked=false
            ,int pageSize=1,int pageNumber=1);
        public Task<T> GetOneAsync(Expression<Func<T, bool>> filter, bool tracked = false);
        public Task<T> DeleteByIdAsync(Expression<Func<T, bool>> filter);
    }
}
