using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFTest;

/// <summary>
/// we are using this only for generate migrations
/// </summary>
public class ApplicationDbContextBuilder : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestEF;Integrated Security=true;MultipleActiveResultSets=true", b => b.MigrationsAssembly("EFTest"));
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}