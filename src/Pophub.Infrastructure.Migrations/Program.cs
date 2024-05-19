using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pophub.Infrastructure.Data;
using Pophub.Infrastructure.DependencyInjection;

var builder = Host.CreateApplicationBuilder();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddInfrastructureServices(
    builder.Configuration.GetConnectionString("DefaultConnection")!,
    "Pophub.Infrastructure.Migrations"
);
var host = builder.Build();

var dbService = host.Services.GetRequiredService<AppDbContext>();

if (dbService.Database.GetPendingMigrations().Any())
{
    dbService.Database.Migrate();
}
