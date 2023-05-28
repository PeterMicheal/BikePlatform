using BikePlatform.Application;
using BikePlatform.Application.CreateRepairRequest;
using BikePlatform.Domain.BikeRepairAggregate;
using BikePlatform.Infrastructure.Storage;
using BikePlatform.Infrastructure.Storage.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));
builder.Services.AddTransient<ICreateRepairRequestApplicationService, CreateRepairRequestApplicationService>();
builder.Services.AddTransient<IRepairRequestRepository, RepairRequestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors(policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
