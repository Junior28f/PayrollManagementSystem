using ClassLibrary1;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Interfaces.Repositories;
using Infrastructure.Repositories;
using PayrollManagementSystem.Models.Interface;
using PayrollManagementSystem.Models.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEmpleadoAsalariadoService, EmpleadoAsalariadoService>();
builder.Services.AddScoped<IEmpleadoAsalariadoPorComisionService, EmpleadoAsalaridoPorComisionService>();
builder.Services.AddScoped<IEmpleadoPorHorasService, EmpleadoPorHorasService>();
builder.Services.AddScoped<IEmpleadoPorComisionService, EmpleadoPorComisionService>();


builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();
builder.Services.AddRepositories();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
    