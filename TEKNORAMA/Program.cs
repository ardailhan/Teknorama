using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Application.Mappings;
using TeknoramaBackOffice.Infrastructure.Tools;
using TeknoramaBackOffice.Persistance.Context;
using TeknoramaBackOffice.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TEKNORAMAContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conStr"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile(),
        new CategoryProfile(),
        new SupplierProfile(),
        new EmployeeProfile(),
        new EmployeeTerritoryProfile(),
        new ExpenseProfile(),
        new IssueProfile(),
        new MessageProfile(),
        new OrderProfile(),
        new OrderDetailProfile(),
        new ShipperProfile(),
        new TerritoryProfile(),
        new UserProfileProfile(),
        new AppUserProfile(),
        new AppRoleProfile(),
        new BasketProfile(),
        new BasketItemProfile(),
    });
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("GlobalCors", config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = JwtSettings.Audience,
        ValidIssuer = JwtSettings.Issuer,
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Key)),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("GlobalCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
