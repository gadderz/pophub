using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pophub.Persistence.Data;
using Pophub.Persistence.DependencyInjection;

var builder = Host.CreateApplicationBuilder();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddPersistenceServices(
    builder.Configuration.GetConnectionString("DefaultConnection")!,
    "Pophub.Persistence.Migrations"
);
var host = builder.Build();

var dbService = host.Services.GetRequiredService<AppDbContext>();

if (dbService.Database.GetPendingMigrations().Any())
{
    dbService.Database.Migrate();
}
