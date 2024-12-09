using GardenTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GardenTest;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions options) : base(options)
    {
    }    
    
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("Person");
    }
    
}