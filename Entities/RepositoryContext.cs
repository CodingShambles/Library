using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<Borrowment>? Borrowments { get; set; }
    public DbSet<Person>? People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>().ToTable("TBAddresses");
        modelBuilder.Entity<Book>().ToTable("TBBooks");
        modelBuilder.Entity<Borrowment>().ToTable("TBBorrowments");
        modelBuilder.Entity<Person>().ToTable("TBPeople");
        modelBuilder.Entity<Tags>().ToTable("TBTags");
    }
}