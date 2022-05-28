using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasOne(p => p.Company)
        .WithMany(t => t.Users)
        .HasForeignKey(p => p.CompanyName)
        .HasPrincipalKey(t => t.Name);
    }
}