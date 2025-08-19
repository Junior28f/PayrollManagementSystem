using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {

        
    }
    public DbSet< EmpleadoAsalariado> EmpleadoAsalariados { get; set; }
    public DbSet<EmpleadoAsalaridoPorComision> EmpleadoAsalaridoPorComision { get; set; }
    public DbSet<EmpleadoPorComision> EmpleadoPorComision { get; set; } 
    public DbSet<EmpleadoPorhoras> EmpleadoPorHoras { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EmpleadoAsalariado>()
            .Property(e => e.Salariosemanal1)
            .HasPrecision(18, 2);

        modelBuilder.Entity<EmpleadoPorComision>()
            .Property(e => e.VentaBruta)
            .HasPrecision(18, 2);

        modelBuilder.Entity<EmpleadoAsalaridoPorComision>()
            .Property(e => e.VentaBruta)
            .HasPrecision(18, 2);

        modelBuilder.Entity<EmpleadoPorhoras>()
            .Property(e => e.SueldoPorhora)
            .HasPrecision(18, 2);
    }

}