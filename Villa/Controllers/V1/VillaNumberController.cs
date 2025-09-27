using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Villa.Model.DTO;
using Villa.Model.Entity;
using Villa.Repository;

namespace Villa.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    
    public class VillaNumberController : ControllerBase
    {
        private readonly IVillaNumberRepository villaNumberRepo;
        private readonly IMapper mp;
        private readonly IVillaRepository villaRepository;

        public VillaNumberController(IVillaNumberRepository villaNumberRepo,
            IMapper mp, IVillaRepository villaRepository)
        {
            this.villaNumberRepo = villaNumberRepo;
            this.mp = mp;
            this.villaRepository = villaRepository;
        }
        [Authorize(Roles = "user")]
        [HttpGet]
      
        public async Task<IActionResult> GetAllVillas()
        {
            return Ok(await villaNumberRepo.GetAllAsync(pageNumber:1,pageSize:1));
        }
        [Authorize(Roles = "user")]
        [HttpGet("{VillaNumber}")]
       
        public async Task<IActionResult> GetOneVilla(int VillaNumber)
        {
            var villaNo = await villaNumberRepo.GetOneAsync(x => x.VillaNo == VillaNumber);
            if (villaNo == null)
            {
                return NotFound("This villa is not found");
            }
            return Ok(villaNo);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewVillanumber(VillaNumberCreatedDto dto)
        {
            var v = mp.Map<VillaNumber>(dto);
            if (dto.VillaID != null)
            {
                var FkValid = await villaRepository.GetOneAsync(x => x.Id == dto.VillaID);
                if (FkValid == null) return BadRequest("This Villa Id is not exist!");
            }
            try
            {
                var villa = await villaNumberRepo.CreateAsync(v);
                return Ok(v);
            }
            catch
            {

                return BadRequest("Villa Number Is aLready Exist :)");
            }


        }
        [HttpPut("{VillaNumber}")]
        public async Task<IActionResult> UpdateById(int VillaNumber, VillaNumberUpdatedDto up)
        {
            if (up.VillaID != null)
            {
                var FkValid = await villaRepository.GetOneAsync(x => x.Id == up.VillaID);
                if (FkValid == null) return BadRequest("This Villa Id is not exist!");
            }

            try
            {
                var villanum = await villaNumberRepo.UpdateByIdAsync(VillaNumber, up);
                if (villanum == null)
                {
                    ModelState.AddModelError("CustomError", "Sorry,This villa Number is not exsit");
                    return BadRequest(ModelState);
                }

                return Ok(villanum);
            }
            catch
            {
                return BadRequest("This Villa Number is already exist!");
            }


        }
        [HttpDelete("{VillaNumber}")]
        public async Task<IActionResult> DeleteById(int VillaNumber)
        {
            var v = await villaNumberRepo.DeleteByIdAsync(x => x.VillaNo == VillaNumber);

            if (v == null) return BadRequest("this villa is not exist");
            return Ok(v);
        }

    }
}
