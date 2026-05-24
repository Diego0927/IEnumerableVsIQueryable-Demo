using IEnumerableVsIQueryable.Console.Entities;
using Microsoft.EntityFrameworkCore;

namespace IEnumerableVsIQueryable.Console.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nombre)
                  .HasMaxLength(100);

            entity.Property(c => c.Ciudad)
                  .HasMaxLength(50);

            entity.Property(c => c.Salario)
                  .HasPrecision(12, 2);

            entity.Property(c => c.TipoCliente)
                  .HasMaxLength(20);
        });
    }
}