using Microsoft.EntityFrameworkCore;
using MediatR;
using server.configuration;
using server.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PokeDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString(builder.Configuration)));
builder.Services.AddMediatR(typeof(Program));


builder.Services.AddTransient<IRequestHandler<CreateUserCommand, string>, CreateUserCommandHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();