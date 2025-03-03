using CareerPathRecommender.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerPathRecommender.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Relation> Relations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}