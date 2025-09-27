using Villa.Model.DTO;
using Villa.Model.Entity;

namespace Villa.Repository
{
    public interface IUserRepository
    {
        Task<bool> ISUniqueUser(string UserName);
        Task<UserDto>Register(RegistrationRequestDto dto);
        public Task<LoginResponceDto> login(LoginRequestDto dto);
    }
}
