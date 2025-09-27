using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using Villa.Model.DTO;
using Villa.Model.Entity;
using Villa.Repository;

namespace Villa.Controllers.V1
{
    [Route("api/v{version:apiVersion}/villaApi")]
    [ApiController]
    [ApiVersion("1.0")]

    public class VillaApiController : ControllerBase
    {

        private readonly IVillaRepository villaRepository;
        private readonly IMapper mp;
        public VillaApiController(IVillaRepository villaRepository, IMapper mp)
        {
            this.villaRepository = villaRepository;
            this.mp = mp;
        }
       [Authorize(Roles ="User,admin")]
        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> GetAllVillas([FromQuery]int? id,int pageSize=1,int pageNumber=5)
        {
            if(id!=null)  return Ok(await villaRepository.GetAllAsync(x=>x.Id>id,
                pageSize:pageSize,pageNumber:pageNumber));

            return Ok(await villaRepository.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber));
        }
       
        // [Authorize(Roles = "user")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOneVilla(int Id)
        {
            var villa = await villaRepository.GetOneAsync(x => x.Id == Id);
            if (villa == null)
            {
                return NotFound("This villa is not found");
            }
            return Ok(villa);
        }
        //  [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewVilla(AddVillaDto dto)
        {
            var v = mp.Map<villa>(dto);

            var villa = await villaRepository.CreateAsync(v);
            if (villa == null)
            {
                ModelState.AddModelError("CustomError", "this villa is already exist");
                return BadRequest(ModelState);
            }

            return Ok(v);
        }
        //  [Authorize(Roles = "admin")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateById(int Id, UpdateVillaDto up)
        {
            var villa = await villaRepository.UpdateByIdAsync(Id, up);
            if (villa == null)
            {
                ModelState.AddModelError("CustomError", "Sorry,This villa Id is not exsit");
                return BadRequest(ModelState);
            }

            return Ok(villa);

        }
        //  [Authorize(Roles = "admin")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById(int Id)
        {
            var v = await villaRepository.DeleteByIdAsync(x => x.Id == Id);
            if (v == null)
            {
                return BadRequest("This ID Not Found in database");
            }
            return Ok(v);
        }

    }
}
