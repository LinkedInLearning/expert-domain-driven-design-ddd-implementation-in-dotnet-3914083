using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Api.Application;
using Wpm.Clinic.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClinicDbContext>(options =>
{
    options.UseSqlite("Data Source=WpmClinic.db");
});
builder.Services.AddScoped<ClinicApplicationService>();
var app = builder.Build();
app.EnsureDbIsCreated();
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
