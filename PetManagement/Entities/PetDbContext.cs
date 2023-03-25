using Microsoft.EntityFrameworkCore;

namespace PetManagement.Entities;

public class PetDbContext : DbContext
{
    public PetDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Owner> Owners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
