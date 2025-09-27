using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Villa.Model.DTO;
using Villa.Model.Entity;

namespace Villa.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;
        private readonly IMapper mp;
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRepository(AppDbContext db, IMapper mp, IConfiguration configuration,
            UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.mp = mp;
            this.configuration = configuration;
            this.userManager = userManager;
        }
      

        public async Task<bool> ISUniqueUser(string UserName)
        {
            var user = await db.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName == UserName);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponceDto> login(LoginRequestDto dto)
        {

            var user = await db.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName.ToLower() == dto.UserName.ToLower());
            bool isvalid = await userManager.CheckPasswordAsync(user, dto.Password);
            if (!isvalid && user == null)
            {
                return null;
            }
            var roles = await userManager.GetRolesAsync(user);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, dto.UserName));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            LoginResponceDto ans = new LoginResponceDto();
            ans.Token = new JwtSecurityTokenHandler().WriteToken(token);
            ans.User = mp.Map<UserDto>(user);
            return ans;
        }

        public async Task<UserDto> Register(RegistrationRequestDto dto)
        {
            ApplicationUser user = mp.Map<ApplicationUser>(dto);
            var res = await userManager.CreateAsync(user, dto.Password);
            if (res.Succeeded)
            {
                if (dto.Roles != null && dto.Roles.Any())
                {
                    res = await userManager.AddToRolesAsync(user, dto.Roles);
                    if (res.Succeeded)
                    {
                        return mp.Map<UserDto>(user);
                    }
                }
                else
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
            return null;
        }
    }
}
