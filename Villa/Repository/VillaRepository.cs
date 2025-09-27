using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Villa.Model.DTO;
using Villa.Model.Entity;

namespace Villa.Repository
{
    public class VillaRepository :Repository<villa>,IVillaRepository
    {
        private readonly AppDbContext db;
        private readonly IMapper mp;

        public VillaRepository(AppDbContext db, IMapper mp):base(db)
        {
            this.db = db;
            this.mp = mp;
        }
    

        public async Task<villa> UpdateByIdAsync(int Id, UpdateVillaDto up)
        {
            var v = await GetOneAsync(x=>x.Id==Id,true);
            if (v == null)
            {
                return null;
            }
            mp.Map(up, v);
            v.UpdatedTime = DateTime.Now;   
            await db.SaveChangesAsync();
            return v;
        }
    }
}
