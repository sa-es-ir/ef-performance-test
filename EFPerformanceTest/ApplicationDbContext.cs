using EFPerformanceTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPerformanceTest;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
}