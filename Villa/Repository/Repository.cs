
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Villa.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext db;

        public Repository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteByIdAsync(Expression<Func<T, bool>>filter)
        {

            var entity = await GetOneAsync(filter, true);
            if (entity == null)
            {
                return null;
            }
            db.Set<T>().Remove(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter=null, bool tracked = false
            , int pageSize = 1, int pageNumber = 1)
        {
            var entity = db.Set<T>().AsQueryable();
            if (!tracked)
            {
                entity = entity.AsNoTracking();
            }
            if (filter != null)
            {
                entity = entity.Where(filter);
            }
            if (pageSize > 100) pageSize = 100;
            entity = entity.Skip(pageSize * (pageNumber - 1)).Take(pageSize); 

            
           
            return await entity.ToListAsync();
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter, bool tracked=false)
        {
            var villas = db.Set<T>().AsQueryable();
            if (!tracked)
            {
                villas = villas.AsNoTracking();
            }
            if (filter != null)
            {
                villas= villas.Where(filter);
            }
            
            return await villas.FirstOrDefaultAsync();
        }

       
    }
}
