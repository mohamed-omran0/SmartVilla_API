using AutoMapper;
using Villa.Model.DTO;
using Villa.Model.Entity;

namespace Villa.Mapping
{
    public class MappingConf : Profile
    {
        public MappingConf()
        {
            CreateMap<villa, villaDto>().ReverseMap();

            CreateMap<villa, AddVillaDto>().ReverseMap();

            CreateMap<UpdateVillaDto, villa>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberCreatedDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdatedDto>().ReverseMap();
            CreateMap<RegistrationRequestDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser,UserDto>().ReverseMap();

        }

    }
}
