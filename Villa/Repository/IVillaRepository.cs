using Villa.Model.DTO;
using Villa.Model.Entity;

namespace Villa.Repository
{
    public interface IVillaRepository:IRepository<villa>
    {
       
        public Task<villa> UpdateByIdAsync(int Id, UpdateVillaDto villa);
    }
}
