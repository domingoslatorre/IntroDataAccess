namespace IntroDataAccess.Repositories;

using Microsoft.EntityFrameworkCore;
using IntroDataAccess.Models;
using IntroDataAccess.Database;


public class SistemaContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    private DatabaseConfig databaseConfig;

    public SistemaContext(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .ToTable("Usuario")
            .HasKey(u => u.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={databaseConfig.DatabaseName}");
}