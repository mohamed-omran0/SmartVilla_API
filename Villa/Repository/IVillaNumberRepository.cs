using Villa.Model.DTO;
using Villa.Model.Entity;

namespace Villa.Repository
{
    public interface IVillaNumberRepository:IRepository<VillaNumber>
    {
        public Task<VillaNumber> UpdateByIdAsync(int Id, VillaNumberUpdatedDto villaNum);

    }
}
