using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public class ApplicationDbContext : DbContext
{
    //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    //{

    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=TestEF;Integrated Security=true;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Blog>()
        //    .HasIndex(x => new { x.Title, x.Url })
        //    .IsDescending(true, false);//<-- EF 7.0 new feature
    }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Author> Authors { get; set; }
}