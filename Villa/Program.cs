
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Villa;
using Villa.Mapping;
using Villa.Model.Entity;
using Villa.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Villa Management API",
        Description = "API to manage Villa!"
    });

    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "Villa Management API",
        Description = "API to manage Villa!"
    });
});

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IVillaRepository, VillaRepository>();
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(MappingConf));



builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true; // »ÌﬁÊ·ﬂ «ÌÂ «·›—Ã‰ «·„ «ÕÂ 
    options.AssumeDefaultVersionWhenUnspecified = true; // »‰” Œœ„ «·‰”ÕÂ «·«› —«÷ÌÂ ›Ì Õ«·Â ⁄œ„  ÕœÌœ «·‰”ŒÂ «·„ÿ·Ê»Â
    options.DefaultApiVersion = new ApiVersion(1, 0); // «·‰”ŒÂ «·«› —«÷ÌÂ ÂÌ 1
});
builder.Services.AddVersionedApiExplorer(options =>
{

    options.GroupNameFormat = "'v'VVV"; //  ”„Ì… «·≈’œ«—«  »«·‘ﬂ· v1, v2
    options.SubstituteApiVersionInUrl = true; // Ì” œ⁄Ì «·›Ì—Ã‰ «·Ì« »œ· „« «ﬂ »Â »‰›” ›Ì ﬂ· „—Â 
});

builder.Services.AddResponseCaching();



var key = builder.Configuration.GetValue<string>("Jwt:Key");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "VillaV1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "VillaV2");

    }
    );
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
