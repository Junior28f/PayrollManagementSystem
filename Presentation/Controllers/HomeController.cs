using System.Diagnostics;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using PayrollManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace PayrollManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        } 

        public IActionResult Index()
        {
            string dbStatus;

            try
            {
                _context.Database.OpenConnection();
                _context.Database.CloseConnection();
                dbStatus = "Conexión a la base de datos exitosa";
            }
            catch (Exception ex)
            {
                dbStatus = $"Error de conexión: {ex.Message}";
            }

            ViewBag.DbStatus = dbStatus;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}