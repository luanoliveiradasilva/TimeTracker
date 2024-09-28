using app.Adapters;
using app.Infrastructure;
using app.Repository;
using app.Repository.Interfaces;
using app.Services;
using app.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TimeTrackerContext>(options => options.UseMySql
(builder.Configuration.GetConnectionString("TimeTracker"), new MySqlServerVersion(new Version(8, 0, 26))));
builder.Services.AddScoped<ITimeTrackerService, TimeTrackerService>();
builder.Services.AddScoped<ITimeTrackerRepo, TimeTrackerRepoRepository>();
builder.Services.AddScoped<TimeBankAdapter, TimeBankAdapter>();

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
