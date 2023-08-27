using l07_assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace l07_ef.Migrations;

public class JobDbContext : DbContext
{
    public DbSet<Job> Job { get; set; }

    public JobDbContext(DbContextOptions<JobDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId);
            entity.Property(e => e.JobTitle).IsRequired();
            entity.Property(e => e.JobDescription).IsRequired();
            entity.Property(e => e.CompanyName).IsRequired();
            entity.Property(e => e.YearsWorked).IsRequired();
        });
    }

}

