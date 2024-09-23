using CSV2Sql.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Quality> Qualities { get; set; }
    public DbSet<Year> Years { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Journal>()
            .HasOne(j => j.Year)
            .WithOne(y => y.Journal)
            .HasForeignKey<Journal>(j => j.YearId);

        modelBuilder.Entity<Journal>()
            .HasMany(j => j.Qualities)
            .WithMany(q => q.Journals)
            .UsingEntity(jq => jq.ToTable("JournalQualities"));
    }
}