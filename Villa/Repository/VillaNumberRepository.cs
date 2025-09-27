using AutoMapper;
using Villa.Model.DTO;
using Villa.Model.Entity;

namespace Villa.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly AppDbContext db;
        private readonly IMapper mp;

        public VillaNumberRepository(AppDbContext db,IMapper mp):base(db)
        {
            this.db = db;
            this.mp = mp;
        }
        public async Task<VillaNumber> UpdateByIdAsync(int Id, VillaNumberUpdatedDto villaNum)
        {

            var v = await GetOneAsync(x=>x.VillaNo==Id,true);
            if (v == null)
            {
                return null;
            }
            mp.Map(villaNum, v);
            v.UpdatedTime = DateTime.Now;
            await db.SaveChangesAsync();
            return v;
        }
    }
}
