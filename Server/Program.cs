using Microsoft.EntityFrameworkCore;
using MediatR;
using server.configuration;
using System.Reflection;
using server.Models;
using server.models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var vAuthSettings = builder.Configuration.GetSection("AuthSettings").Get<AuthSettings>();
builder.Services.AddSingleton(vAuthSettings); //

builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<PokeDbContext>().AddRoles<Role>().AddDefaultTokenProviders();

builder.Services.AddDbContext<PokeDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString(builder.Configuration)).UseLowerCaseNamingConvention());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(options =>
{
    options.SetIsOriginAllowed(x => _ = true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
});
app.MapControllers();

app.Run();
