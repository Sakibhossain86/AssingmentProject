using ExcelTech_Project.HostedServices;
using ExcelTech_Project.Models;
using ExcelTech_Project.Repostoris;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExeclDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IPatientsRepo, PatientsRepo>();
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddHostedService<DbSeederHostedService>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
